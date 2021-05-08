#ifndef __LED_H
#define __LED_H

#include "stm32f10x.h"

//LED�Ƶĺ궨��
#define LED1     GPIO_Pin_8
#define LED2     GPIO_Pin_9
#define LED3     GPIO_Pin_10
#define LED4     GPIO_Pin_11
#define LED5     GPIO_Pin_12
#define LED6     GPIO_Pin_13
#define LED7     GPIO_Pin_14
#define LED8     GPIO_Pin_15
#define LED_All  GPIO_Pin_8 | GPIO_Pin_9 | GPIO_Pin_10 | GPIO_Pin_11 | GPIO_Pin_12 | GPIO_Pin_13 | GPIO_Pin_14 | GPIO_Pin_15

void LED_Init(void);
void LED_Control(u16 led, u8 state);

#endif /*__LED_H*/

