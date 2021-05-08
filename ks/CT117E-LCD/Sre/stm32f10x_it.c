/**
  ******************************************************************************
  * @file    I2S/SPI_I2S_Switch/stm32f10x_it.c 
  * @author  MCD Application Team
  * @version V3.5.0
  * @date    08-April-2011
  * @brief   Main Interrupt Service Routines.
  *          This file provides template for all exceptions handler and peripherals
  *          interrupt service routine.
  ******************************************************************************
  * @attention
  *
  * THE PRESENT FIRMWARE WHICH IS FOR GUIDANCE ONLY AIMS AT PROVIDING CUSTOMERS
  * WITH CODING INFORMATION REGARDING THEIR PRODUCTS IN ORDER FOR THEM TO SAVE
  * TIME. AS A RESULT, STMICROELECTRONICS SHALL NOT BE HELD LIABLE FOR ANY
  * DIRECT, INDIRECT OR CONSEQUENTIAL DAMAGES WITH RESPECT TO ANY CLAIMS ARISING
  * FROM THE CONTENT OF SUCH FIRMWARE AND/OR THE USE MADE BY CUSTOMERS OF THE
  * CODING INFORMATION CONTAINED HEREIN IN CONNECTION WITH THEIR PRODUCTS.
  *
  * <h2><center>&copy; COPYRIGHT 2011 STMicroelectronics</center></h2>
  ******************************************************************************
  */

/* Includes ------------------------------------------------------------------*/
#include "stm32f10x_it.h"

/** @addtogroup STM32F10x_StdPeriph_Examples
  * @{
  */

/** @addtogroup I2S_SPI_I2S_Switch
  * @{
  */ 

/* Private typedef -----------------------------------------------------------*/
/* Private define ------------------------------------------------------------*/
/* Private macro -------------------------------------------------------------*/
/* Private variables ---------------------------------------------------------*/
/* Private function prototypes -----------------------------------------------*/
/* Private functions ---------------------------------------------------------*/

/******************************************************************************/
/*            Cortex-M3 Processor Exceptions Handlers                         */
/******************************************************************************/

/**
  * @brief  This function handles NMI exception.
  * @param  None
  * @retval None
  */
void NMI_Handler(void)
{
}

/**
  * @brief  This function handles Hard Fault exception.
  * @param  None
  * @retval None
  */
void HardFault_Handler(void)
{
  /* Go to infinite loop when Hard Fault exception occurs */
  while (1)
  {}
}

/**
  * @brief  This function handles Memory Manage exception.
  * @param  None
  * @retval None
  */
void MemManage_Handler(void)
{
  /* Go to infinite loop when Memory Manage exception occurs */
  while (1)
  {}
}

/**
  * @brief  This function handles Bus Fault exception.
  * @param  None
  * @retval None
  */
void BusFault_Handler(void)
{
  /* Go to infinite loop when Bus Fault exception occurs */
  while (1)
  {}
}

/**
  * @brief  This function handles Usage Fault exception.
  * @param  None
  * @retval None
  */
void UsageFault_Handler(void)
{
  /* Go to infinite loop when Usage Fault exception occurs */
  while (1)
  {}
}

/**
  * @brief  This function handles Debug Monitor exception.
  * @param  None
  * @retval None
  */
void DebugMon_Handler(void)
{
}

/**
  * @brief  This function handles SVCall exception.
  * @param  None
  * @retval None
  */
void SVC_Handler(void)
{
}

/**
  * @brief  This function handles PendSV_Handler exception.
  * @param  None
  * @retval None
  */
void PendSV_Handler(void)
{
}

/**
  * @brief  This function handles SysTick Handler.
  * @param  None
  * @retval None
  */

void SysTick_Handler(void)
{
}

#include "lcd.h"
#include "usart.h"
#include "key.h"
#include "adc.h"
#include <stdio.h>
#include <string.h>

