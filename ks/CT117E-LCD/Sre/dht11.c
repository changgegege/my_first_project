#include "dht11.h"

//定义全局变量，用户存储温湿度数据
double Humidity = 0, Temperature = 0;

/* 初始化DHT11的DATA引脚 */
void DHT11_Init(void)
{
	//定义GPIO初始化结构体
	GPIO_InitTypeDef GPIO_InitStructure;

	//使能GPIOA时钟
	RCC_APB2PeriphClockCmd(DHT11_CLOCK, ENABLE);
	
	//GPIOA参数配置
	GPIO_InitStructure.GPIO_Pin = DHT11_PIN;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;   //推挽输出模式
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;	
	GPIO_Init(DHT11_PORT, &GPIO_InitStructure);
}

/* DHT11的DATA引脚的上拉输入模式 */
void DHT11_Mode_IN(void)
{
	GPIO_InitTypeDef GPIO_InitStructure;
	
	GPIO_InitStructure.GPIO_Pin = DHT11_PIN;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IPU;       //上拉输入模式
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(DHT11_PORT, &GPIO_InitStructure);
}

/* DHT11的DATA引脚的推挽输出模式 */
void DHT11_Mode_Out(void)
{	
	GPIO_InitTypeDef GPIO_InitStructure;
	
	GPIO_InitStructure.GPIO_Pin = DHT11_PIN;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;    //推挽输出模式
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(DHT11_PORT, &GPIO_InitStructure);
}

/* 读取一个字节的数据 
dht11一次性发送40位数据，高位先出 */
u8 DHT11_ReadBytes(void)
{
	u8 data = 0, i;
	
	for(i=0;i<8;i++)
	{
		while(DHT11_VALUE() == 0);     //每一位都是先有54us的低电平信号
		
		Systick_Delay_Us(50);
		
		if(DHT11_VALUE() == 1)         //延时50us后还是高电平的话说明该位为高电平
		{
			while(DHT11_VALUE() == 1);   //等待该位发送完成
			data |= (u8)(0x80>>i);       //若数据是1则左移相应的位，若数据是0可不修改，无影响
		} 
	}
	return data;
}

u8 dht11_flag = 1;           //dht11数据采集标志位
u16 dht11_count = 0;         //dht11数据采集时间间隔
u8 dht11_getdata_flag = 0;   //是否采集到数据的标志  0代表未采集到的数据 1代表数据采集成功
u8 send_th_flag = 1;         //是否通过串口发送温湿度  0代表禁止发送 1代表使能发送
u8 biubiu_flag = 0;          //报警标志

/* dht11数据采集函数
返回值：
0代表数据采集失败；1代表数据采集成功；2代表此时未到数据采集阶段 */
u8 DHT11_GetData(void) {
	u16 count = 0;                        //判断数据接收是否失败
	u8 H_H, H_L, C_H, C_L, Check, temp;   //保存采集的数据
	
	//开始数据接收
	if(dht11_flag == 1) {
		dht11_flag = 0;                     //标志位清零
		dht11_count = 2000;                 //准备下一次的接收
		
		//发起始信号（输出） 总线拉低22ms，告诉传感器准备数据
		DHT11_Mode_Out();
		
		DHT11_LOW();
		Systick_Delay_Ms(22);
		
		DHT11_HIGH();
		Systick_Delay_Us(30);
		
		//响应信号（输入）  传感器把总线拉低83us，再拉高87us作为响应信号
		DHT11_Mode_IN();
		
		if(DHT11_VALUE() == 0) {
			while(DHT11_VALUE() == 0) {
				count++;
				if(count > 1000) {             //若count计数达到1000，说明此时已超过83us，接收到的不是响应信号
					dht11_getdata_flag = 0;      //数据接收失败
					return 0;
				}
			}
			
			count = 0;
			while(DHT11_VALUE() == 1) {
				count++;
				if(count > 1000) {             //若count计数达到1000，说明此时已超过87us，接收到的不是响应信号
					dht11_getdata_flag = 0;      //数据接收失败
					return 0;
				}
			}
			
			//接收数据（输入） 接收5字节数据，依次为湿度高温、低位、温度高位、低位以及校验位
			H_H = DHT11_ReadBytes();
			H_L = DHT11_ReadBytes();
			C_H = DHT11_ReadBytes();
			C_L = DHT11_ReadBytes();
			Check = DHT11_ReadBytes();
			
			//采集数据完成，总线拉高
			DHT11_Mode_Out();
			DHT11_HIGH();
			
			temp = H_H + H_L + C_H + C_L;      //放置温湿度高位和低位相加结果数据溢出，先用一个8位的临时变量存储和，再与校验值比较
			
			//若采集到的数据正确
			if(Check == temp) {
				Humidity = H_H + H_L / 10.0;     //得到湿度数据
				Temperature = C_H + C_L / 10.0;	 //得到温度数据
				dht11_getdata_flag = 1;          //数据接收成功，标志位置1
				
				//若此时温度高于最高温或者低于最低温，触发警报
				if(Temperature > max_T || Temperature < min_T) {
					if(Temperature > max_T) {
						biubiu_flag = 1;	           //温度高于最高位，报警值为1
					}
					else if(Temperature < min_T) {
						biubiu_flag = 2;             //温度低于最低温，报警值为2
					}						
				}
				else {
					biubiu_flag = 0;               //未触发警报，报警值为0，代表此时不是报警状态
				}
				
				//串口发送温湿度数据标志位有效时发送当前温湿度数据采集结果及警报状态
				if(send_th_flag == 1) {
					printf("读取DHT11数据成功！\r\n湿度：%.1lf ％RH,温度：%.1lf ℃,%d\r\n", Humidity, Temperature, biubiu_flag);
				}
				return 1;
			}
			else {
				if(send_th_flag == 1)
					printf("读取DHT11数据失败！\r\n");
				
				dht11_getdata_flag = 0;          //采集到的数据校验不成功，数据采集失败
				return 0;
			}
		}
		else {
			if(send_th_flag == 1)
				printf("读取DHT11数据失败！\r\n");
			dht11_getdata_flag = 0;            //未接收到响应信号，数据采集失败
			return 0;	
		}
	}
	else    //未到采集时间，函数返回2
		return 2;
}

