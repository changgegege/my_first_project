#ifndef __ADC_H
#define __ADC_H

#include "stm32f10x.h"
#include "24c02.h"
#include <stdio.h>

extern double voltage_val;
extern u16 high_val;
extern u16 threshold1, threshold2, threshold3;
extern u16 tmp_threshold1, tmp_threshold2, tmp_threshold3;
extern u8 level;
extern u32 time;

void Adc_Init(void);
void Adc_Get_Voltage_Val(void);

#endif /*__ADC_H*/

