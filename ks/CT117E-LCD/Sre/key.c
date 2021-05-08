#include "key.h"

/* 按键的初始化 */
void KEY_Init(void) {
	//定义GPIO初始化结构体
	GPIO_InitTypeDef GPIO_InitStructure;
	
	//开启GPIOA和GPIOB的时钟
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA | RCC_APB2Periph_GPIOB, ENABLE);
	
	//配置GPIO参数以及初始化GPIO，作为按键的话配置为上拉输入模式
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0 | GPIO_Pin_8;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IPU;
  GPIO_Init(GPIOA, &GPIO_InitStructure);
	
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_1 | GPIO_Pin_2;
	GPIO_Init(GPIOB, &GPIO_InitStructure);
}

//定义各种全局变量
u8 keyscan_count = 20;      //按键消抖，20ms
u8 keyscan_flag = 0;        //20ms延时完成后，该标志位置1
u8 b2_count_dht11 = 0;      //判断要修改温湿度的哪个阈值数据 1修改最高温，2修改最低温
u8 b2_count_adc = 0;        //判断要修改水位的哪个阈值数据   1修改阈值1,2修改阈值2,3修改阈值3
u8 b1_flag = 0;             //界面标志，0时在dht11数据界面，1时在dht11参数界面，2时在水位数据界面，3时在水位参数界面

double max_T = 30.0, min_T = 20.0;       //温湿度阈值设定，最高温和最低温
double tmp_max = 30.0, tmp_min = 20.0;   //在用户在界面中通过按键设置阈值时首先用该临时变量保存，在界面切换时判断修改后的阈值是否合理

