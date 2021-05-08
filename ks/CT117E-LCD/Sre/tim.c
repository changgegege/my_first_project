#include "tim.h"

/* TIM2的初始化 */
void TIM_Init(void) {
	//定义TIM以及中断初始化结构体
	TIM_TimeBaseInitTypeDef TIM_TimeBaseStructure;
	NVIC_InitTypeDef NVIC_InitStructure;
	
	//使能TIM2时钟
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM2, ENABLE);
	
	//中断配置
	NVIC_InitStructure.NVIC_IRQChannel = TIM2_IRQn;      //中断源为TIM2
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 1;
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&NVIC_InitStructure);
	
	NVIC_PriorityGroupConfig(NVIC_PriorityGroup_0);
	
	//TIM2参数配置
	TIM_TimeBaseStructure.TIM_Period = 1000;                       //自动重装载值为1000，代表1ms
  TIM_TimeBaseStructure.TIM_Prescaler = 71;                      //预分频值为72
  TIM_TimeBaseStructure.TIM_ClockDivision = 0;                   //时钟分频为0代表1分频，使用72MHz时钟
  TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;    //向上计数
  TIM_TimeBaseInit(TIM2, &TIM_TimeBaseStructure);
	
	TIM_SetCounter(TIM2, 0);                     //设置定时器值为0，从0开始计数
	
	TIM_Cmd(TIM2, ENABLE);                       //使能TIM2
	TIM_ITConfig(TIM2, TIM_IT_Update, ENABLE);    //使能TIM2更新中断
}

