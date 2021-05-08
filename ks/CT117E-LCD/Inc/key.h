#ifndef __KEY_H
#define __KEY_H

#include "stm32f10x.h"
#include "lcd.h"
#include "dht11.h"
#include "adc.h"
#include "led.h"
#include "24c02.h"
#include <stdio.h>

//宏定义各按键输入的键值
#define KEY1    GPIO_ReadInputDataBit(GPIOA,GPIO_Pin_0)
#define KEY2    GPIO_ReadInputDataBit(GPIOA,GPIO_Pin_8)
#define KEY3    GPIO_ReadInputDataBit(GPIOB,GPIO_Pin_1)
#define KEY4    GPIO_ReadInputDataBit(GPIOB,GPIO_Pin_2)

extern double max_T,min_T;
extern double tmp_max,tmp_min;
extern u8 dht11_rece_flag;

void KEY_Init(void);
void KEY_Scan(void);
void KEY_Menu(void);

#endif /*__KEY_H*/