/* 按键扫描函数：实现判断是否有按键按下，以及实现按键功能
其余设计：实现了按键消抖、解决一次按下多次触发的情况
各按键功能介绍：
KEY1：界面切换     KEY2：选择要修改的阈值
KEY3：阈值增加     KEY4：阈值减少 */
void KEY_Scan(void) {
	static u8 keydownflag = 0;     //判断当前是否有按键按下  0代表此时没有按键按下，1代表此时有按键按下
	
	//若有按键按下
	if((KEY1 == 0 || KEY2 == 0 || KEY3 == 0 || KEY4 == 0) && keydownflag == 0) {
		keydownflag = 1;      //标志位置1，说明此时有按键按下
		keyscan_count = 20;   //准备按键消抖，为不影响主函数的执行，使用一个计数值，并且该计数值在TIM2每进入一次中断时减1，当减到0时实现延时20ms的作用
		
		if(keyscan_flag) {    //若此时消抖完成
			keyscan_flag = 0;   //标志位清0
			
			//按键1按下
			if(KEY1 == 0) {
				b1_flag++;        //界面标志位加1，代表切换到下一个界面
				
				//此部分函数实现若当前处于界面2，即dht11参数界面，当要切换界面时判断修改后的阈值是否合理
				if(b1_flag == 2) {
					if(tmp_min >= tmp_max) {         //若最高温小于最低温，参数不合理
						tmp_max = max_T;               //将临时变量的值赋值为最新一次合理的温度阈值
						tmp_min = min_T;
						LED_Control(LED3, 0);          //参数不合理，LED3点亮
					}
					else {
						max_T = tmp_max;               //参数合理，将温度阈值设置为临时变量的值
						min_T = tmp_min;
						
						_24c02_Write_Temperature();    //将修改后的阈值写入到EEPROM中
						LED_Control(LED3, 1);          //参数合理，LED3熄灭
					}
				}
				
				//此部分函数实现若当时处于界面4，即水位参数界面，当要切换界面时判断修改后的阈值是否合理
				if(b1_flag == 4) {
					//阈值不合理
					if(tmp_threshold1 >= tmp_threshold2 || tmp_threshold2 >= tmp_threshold3) {
						tmp_threshold1 = threshold1;              //临时变量的值赋值为最新一次合理的阈值
						tmp_threshold2 = threshold2;
						tmp_threshold3 = threshold3;
						LED_Control(LED4, 0);                     //参数不合理，LED4点亮
					}
					else {
						//阈值成功修改后，水位持续时间重置
						if(threshold1 != tmp_threshold1 || threshold2 != tmp_threshold2 || threshold3 != tmp_threshold3) {
							time = 0;          
						}
						
						threshold1 = tmp_threshold1;          //参数合理，将阈值设置为临时变量的值
						threshold2 = tmp_threshold2;
						threshold3 = tmp_threshold3;
						
						_24c02_Write_Threshold();             //将修改后的阈值写入到EEPROM中
						LED_Control(LED4, 1);                 //参数合理，LED4熄灭
					}
				}
				
				//本次设计只有4个界面，所以当b1_flag的值为4时需要切换到第一个界面实现循环
				if(b1_flag > 3) {
					b1_flag = 0;
				}
				
				//每次界面切换后，要修改的阈值的判断标志位清零
				b2_count_adc = 0;
				b2_count_dht11 = 0;
			}
			
			//按键2按下，并且只有在参数界面有效
			else if(KEY2 == 0 && (b1_flag == 1 || b1_flag == 3)) {
				if(b1_flag == 1) {          //dht11参数界面
					b2_count_dht11++;         //有最高温和最低温可选，每按下一次按键2，可切换要修改最高温还是最低温，可修改的阈值文字部分高亮显示
					if(b2_count_dht11 > 2) {
						b2_count_dht11 = 1;
					}
				}
				else if(b1_flag == 3) {     //水位参数界面
					b2_count_adc++;           //阈值1，阈值2，阈值3可选
					if(b2_count_adc > 3) {
						b2_count_adc = 1;
					}
				}
			}
			
			//按键3按下，并且只在参数界面有效
			else if(KEY3 == 0 && (b1_flag == 1 || b1_flag == 3)) {
				if(b1_flag == 1) {            //dht11参数界面
					switch(b2_count_dht11) {
						case 1:                   //最高温加0.1
							tmp_max += 0.1;
							break;
						case 2:                   //最低温加0.1
							tmp_min += 0.1; 
							break;
						default:
							break;
					}
				}
				else if(b1_flag == 3) {       //水位参数界面
					switch(b2_count_adc) {
						case 1:                   //阈值1加10
							if(tmp_threshold1 < 390)
								tmp_threshold1 += 10;
							break;
						case 2:                   //阈值2加10
							if(tmp_threshold2 < 390)
								tmp_threshold2 += 10;
							break;
						case 3:                   //阈值3加10
							if(tmp_threshold3 < 390)
								tmp_threshold3 += 10;
							break;
						default:
							break;
					}
				}
			}
			
			//按键4按下，并且只在参数界面有效
			else if(KEY4 == 0 && (b1_flag == 1 || b1_flag == 3)) {
				if(b1_flag == 1) {            //dht11参数界面
					switch(b2_count_dht11) {
						case 1:                   //最高温减0.1
							tmp_max -= 0.1;
							break;
						case 2:                   //最低温减0.1
							tmp_min -= 0.1;
							break;
						default:
							break;
					}
				}
				else if(b1_flag == 3) {       //水位参数界面
					switch(b2_count_adc) {
						case 1:                   //阈值1减10
							if(tmp_threshold1 > 10)
								tmp_threshold1 -= 10;
							break;
						case 2:                   //阈值2减10
							if(tmp_threshold2 > 10)
								tmp_threshold2 -= 10;
							break;
						case 3:                   //阈值3减10
							if(tmp_threshold3 > 10)
								tmp_threshold3 -= 10;
							break;
						default:
							break;
					}
				}
			}
		}
	}
	
	//无按键按下时
	else if(KEY1 == 1 && KEY2 == 1 && KEY3 == 1 && KEY4 == 1 && keydownflag == 1) {
		keydownflag = 0;
	}
}

u8 print_str[5][20] = {0};    //存储要显示在LCD上的字符串
u8 dht11_rece_flag = 2;       //dht11是否采集到数据的标志位

