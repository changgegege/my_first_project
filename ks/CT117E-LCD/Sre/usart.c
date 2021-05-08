#include "usart.h"

/* ����2�ĳ�ʼ�� */
void Usart_Init(void) {
	//����GPIO��USART�Լ��жϳ�ʼ���ṹ��
	GPIO_InitTypeDef GPIO_InitStructure;
	USART_InitTypeDef USART_InitStructure;
	NVIC_InitTypeDef NVIC_InitStructure;
	
	//ʹ��GPIOA��USART2��ʱ��
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA, ENABLE);
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_USART2, ENABLE);
	
	//PA2��Ϊ����2��TX��PA3��Ϊ����2��RX
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_3;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN_FLOATING;   //��������ģʽ
  GPIO_Init(GPIOA, &GPIO_InitStructure);

  GPIO_InitStructure.GPIO_Pin = GPIO_Pin_2;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF_PP;         //�����������ģʽ
  GPIO_Init(GPIOA, &GPIO_InitStructure);
	
	//�ж�����
	NVIC_PriorityGroupConfig(NVIC_PriorityGroup_0);     
  
  NVIC_InitStructure.NVIC_IRQChannel = USART2_IRQn;       //�ж�ԴΪUSART2
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 1;
  NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
  NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
  NVIC_Init(&NVIC_InitStructure);
	
	//��������
	USART_InitStructure.USART_BaudRate = 9600;                     //������
  USART_InitStructure.USART_WordLength = USART_WordLength_8b;    //����λ
  USART_InitStructure.USART_StopBits = USART_StopBits_1;         //ֹͣλ
  USART_InitStructure.USART_Parity = USART_Parity_No;            //��żУ��
  USART_InitStructure.USART_HardwareFlowControl = USART_HardwareFlowControl_None;   //Ӳ��������
  USART_InitStructure.USART_Mode = USART_Mode_Rx | USART_Mode_Tx;                   //����ģʽ
	USART_Init(USART2, &USART_InitStructure);
	
	USART_ITConfig(USART2, USART_IT_RXNE, ENABLE);    //ʹ�ܴ���2�����ж�
	
	USART_Cmd(USART2, ENABLE);    //ʹ�ܴ���2
}

/* ���ڷ���һ���ֽں���
����˵����
USARTx��˵��Ҫͨ���ĸ����ڷ�������
ch��Ҫ���͵�һ���ֽڵ����� */
void Usart_SendChar(USART_TypeDef* USARTx, u8 ch) {
	USART_SendData(USART2, ch);                                    //����һ���ֽ�
	while(USART_GetFlagStatus(USART2, USART_FLAG_TXE) == RESET);   //�ȴ��������
}

/* ���ڷ���һ���ַ�������
����˵����
USARTx��˵��Ҫͨ���ĸ����ڷ�������
str��Ҫ���͵��ַ��� */
void Usart_SendString(USART_TypeDef* USARTx, char* str) {
	do { 
		Usart_SendChar(USARTx, *str++);                               //���η����ַ�����ÿ���ֽڣ�ֱ�������ַ���������
	}while(*str != '\0');
	while(USART_GetFlagStatus(USART2, USART_FLAG_TC) == RESET);     //�ȴ��������
}

/* �ض��� */
int fputc(int ch, FILE *f) {
	USART_SendData(USART2, (u8)ch);
	while(USART_GetFlagStatus(USART2, USART_FLAG_TC) == RESET);
	return ch;
}

int fgetc(FILE *f) {
	while(USART_GetFlagStatus(USART2, USART_FLAG_RXNE) == RESET);
	return (int)USART_ReceiveData(USART2);
}

