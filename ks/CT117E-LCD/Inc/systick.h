#ifndef __SYSTICK_H
#define __SYSTICK_H

#include "stm32f10x.h"

void Systick_Delay_Ms(uint32_t time);
void Systick_Delay_Us(uint32_t time);

#endif /*__SYSTICK_H*/

