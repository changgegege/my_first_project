#ifndef __DHT11_H
#define __DHT11_H

#include "stm32f10x.h"
#include "systick.h"
#include "lcd.h"
#include "usart.h"
#include "key.h"
#include <stdio.h>

//宏定义连接dht11的DATA引脚，使用PA1引脚
#define DHT11_CLOCK    RCC_APB2Periph_GPIOA
#define DHT11_PORT     GPIOA
#define DHT11_PIN      GPIO_Pin_1

//宏定义dht11数据引脚的输出模式、输入模式、输出高电平、低电平以及读取引脚数据
#define DHT11_OUT()        DHT11_Mode_Out()
#define DHT11_IN()         DHT11_Mode_IN()
#define DHT11_HIGH()       GPIO_SetBits(GPIOA, GPIO_Pin_1)
#define DHT11_LOW()        GPIO_ResetBits(GPIOA, GPIO_Pin_1)
#define DHT11_VALUE()      GPIO_ReadInputDataBit(GPIOA, GPIO_Pin_1)

extern double Humidity, Temperature;
extern u8 dht11_getdata_flag;
extern u8 biubiu_flag;

void DHT11_Init(void);
u8 DHT11_ReadBytes(void);
u8 DHT11_GetData(void);

#endif /*__DHT11_H*/

