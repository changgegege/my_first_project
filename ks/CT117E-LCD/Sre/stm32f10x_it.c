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

u8 usart_str[50] = {0};         //存储接收到的字符串指令
extern u8 biubiu_flag;          //温湿度数据是否处于报警状态标志
extern u8 send_th_flag;         //是否允许串口发送当前温湿度标志

void USART2_IRQHandler(void) {
	static u8 count = 0;          //记录接收到的字节数
	u8 ch;                        //保存接收到的字节
	if(USART_GetFlagStatus(USART2, USART_FLAG_RXNE) != RESET) {      //如果有数据发送过来
		ch = USART_ReceiveData(USART2);    
		if(ch != ']') {                    //若接收到的字节不是']'代表指令未发送完，继续接收
			usart_str[count++] = ch;
		}
		else {                             //指令接收完成，count清零
			count = 0;
			
			//接收到“T1[FINAL]”指令，发送当前温度阈值及报警状态
			if(strncmp((char*)usart_str, "T1",2) == 0) {         //配合app使用
				send_th_flag = 0;                       //禁止串口发送温湿度数据
				printf("%.1lf,%.1lf,%d", max_T, min_T, biubiu_flag);
			}
			
			//接收到“G1[FINAL]”指令，发送温湿度数据
			if(strncmp((char*)usart_str, "G1",2) == 0) {       
				send_th_flag = 1;                       //使能串口发送温湿度数据
			} 
			
			//接收到“W1[FINAL]”指令，发送水位、水位等级以及水位持续时间
			if(strncmp((char*)usart_str, "W1",2) == 0) {
				send_th_flag = 0;                       //禁止串口发送温湿度数据
				printf("%d,%d,%d", high_val, level, time);
			}
			
			//接收到“W2[FINAL]”指令，发送水位阈值信息
			if(strncmp((char*)usart_str, "W2",2) == 0) {
				send_th_flag = 0;                       //禁止串口发送温湿度数据
				printf("%d,%d,%d", threshold1, threshold2, threshold3);
			}
		}
	}
}

#include "key.h"
#include "adc.h"
#include "dht11.h"
#include <stdio.h>

extern u8 keyscan_count;         //按键消抖延时毫秒数
extern u8 keyscan_flag;          //消抖完成标志位

extern u16 voltage_val_count;    //ADC数据采集延时毫秒数
extern u8 voltage_val_flag;      //ADC数据采集标志位

extern u16 dht11_count;          //dht11数据采集延时毫秒数
extern u8 dht11_flag;            //dht11数据采集标志位

void TIM2_IRQHandler(void) {
	if(TIM_GetITStatus(TIM2, TIM_IT_Update) == SET) {      //TIM2更新中断置位
		TIM_ClearITPendingBit(TIM2, TIM_IT_Update);          //清除中断标志位
		
		if(--keyscan_count == 0) {         //按键消抖延时完成
			keyscan_flag = 1;                //消抖完成标志位置1
		}  
		
		if(--voltage_val_count == 0) {     //到达ADC数据采集时间间隔
			voltage_val_flag = 1;            //ADC数据采集标志位置1
		}
		
		if(--dht11_count == 0) {           //到达dht11数据采集时间间隔
			dht11_flag = 1;                  //dht11数据采集标志位置1
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