u8 usart_str[50] = {0};         //�洢���յ����ַ���ָ��
extern u8 biubiu_flag;          //��ʪ�������Ƿ��ڱ���״̬��־
extern u8 send_th_flag;         //�Ƿ������ڷ��͵�ǰ��ʪ�ȱ�־

void USART2_IRQHandler(void) {
	static u8 count = 0;          //��¼���յ����ֽ���
	u8 ch;                        //������յ����ֽ�
	if(USART_GetFlagStatus(USART2, USART_FLAG_RXNE) != RESET) {      //��������ݷ��͹���
		ch = USART_ReceiveData(USART2);    
		if(ch != ']') {                    //�����յ����ֽڲ���']'����ָ��δ�����꣬��������
			usart_str[count++] = ch;
		}
		else {                             //ָ�������ɣ�count����
			count = 0;
			
			//���յ���T1[FINAL]��ָ����͵�ǰ�¶���ֵ������״̬
			if(strncmp((char*)usart_str, "T1",2) == 0) {         //���appʹ��
				send_th_flag = 0;                       //��ֹ���ڷ�����ʪ������
				printf("%.1lf,%.1lf,%d", max_T, min_T, biubiu_flag);
			}
			
			//���յ���G1[FINAL]��ָ�������ʪ������
			if(strncmp((char*)usart_str, "G1",2) == 0) {       
				send_th_flag = 1;                       //ʹ�ܴ��ڷ�����ʪ������
			} 
			
			//���յ���W1[FINAL]��ָ�����ˮλ��ˮλ�ȼ��Լ�ˮλ����ʱ��
			if(strncmp((char*)usart_str, "W1",2) == 0) {
				send_th_flag = 0;                       //��ֹ���ڷ�����ʪ������
				printf("%d,%d,%d", high_val, level, time);
			}
			
			//���յ���W2[FINAL]��ָ�����ˮλ��ֵ��Ϣ
			if(strncmp((char*)usart_str, "W2",2) == 0) {
				send_th_flag = 0;                       //��ֹ���ڷ�����ʪ������
				printf("%d,%d,%d", threshold1, threshold2, threshold3);
			}
		}
	}
}

#include "key.h"
#include "adc.h"
#include "dht11.h"
#include <stdio.h>

extern u8 keyscan_count;         //����������ʱ������
extern u8 keyscan_flag;          //������ɱ�־λ

extern u16 voltage_val_count;    //ADC���ݲɼ���ʱ������
extern u8 voltage_val_flag;      //ADC���ݲɼ���־λ

extern u16 dht11_count;          //dht11���ݲɼ���ʱ������
extern u8 dht11_flag;            //dht11���ݲɼ���־λ

void TIM2_IRQHandler(void) {
	if(TIM_GetITStatus(TIM2, TIM_IT_Update) == SET) {      //TIM2�����ж���λ
		TIM_ClearITPendingBit(TIM2, TIM_IT_Update);          //����жϱ�־λ
		
		if(--keyscan_count == 0) {         //����������ʱ���
			keyscan_flag = 1;                //������ɱ�־λ��1
		}  
		
		if(--voltage_val_count == 0) {     //����ADC���ݲɼ�ʱ����
			voltage_val_flag = 1;            //ADC���ݲɼ���־λ��1
		}
		
		if(--dht11_count == 0) {           //����dht11���ݲɼ�ʱ����
			dht11_flag = 1;                  //dht11���ݲɼ���־λ��1
		}
	}
}

/******************************************************************************/
/*                 STM32F10x Peripherals Interrupt Handlers                   */
/*  Add here the Interrupt Handler for the used peripheral(s) (PPP), for the  */
/*  available peripheral interrupt handler's name please refer to the startup */
/*  file (startup_stm32f10x_xx.s).                                            */
/******************************************************************************/

/**
  * @brief  This function handles PPP interrupt request.
  * @param  None
  * @retval None
  */
/*void PPP_Switch_IRQHandler(void)
{
}*/

/**
  * @}
  */ 

/**
  * @}
  */ 

/******************* (C) COPYRIGHT 2011 STMicroelectronics *****END OF FILE****/
