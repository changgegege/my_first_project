#include "led.h"

/* LED的初始化 */
void LED_Init(void) {
	//定义GPIO初始化结构体
	GPIO_InitTypeDef GPIO_InitStructure;
	
	//开启GPIOC和GPIOD的时钟，开启GPIOD是因为锁存器
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOC | RCC_APB2Periph_GPIOD, ENABLE);
	
	//配置GPIOC初始化参数
	GPIO_InitStructure.GPIO_Pin = LED_All;
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
	//初始化GPIO
  GPIO_Init(GPIOC, &GPIO_InitStructure);
	
	//配置GPIOD初始化参数
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_2;
	GPIO_Init(GPIOD, &GPIO_InitStructure);
	
	//熄灭所有LED灯
	GPIO_SetBits(GPIOD, GPIO_Pin_2);         //锁存器打开，LED灯的状态可以被写入
	GPIO_SetBits(GPIOC, LED_All);            //熄灭所有LED灯
	GPIO_ResetBits(GPIOD, GPIO_Pin_2);       //关闭锁存器
}

/* LED灯控制函数
参数介绍：
led：代表要控制的LED灯的编号，可为LED1-LED8以及LED_ALL
state：代表要控制的灯的状态，0代表点亮LED灯，1代表熄灭LED灯 */
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