/*菜单显示函数：实现各界面在LCD上字符串的显示以及报警指示灯*/
void KEY_Menu(void) {
	u8 days, hours, mintues, seconds;      //保存水位持续时间的天数、小时数、分钟数以及秒数
	
	//如果温度高于最高温或者低于最低温报警，LED1点亮
	if(biubiu_flag == 1 || biubiu_flag == 2) {
		LED_Control(LED1, 0);
	}
	else {
		LED_Control(LED1, 1);
	}
	
	//如果水位等级大于或等于2报警，LED2点亮
	if(level >= 2) {
		LED_Control(LED2, 0);
	}
	else {
		LED_Control(LED2, 1);
	}
	
	//根据b1_flag的值判断当前要显示哪个界面以及其对应的字符串
	switch(b1_flag) {
		case 0:                //dht11数据界面
			//如果未采集到数据或未到采集时间但上一次未采集到数据（处于采集失败界面）
			if(dht11_rece_flag == 0 || (dht11_rece_flag == 2 && dht11_getdata_flag == 0)){     //改进不会自动跳转画面的问题以及疯狂跳转问题
				sprintf((char*)print_str[0], "     DHT11_Data      ");
				sprintf((char*)print_str[1], "   FAIL!!!           ");
				sprintf((char*)print_str[2], "                     ");
				sprintf((char*)print_str[3], "                     ");
				sprintf((char*)print_str[4], "                     ");
			}
			//如果采集到数据或未到采集时间但上一次采集到了数据，保留上一次采集的数据在屏幕中显示
			else if(dht11_rece_flag == 1 || (dht11_rece_flag == 2 && dht11_getdata_flag == 1)) {
				dht11_getdata_flag = 1;        //修改该标志位为采集到了数据，下一次未到采集时间时不会跳转到fail界面
				
				sprintf((char*)print_str[0], "     DHT11_Data      ");
				sprintf((char*)print_str[1], "   T:%.1lf C         ",Temperature);
				sprintf((char*)print_str[2], "   H:%.1lf %cRH      ",Humidity,'%');
				sprintf((char*)print_str[3], "                     ");
				sprintf((char*)print_str[4], "                     ");
			}
			break;
		case 1:         //dht11参数界面
			sprintf((char*)print_str[0], "     DHT11_Para      ");
			sprintf((char*)print_str[1], "   TMAX:%.1lf C      ",tmp_max);
			sprintf((char*)print_str[2], "   TMIN:%.1lf C      ",tmp_min);
			sprintf((char*)print_str[3], "                     ");
			sprintf((char*)print_str[4], "                     ");
			break;
		case 2:         //水位数据界面
			days = time / (3600*24);           //time中存储的是秒数，将其转换为对应的xx:xx:xx:xx的样式显示
			hours = time % (3600*24) /3600;
			mintues = time % (3600*24) % 3600 /60;
			seconds = time % (3600*24) %3600 % 60;
		
			sprintf((char*)print_str[0], "      ADC_Data       ");
			sprintf((char*)print_str[1], "   V:%.2lfV          ",voltage_val);
			sprintf((char*)print_str[2], "   H:%dcm            ",high_val);
			sprintf((char*)print_str[3], "   Level:%d          ",level);	
			sprintf((char*)print_str[4], "   TIME:%02d:%02d:%02d:%02d   ",days,hours,mintues,seconds);
			break;
		case 3:         //水位参数界面
			sprintf((char*)print_str[0], "      ADC_Para       ");
			sprintf((char*)print_str[1], "   Level1:%dcm       ",tmp_threshold1);
			sprintf((char*)print_str[2], "   Level2:%dcm       ",tmp_threshold2);
			sprintf((char*)print_str[3], "   Level3:%dcm       ",tmp_threshold3);
			sprintf((char*)print_str[4], "                     ");
			break;
	}
	
	LCD_SetTextColor(White);                              //字体颜色设置为白色
	LCD_DisplayStringLine(Line1, (u8 *)print_str[0]);     //打印第一行的字符串
	
	//若当前是dht11参数界面
	if(b1_flag == 1) {
		//根据b2_count_dht11的值高亮显示某一阈值，代表可修改
		if(b2_count_dht11 == 1)
			LCD_SetTextColor(Green);   
		else
			LCD_SetTextColor(White);
		LCD_DisplayStringLine(Line3, (u8 *)print_str[1]);
				
		if(b2_count_dht11 == 2)
			LCD_SetTextColor(Green);
		else
			LCD_SetTextColor(White);
		LCD_DisplayStringLine(Line5, (u8 *)print_str[2]);
	}
	
	//若当前是水位参数界面
	else if(b1_flag == 3) {
		//根据b2_count_adc的值高亮显示某一阈值，代表可修改
		if(b2_count_adc == 1)       
			LCD_SetTextColor(Green);
		else
			LCD_SetTextColor(White);
		LCD_DisplayStringLine(Line3, (u8 *)print_str[1]);
				
		if(b2_count_adc == 2)
			LCD_SetTextColor(Green);
		else
			LCD_SetTextColor(White);
		LCD_DisplayStringLine(Line5, (u8 *)print_str[2]);
				
		if(b2_count_adc == 3)
			LCD_SetTextColor(Green);
		else
			LCD_SetTextColor(White);
		LCD_DisplayStringLine(Line7, (u8 *)print_str[3]);
	}
	
	//若当前是数据界面，正常显示内容
	else {
		LCD_DisplayStringLine(Line3, (u8 *)print_str[1]);
		LCD_DisplayStringLine(Line5, (u8 *)print_str[2]);
		LCD_DisplayStringLine(Line7, (u8 *)print_str[3]);
	}
		

	LCD_DisplayStringLine(Line9, (u8 *)print_str[4]);    //只在水位数据界面有具体内容
}

