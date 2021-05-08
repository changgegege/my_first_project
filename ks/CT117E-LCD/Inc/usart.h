#ifndef __USART_H
#define __USART_H

#include "stm32f10x.h"
#include <stdio.h>

void Usart_Init(void);
void Usart_SendChar(USART_TypeDef* USARTx, u8 ch);
void Usart_SendString(USART_TypeDef* USARTx, char* str);

#endif /*__USART_H*/

