#include "usart.h"

/* 串口2的初始化 */
void Usart_Init(void) {
	//定义GPIO、USART以及中断初始化结构体
	GPIO_InitTypeDef GPIO_InitStructure;
	USART_InitTypeDef USART_InitStructure;
	NVIC_InitTypeDef NVIC_InitStructure;
	
	//使能GPIOA和USART2的时钟
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA, ENABLE);
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_USART2, ENABLE);
	
	//PA2作为串口2的TX，PA3作为串口2的RX
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_3;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN_FLOATING;   //浮空输入模式
  GPIO_Init(GPIOA, &GPIO_InitStructure);

  GPIO_InitStructure.GPIO_Pin = GPIO_Pin_2;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF_PP;         //复用推挽输出模式
  GPIO_Init(GPIOA, &GPIO_InitStructure);
	
	//中断配置
	NVIC_PriorityGroupConfig(NVIC_PriorityGroup_0);     
  
  NVIC_InitStructure.NVIC_IRQChannel = USART2_IRQn;       //中断源为USART2
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 1;
  NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
  NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
  NVIC_Init(&NVIC_InitStructure);
	
	//串口设置
	USART_InitStructure.USART_BaudRate = 9600;                     //波特率
  USART_InitStructure.USART_WordLength = USART_WordLength_8b;    //数据位
  USART_InitStructure.USART_StopBits = USART_StopBits_1;         //停止位
  USART_InitStructure.USART_Parity = USART_Parity_No;            //奇偶校验
  USART_InitStructure.USART_HardwareFlowControl = USART_HardwareFlowControl_None;   //硬件流控制
  USART_InitStructure.USART_Mode = USART_Mode_Rx | USART_Mode_Tx;                   //串口模式
	USART_Init(USART2, &USART_InitStructure);
	
	USART_ITConfig(USART2, USART_IT_RXNE, ENABLE);    //使能串口2接收中断
	
	USART_Cmd(USART2, ENABLE);    //使能串口2
}

/* 串口发送一个字节函数
参数说明：
USARTx：说明要通过哪个串口发送数据
ch：要发送的一个字节的数据 */
void Usart_SendChar(USART_TypeDef* USARTx, u8 ch) {
	USART_SendData(USART2, ch);                                    //发送一个字节
	while(USART_GetFlagStatus(USART2, USART_FLAG_TXE) == RESET);   //等待发送完成
}

/* 串口发送一个字符串函数
参数说明：
USARTx：说明要通过哪个串口发送数据
str：要发送的字符串 */
void Usart_SendString(USART_TypeDef* USARTx, char* str) {
	do { 
		Usart_SendChar(USARTx, *str++);                               //依次发送字符串的每个字节，直到碰到字符串结束符
	}while(*str != '\0');
	while(USART_GetFlagStatus(USART2, USART_FLAG_TC) == RESET);     //等待发送完成
}

/* 重定向 */
int fputc(int ch, FILE *f) {
	USART_SendData(USART2, (u8)ch);
	while(USART_GetFlagStatus(USART2, USART_FLAG_TC) == RESET);
	return ch;
}

int fgetc(FILE *f) {
	while(USART_GetFlagStatus(USART2, USART_FLAG_RXNE) == RESET);
	return (int)USART_ReceiveData(USART2);
}

