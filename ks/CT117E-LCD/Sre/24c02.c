#include "24c02.h"

/* 向EEPROM中写入数据的函数
参数介绍：
address：要写入的地址
data：要写入的数据
指令介绍：
0x0a指令代表写入数据 */
void _24c02_Write(u8 address, u8 data) {
	I2CStart();               //I2C总线启动
	I2CSendByte(0xa0);        //要写入数据的命令
	I2CWaitAck();             //等待应答
	I2CSendByte(address);     //发送要写入的地址
	I2CWaitAck();
	I2CSendByte(data);        //发送要写入的数据
	I2CWaitAck();
	I2CStop();                //I2C总线停止
}

/* 向EEPROM中读取数据的函数
参数介绍：
address：要读取数据的地址
指令介绍：
0x0a指令代表写入数据，0xa1指令代表读取数据 */
u8 _24c02_Read(u8 address) {
	u8 tmp;                   //临时变量，用于存储读取的数据
	
	I2CStart();               //I2C总线开启
	I2CSendByte(0xa0);        //写入数据的指令
	I2CWaitAck();
	I2CSendByte(address);     //写入要读取数据的地址
	I2CWaitAck();
	
	I2CStart();               //要开启两次总线
	I2CSendByte(0xa1);        //读取数据的指令
	I2CWaitAck();
	tmp = I2CReceiveByte();   //读取数据并保存到临时变量中
	I2CWaitAck();
	I2CStop();                //I2C总线停止
	
	return tmp;
}

/* 将当前温湿度阈值存储到EEPROM
0x01存储最高温整数部分，0x02存储最高温小数部分，0x03存储最低温整数部分，0x04存储最低温小数部分 */
void _24c02_Write_Temperature(void) {
		u16 tmp;
	
		//存储最高温
		tmp = max_T*100;               //如果不是100倍可能会产生小数部分差0.1的情况
		_24c02_Write(0x01, tmp / 100);
		Systick_Delay_Ms(5);           //由于写入数据需要花费较多时间，延时可保证数据可以正常写入
		_24c02_Write(0x02, tmp % 100);
		Systick_Delay_Ms(5);
	
		//存储最低温
		tmp = min_T*100;
		_24c02_Write(0x03, tmp / 100);
		Systick_Delay_Ms(5);
		_24c02_Write(0x04, tmp % 100);
		Systick_Delay_Ms(5);
}

/* 将当前水位阈值存储到EEPROM
0x05和0x06用于存储阈值1数据，0x07和0x08用于存储阈值2数据，0x09和0x0a用于存储阈值3数据 */
void _24c02_Write_Threshold(void) {      //400超过u8的限制，要用两个存储单元实现
		//存储阈值1
		_24c02_Write(0x05, threshold1 / 10);
		Systick_Delay_Ms(5);
		_24c02_Write(0x06, threshold1 % 10);
		Systick_Delay_Ms(5);
	
		//存储阈值2
		_24c02_Write(0x07, threshold2 / 10);
		Systick_Delay_Ms(5);
		_24c02_Write(0x08, threshold2 % 10);
		Systick_Delay_Ms(5);
		
		//存储阈值3
		_24c02_Write(0x09, threshold3 / 10);
		Systick_Delay_Ms(5);
		_24c02_Write(0x0a, threshold3 % 10);
		Systick_Delay_Ms(5);
}

/* 将当前水位持续时间以及水位等级存储到EEPROM
0x0b、0x0c、0x0d以及0x0e存储水位持续时间，0x0f存储当前水位等级
说明：存储水位等级是为了保证不会每次一上电，水位持续时间都再次从0开始计时 */
void _24c02_Write_Time_Level(void) {
		_24c02_Write(0x0b, time / (3600*24));
		Systick_Delay_Ms(5);
		_24c02_Write(0x0c, time % (3600*24) / 3600);
		Systick_Delay_Ms(5);
		_24c02_Write(0x0d, time % (3600*24) % 3600 / 60);
		Systick_Delay_Ms(5);
		_24c02_Write(0x0e, time % (3600*24) % 3600 % 60);
		Systick_Delay_Ms(5);
	
		_24c02_Write(0x0f, level);
		Systick_Delay_Ms(5);
}

/* 读取存储在EEPROM中的温湿度及水位阈值数据 */
void _24c02_Read_Temprature_Threshold(void) {
	u8 tmp1,tmp2;
	
	//最高温
	tmp1 = _24c02_Read(0x01);
	Systick_Delay_Ms(5);
	tmp2 = _24c02_Read(0x02);
	Systick_Delay_Ms(5);
	max_T = tmp_max = (tmp1*100 + tmp2) / 100.0;
	
	//最低温
	tmp1 = _24c02_Read(0x03);
	Systick_Delay_Ms(5);
	tmp2 = _24c02_Read(0x04);
	Systick_Delay_Ms(5);
	min_T = tmp_min = (tmp1*100 + tmp2) / 100.0;
	
	//阈值1
	tmp1 = _24c02_Read(0x05);
	Systick_Delay_Ms(5);
	tmp2 = _24c02_Read(0x06);
	Systick_Delay_Ms(5);
	threshold1 = tmp_threshold1 = tmp1*10 + tmp2;
	
	//阈值2
	tmp1 = _24c02_Read(0x07);
	Systick_Delay_Ms(5);
	tmp2 = _24c02_Read(0x08);
	Systick_Delay_Ms(5);
	threshold2 = tmp_threshold2 = tmp1*10 + tmp2;
	
	//阈值3
	tmp1 = _24c02_Read(0x09);
	Systick_Delay_Ms(5);
	tmp2 = _24c02_Read(0x0a);
	Systick_Delay_Ms(5);
	threshold3 = tmp_threshold3 = tmp1*10 + tmp2;
}

/* 读取存储在EEPROM中的水位持续时间和水位等级数据 */
void _24c02_Read_Time_Level(void) {
	u8 d,h,m,s,tmp_level;
	
	d = _24c02_Read(0x0b);
	Systick_Delay_Ms(5);
	h = _24c02_Read(0x0c);
	Systick_Delay_Ms(5);	
	m = _24c02_Read(0x0d);
	Systick_Delay_Ms(5);
	s = _24c02_Read(0x0e);
	Systick_Delay_Ms(5);
	tmp_level = _24c02_Read(0x0f);
	Systick_Delay_Ms(5);
	
	time = d * (3600*24) + h * 3600 + m * 60 + s;
	level = tmp_level;
}

