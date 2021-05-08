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
	
	//ģ���ʼ��
	LED_Init();
	KEY_Init();
	DHT11_Init();
	i2c_init();
	Adc_Init();
	Usart_Init();
	TIM_Init();
	
	//��ȡ�洢��EEPROM�е���ʪ���Լ�ˮλ��ֵ��Ϣ����ȡˮλ����ʱ���Լ��ϵ�ǰ��ˮλ�ȼ�
	_24c02_Read_Temprature_Threshold();
	_24c02_Read_Time_Level();
	
	//LCD��ʼ��
	STM3210B_LCD_Init();
	LCD_Clear(Black);
	LCD_SetBackColor(Black);
	LCD_SetTextColor(White);
	
	//��ֹLCD��ʼ��ʱ��LED���Ӱ�죬�ڳ�ʼ����ɺ�ر�����LED��
	LED_Control(LED_All, 1);	
	
	Systick_Delay_Ms(200);
	
	//��ѭ����ʵ��2s��ȡһ����ʪ�����ݣ�ʵ�ֽ������ʾ������ɨ���1s��ȡһ��ˮλ��Ϣ
	while(1) {
		dht11_rece_flag = DHT11_GetData();
		KEY_Menu();
		KEY_Scan();
		Adc_Get_Voltage_Val();
	}
}

