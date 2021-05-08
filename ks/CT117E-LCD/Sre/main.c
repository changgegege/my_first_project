#include "stm32f10x.h"
#include "lcd.h"
#include "led.h"
#include "key.h"
#include "i2c.h"
#include "24c02.h"
#include "systick.h"
#include "adc.h"
#include "usart.h"
#include "dht11.h"
#include "tim.h"

int main(void)
{
	Systick_Delay_Ms(200);
	
	//模块初始化
	LED_Init();
	KEY_Init();
	DHT11_Init();
	i2c_init();
	Adc_Init();
	Usart_Init();
	TIM_Init();
	
	//获取存储在EEPROM中的温湿度以及水位阈值信息、获取水位持续时间以及断电前的水位等级
	_24c02_Read_Temprature_Threshold();
	_24c02_Read_Time_Level();
	
	//LCD初始化
	STM3210B_LCD_Init();
	LCD_Clear(Black);
	LCD_SetBackColor(Black);
	LCD_SetTextColor(White);
	
	//防止LCD初始化时对LED造成影响，在初始化完成后关闭所有LED灯
	LED_Control(LED_All, 1);	
	
	Systick_Delay_Ms(200);
	
	//死循环中实现2s获取一次温湿度数据，实现界面的显示，按键扫描和1s获取一次水位信息
	while(1) {
		dht11_rece_flag = DHT11_GetData();
		KEY_Menu();
		KEY_Scan();
		Adc_Get_Voltage_Val();
	}
}

