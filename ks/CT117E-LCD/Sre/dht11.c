#include "dht11.h"

//����ȫ�ֱ������û��洢��ʪ������
double Humidity = 0, Temperature = 0;

/* ��ʼ��DHT11��DATA���� */
void DHT11_Init(void)
{
	//����GPIO��ʼ���ṹ��
	GPIO_InitTypeDef GPIO_InitStructure;

	//ʹ��GPIOAʱ��
	RCC_APB2PeriphClockCmd(DHT11_CLOCK, ENABLE);
	
	//GPIOA��������
	GPIO_InitStructure.GPIO_Pin = DHT11_PIN;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;   //�������ģʽ
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;	
	GPIO_Init(DHT11_PORT, &GPIO_InitStructure);
}

/* DHT11��DATA���ŵ���������ģʽ */
void DHT11_Mode_IN(void)
{
	GPIO_InitTypeDef GPIO_InitStructure;
	
	GPIO_InitStructure.GPIO_Pin = DHT11_PIN;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IPU;       //��������ģʽ
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(DHT11_PORT, &GPIO_InitStructure);
}

/* DHT11��DATA���ŵ��������ģʽ */
void DHT11_Mode_Out(void)
{	
	GPIO_InitTypeDef GPIO_InitStructure;
	
	GPIO_InitStructure.GPIO_Pin = DHT11_PIN;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;    //�������ģʽ
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(DHT11_PORT, &GPIO_InitStructure);
}

/* ��ȡһ���ֽڵ����� 
dht11һ���Է���40λ���ݣ���λ�ȳ� */
u8 DHT11_ReadBytes(void)
{
	u8 data = 0, i;
	
	for(i=0;i<8;i++)
	{
		while(DHT11_VALUE() == 0);     //ÿһλ��������54us�ĵ͵�ƽ�ź�
		
		Systick_Delay_Us(50);
		
		if(DHT11_VALUE() == 1)         //��ʱ50us���Ǹߵ�ƽ�Ļ�˵����λΪ�ߵ�ƽ
		{
			while(DHT11_VALUE() == 1);   //�ȴ���λ�������
			data |= (u8)(0x80>>i);       //��������1��������Ӧ��λ����������0�ɲ��޸ģ���Ӱ��
		} 
	}
	return data;
}

u8 dht11_flag = 1;           //dht11���ݲɼ���־λ
u16 dht11_count = 0;         //dht11���ݲɼ�ʱ����
u8 dht11_getdata_flag = 0;   //�Ƿ�ɼ������ݵı�־  0����δ�ɼ��������� 1�������ݲɼ��ɹ�
u8 send_th_flag = 1;         //�Ƿ�ͨ�����ڷ�����ʪ��  0�����ֹ���� 1����ʹ�ܷ���
u8 biubiu_flag = 0;          //������־

/* dht11���ݲɼ�����
����ֵ��
0�������ݲɼ�ʧ�ܣ�1�������ݲɼ��ɹ���2�����ʱδ�����ݲɼ��׶� */
u8 DHT11_GetData(void) {
	u16 count = 0;                        //�ж����ݽ����Ƿ�ʧ��
	u8 H_H, H_L, C_H, C_L, Check, temp;   //����ɼ�������
	
	//��ʼ���ݽ���
	if(dht11_flag == 1) {
		dht11_flag = 0;                     //��־λ����
		dht11_count = 2000;                 //׼����һ�εĽ���
		
		//����ʼ�źţ������ ��������22ms�����ߴ�����׼������
		DHT11_Mode_Out();
		
		DHT11_LOW();
		Systick_Delay_Ms(22);
		
		DHT11_HIGH();
		Systick_Delay_Us(30);
		
		//��Ӧ�źţ����룩  ����������������83us��������87us��Ϊ��Ӧ�ź�
		DHT11_Mode_IN();
		
		if(DHT11_VALUE() == 0) {
			while(DHT11_VALUE() == 0) {
				count++;
				if(count > 1000) {             //��count�����ﵽ1000��˵����ʱ�ѳ���83us�����յ��Ĳ�����Ӧ�ź�
					dht11_getdata_flag = 0;      //���ݽ���ʧ��
					return 0;
				}
			}
			
			count = 0;
			while(DHT11_VALUE() == 1) {
				count++;
				if(count > 1000) {             //��count�����ﵽ1000��˵����ʱ�ѳ���87us�����յ��Ĳ�����Ӧ�ź�
					dht11_getdata_flag = 0;      //���ݽ���ʧ��
					return 0;
				}
			}
			
			//�������ݣ����룩 ����5�ֽ����ݣ�����Ϊʪ�ȸ��¡���λ���¶ȸ�λ����λ�Լ�У��λ
			H_H = DHT11_ReadBytes();
			H_L = DHT11_ReadBytes();
			C_H = DHT11_ReadBytes();
			C_L = DHT11_ReadBytes();
			Check = DHT11_ReadBytes();
			
			//�ɼ�������ɣ���������
			DHT11_Mode_Out();
			DHT11_HIGH();
			
			temp = H_H + H_L + C_H + C_L;      //������ʪ�ȸ�λ�͵�λ��ӽ���������������һ��8λ����ʱ�����洢�ͣ�����У��ֵ�Ƚ�
			
			//���ɼ�����������ȷ
			if(Check == temp) {
				Humidity = H_H + H_L / 10.0;     //�õ�ʪ������
				Temperature = C_H + C_L / 10.0;	 //�õ��¶�����
				dht11_getdata_flag = 1;          //���ݽ��ճɹ�����־λ��1
				
				//����ʱ�¶ȸ�������»��ߵ�������£���������
				if(Temperature > max_T || Temperature < min_T) {
					if(Temperature > max_T) {
						biubiu_flag = 1;	           //�¶ȸ������λ������ֵΪ1
					}
					else if(Temperature < min_T) {
						biubiu_flag = 2;             //�¶ȵ�������£�����ֵΪ2
					}						
				}
				else {
					biubiu_flag = 0;               //δ��������������ֵΪ0�������ʱ���Ǳ���״̬
				}
				
				//���ڷ�����ʪ�����ݱ�־λ��Чʱ���͵�ǰ��ʪ�����ݲɼ����������״̬
				if(send_th_flag == 1) {
					printf("��ȡDHT11���ݳɹ���\r\nʪ�ȣ�%.1lf ��RH,�¶ȣ�%.1lf ��,%d\r\n", Humidity, Temperature, biubiu_flag);
				}
				return 1;
			}
			else {
				if(send_th_flag == 1)
					printf("��ȡDHT11����ʧ�ܣ�\r\n");
				
				dht11_getdata_flag = 0;          //�ɼ���������У�鲻�ɹ������ݲɼ�ʧ��
				return 0;
			}
		}
		else {
			if(send_th_flag == 1)
				printf("��ȡDHT11����ʧ�ܣ�\r\n");
			dht11_getdata_flag = 0;            //δ���յ���Ӧ�źţ����ݲɼ�ʧ��
			return 0;	
		}
	}
	else    //δ���ɼ�ʱ�䣬��������2
		return 2;
}

