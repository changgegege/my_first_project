#include "led.h"

/* LED�ĳ�ʼ�� */
void LED_Init(void) {
	//����GPIO��ʼ���ṹ��
	GPIO_InitTypeDef GPIO_InitStructure;
	
	//����GPIOC��GPIOD��ʱ�ӣ�����GPIOD����Ϊ������
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOC | RCC_APB2Periph_GPIOD, ENABLE);
	
	//����GPIOC��ʼ������
	GPIO_InitStructure.GPIO_Pin = LED_All;
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
	//��ʼ��GPIO
  GPIO_Init(GPIOC, &GPIO_InitStructure);
	
	//����GPIOD��ʼ������
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_2;
	GPIO_Init(GPIOD, &GPIO_InitStructure);
	
	//Ϩ������LED��
	GPIO_SetBits(GPIOD, GPIO_Pin_2);         //�������򿪣�LED�Ƶ�״̬���Ա�д��
	GPIO_SetBits(GPIOC, LED_All);            //Ϩ������LED��
	GPIO_ResetBits(GPIOD, GPIO_Pin_2);       //�ر�������
}

/* LED�ƿ��ƺ���
�������ܣ�
led������Ҫ���Ƶ�LED�Ƶı�ţ���ΪLED1-LED8�Լ�LED_ALL
state������Ҫ���ƵĵƵ�״̬��0�������LED�ƣ�1����Ϩ��LED�� */
void LED_Control(u16 led, u8 state) {
	if(state == 0) {
		GPIO_SetBits(GPIOD, GPIO_Pin_2);
		GPIO_ResetBits(GPIOC, led);
		GPIO_ResetBits(GPIOD, GPIO_Pin_2);
	}
	else if(state == 1) {
		GPIO_SetBits(GPIOD, GPIO_Pin_2);
		GPIO_SetBits(GPIOC, led);
		GPIO_ResetBits(GPIOD, GPIO_Pin_2);
	}
}

