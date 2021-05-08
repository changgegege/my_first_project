#ifndef __24C02_H
#define __24C02_H

#include "stm32f10x.h"
#include "i2c.h"
#include "adc.h"
#include "key.h"
#include "systick.h"
#include "usart.h"
#include <stdio.h>

void _24c02_Write(u8 address, u8 data);
u8 _24c02_Read(u8 address);
void _24c02_Write_Temperature(void);
void _24c02_Write_Threshold(void);
void _24c02_Read_Temprature_Threshold(void);
void _24c02_Write_Time_Level(void);
void _24c02_Read_Time_Level(void);

#endif /*__24C02_H*/

