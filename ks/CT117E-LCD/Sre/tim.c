#include "tim.h"

/* TIM2�ĳ�ʼ�� */
void TIM_Init(void) {
	//����TIM�Լ��жϳ�ʼ���ṹ��
	TIM_TimeBaseInitTypeDef TIM_TimeBaseStructure;
	NVIC_InitTypeDef NVIC_InitStructure;
	
	//ʹ��TIM2ʱ��
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM2, ENABLE);
	
	//�ж�����
	NVIC_InitStructure.NVIC_IRQChannel = TIM2_IRQn;      //�ж�ԴΪTIM2
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 1;
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&NVIC_InitStructure);
	
	NVIC_PriorityGroupConfig(NVIC_PriorityGroup_0);
	
	//TIM2��������
	TIM_TimeBaseStructure.TIM_Period = 1000;                       //�Զ���װ��ֵΪ1000������1ms
  TIM_TimeBaseStructure.TIM_Prescaler = 71;                      //Ԥ��ƵֵΪ72
  TIM_TimeBaseStructure.TIM_ClockDivision = 0;                   //ʱ�ӷ�ƵΪ0����1��Ƶ��ʹ��72MHzʱ��
  TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;    //���ϼ���
  TIM_TimeBaseInit(TIM2, &TIM_TimeBaseStructure);
	
	TIM_SetCounter(TIM2, 0);                     //���ö�ʱ��ֵΪ0����0��ʼ����
	
	TIM_Cmd(TIM2, ENABLE);                       //ʹ��TIM2
	TIM_ITConfig(TIM2, TIM_IT_Update, ENABLE);    //ʹ��TIM2�����ж�
}

