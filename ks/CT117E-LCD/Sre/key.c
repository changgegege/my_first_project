#include "key.h"

/* �����ĳ�ʼ�� */
void KEY_Init(void) {
	//����GPIO��ʼ���ṹ��
	GPIO_InitTypeDef GPIO_InitStructure;
	
	//����GPIOA��GPIOB��ʱ��
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA | RCC_APB2Periph_GPIOB, ENABLE);
	
	//����GPIO�����Լ���ʼ��GPIO����Ϊ�����Ļ�����Ϊ��������ģʽ
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0 | GPIO_Pin_8;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IPU;
  GPIO_Init(GPIOA, &GPIO_InitStructure);
	
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_1 | GPIO_Pin_2;
	GPIO_Init(GPIOB, &GPIO_InitStructure);
}

//�������ȫ�ֱ���
u8 keyscan_count = 20;      //����������20ms
u8 keyscan_flag = 0;        //20ms��ʱ��ɺ󣬸ñ�־λ��1
u8 b2_count_dht11 = 0;      //�ж�Ҫ�޸���ʪ�ȵ��ĸ���ֵ���� 1�޸�����£�2�޸������
u8 b2_count_adc = 0;        //�ж�Ҫ�޸�ˮλ���ĸ���ֵ����   1�޸���ֵ1,2�޸���ֵ2,3�޸���ֵ3
u8 b1_flag = 0;             //�����־��0ʱ��dht11���ݽ��棬1ʱ��dht11�������棬2ʱ��ˮλ���ݽ��棬3ʱ��ˮλ��������

double max_T = 30.0, min_T = 20.0;       //��ʪ����ֵ�趨������º������
double tmp_max = 30.0, tmp_min = 20.0;   //���û��ڽ�����ͨ������������ֵʱ�����ø���ʱ�������棬�ڽ����л�ʱ�ж��޸ĺ����ֵ�Ƿ����

/* ����ɨ�躯����ʵ���ж��Ƿ��а������£��Լ�ʵ�ְ�������
������ƣ�ʵ���˰������������һ�ΰ��¶�δ��������
���������ܽ��ܣ�
KEY1�������л�     KEY2��ѡ��Ҫ�޸ĵ���ֵ
KEY3����ֵ����     KEY4����ֵ���� */
void KEY_Scan(void) {
	static u8 keydownflag = 0;     //�жϵ�ǰ�Ƿ��а�������  0�����ʱû�а������£�1�����ʱ�а�������
	
	//���а�������
	if((KEY1 == 0 || KEY2 == 0 || KEY3 == 0 || KEY4 == 0) && keydownflag == 0) {
		keydownflag = 1;      //��־λ��1��˵����ʱ�а�������
		keyscan_count = 20;   //׼������������Ϊ��Ӱ����������ִ�У�ʹ��һ������ֵ�����Ҹü���ֵ��TIM2ÿ����һ���ж�ʱ��1��������0ʱʵ����ʱ20ms������
		
		if(keyscan_flag) {    //����ʱ�������
			keyscan_flag = 0;   //��־λ��0
			
			//����1����
			if(KEY1 == 0) {
				b1_flag++;        //�����־λ��1�������л�����һ������
				
				//�˲��ֺ���ʵ������ǰ���ڽ���2����dht11�������棬��Ҫ�л�����ʱ�ж��޸ĺ����ֵ�Ƿ����
				if(b1_flag == 2) {
					if(tmp_min >= tmp_max) {         //�������С������£�����������
						tmp_max = max_T;               //����ʱ������ֵ��ֵΪ����һ�κ�����¶���ֵ
						tmp_min = min_T;
						LED_Control(LED3, 0);          //����������LED3����
					}
					else {
						max_T = tmp_max;               //�����������¶���ֵ����Ϊ��ʱ������ֵ
						min_T = tmp_min;
						
						_24c02_Write_Temperature();    //���޸ĺ����ֵд�뵽EEPROM��
						LED_Control(LED3, 1);          //��������LED3Ϩ��
					}
				}
				
				//�˲��ֺ���ʵ������ʱ���ڽ���4����ˮλ�������棬��Ҫ�л�����ʱ�ж��޸ĺ����ֵ�Ƿ����
				if(b1_flag == 4) {
					//��ֵ������
					if(tmp_threshold1 >= tmp_threshold2 || tmp_threshold2 >= tmp_threshold3) {
						tmp_threshold1 = threshold1;              //��ʱ������ֵ��ֵΪ����һ�κ������ֵ
						tmp_threshold2 = threshold2;
						tmp_threshold3 = threshold3;
						LED_Control(LED4, 0);                     //����������LED4����
					}
					else {
						//��ֵ�ɹ��޸ĺ�ˮλ����ʱ������
						if(threshold1 != tmp_threshold1 || threshold2 != tmp_threshold2 || threshold3 != tmp_threshold3) {
							time = 0;          
						}
						
						threshold1 = tmp_threshold1;          //������������ֵ����Ϊ��ʱ������ֵ
						threshold2 = tmp_threshold2;
						threshold3 = tmp_threshold3;
						
						_24c02_Write_Threshold();             //���޸ĺ����ֵд�뵽EEPROM��
						LED_Control(LED4, 1);                 //��������LED4Ϩ��
					}
				}
				
				//�������ֻ��4�����棬���Ե�b1_flag��ֵΪ4ʱ��Ҫ�л�����һ������ʵ��ѭ��
				if(b1_flag > 3) {
					b1_flag = 0;
				}
				
				//ÿ�ν����л���Ҫ�޸ĵ���ֵ���жϱ�־λ����
				b2_count_adc = 0;
				b2_count_dht11 = 0;
			}
			
			//����2���£�����ֻ���ڲ���������Ч
			else if(KEY2 == 0 && (b1_flag == 1 || b1_flag == 3)) {
				if(b1_flag == 1) {          //dht11��������
					b2_count_dht11++;         //������º�����¿�ѡ��ÿ����һ�ΰ���2�����л�Ҫ�޸�����»�������£����޸ĵ���ֵ���ֲ��ָ�����ʾ
					if(b2_count_dht11 > 2) {
						b2_count_dht11 = 1;
					}
				}
				else if(b1_flag == 3) {     //ˮλ��������
					b2_count_adc++;           //��ֵ1����ֵ2����ֵ3��ѡ
					if(b2_count_adc > 3) {
						b2_count_adc = 1;
					}
				}
			}
			
			//����3���£�����ֻ�ڲ���������Ч
			else if(KEY3 == 0 && (b1_flag == 1 || b1_flag == 3)) {
				if(b1_flag == 1) {            //dht11��������
					switch(b2_count_dht11) {
						case 1:                   //����¼�0.1
							tmp_max += 0.1;
							break;
						case 2:                   //����¼�0.1
							tmp_min += 0.1; 
							break;
						default:
							break;
					}
				}
				else if(b1_flag == 3) {       //ˮλ��������
					switch(b2_count_adc) {
						case 1:                   //��ֵ1��10
							if(tmp_threshold1 < 390)
								tmp_threshold1 += 10;
							break;
						case 2:                   //��ֵ2��10
							if(tmp_threshold2 < 390)
								tmp_threshold2 += 10;
							break;
						case 3:                   //��ֵ3��10
							if(tmp_threshold3 < 390)
								tmp_threshold3 += 10;
							break;
						default:
							break;
					}
				}
			}
			
			//����4���£�����ֻ�ڲ���������Ч
			else if(KEY4 == 0 && (b1_flag == 1 || b1_flag == 3)) {
				if(b1_flag == 1) {            //dht11��������
					switch(b2_count_dht11) {
						case 1:                   //����¼�0.1
							tmp_max -= 0.1;
							break;
						case 2:                   //����¼�0.1
							tmp_min -= 0.1;
							break;
						default:
							break;
					}
				}
				else if(b1_flag == 3) {       //ˮλ��������
					switch(b2_count_adc) {
						case 1:                   //��ֵ1��10
							if(tmp_threshold1 > 10)
								tmp_threshold1 -= 10;
							break;
						case 2:                   //��ֵ2��10
							if(tmp_threshold2 > 10)
								tmp_threshold2 -= 10;
							break;
						case 3:                   //��ֵ3��10
							if(tmp_threshold3 > 10)
								tmp_threshold3 -= 10;
							break;
						default:
							break;
					}
				}
			}
		}
	}
	
	//�ް�������ʱ
	else if(KEY1 == 1 && KEY2 == 1 && KEY3 == 1 && KEY4 == 1 && keydownflag == 1) {
		keydownflag = 0;
	}
}

u8 print_str[5][20] = {0};    //�洢Ҫ��ʾ��LCD�ϵ��ַ���
u8 dht11_rece_flag = 2;       //dht11�Ƿ�ɼ������ݵı�־λ

/*�˵���ʾ������ʵ�ָ�������LCD���ַ�������ʾ�Լ�����ָʾ��*/
void KEY_Menu(void) {
	u8 days, hours, mintues, seconds;      //����ˮλ����ʱ���������Сʱ�����������Լ�����
	
	//����¶ȸ�������»��ߵ�������±�����LED1����
	if(biubiu_flag == 1 || biubiu_flag == 2) {
		LED_Control(LED1, 0);
	}
	else {
		LED_Control(LED1, 1);
	}
	
	//���ˮλ�ȼ����ڻ����2������LED2����
	if(level >= 2) {
		LED_Control(LED2, 0);
	}
	else {
		LED_Control(LED2, 1);
	}
	
	//����b1_flag��ֵ�жϵ�ǰҪ��ʾ�ĸ������Լ����Ӧ���ַ���
	switch(b1_flag) {
		case 0:                //dht11���ݽ���
			//���δ�ɼ������ݻ�δ���ɼ�ʱ�䵫��һ��δ�ɼ������ݣ����ڲɼ�ʧ�ܽ��棩
			if(dht11_rece_flag == 0 || (dht11_rece_flag == 2 && dht11_getdata_flag == 0)){     //�Ľ������Զ���ת����������Լ������ת����
				sprintf((char*)print_str[0], "     DHT11_Data      ");
				sprintf((char*)print_str[1], "   FAIL!!!           ");
				sprintf((char*)print_str[2], "                     ");
				sprintf((char*)print_str[3], "                     ");
				sprintf((char*)print_str[4], "                     ");
			}
			//����ɼ������ݻ�δ���ɼ�ʱ�䵫��һ�βɼ��������ݣ�������һ�βɼ�����������Ļ����ʾ
			else if(dht11_rece_flag == 1 || (dht11_rece_flag == 2 && dht11_getdata_flag == 1)) {
				dht11_getdata_flag = 1;        //�޸ĸñ�־λΪ�ɼ��������ݣ���һ��δ���ɼ�ʱ��ʱ������ת��fail����
				
				sprintf((char*)print_str[0], "     DHT11_Data      ");
				sprintf((char*)print_str[1], "   T:%.1lf C         ",Temperature);
				sprintf((char*)print_str[2], "   H:%.1lf %cRH      ",Humidity,'%');
				sprintf((char*)print_str[3], "                     ");
				sprintf((char*)print_str[4], "                     ");
			}
			break;
		case 1:         //dht11��������
			sprintf((char*)print_str[0], "     DHT11_Para      ");
			sprintf((char*)print_str[1], "   TMAX:%.1lf C      ",tmp_max);
			sprintf((char*)print_str[2], "   TMIN:%.1lf C      ",tmp_min);
			sprintf((char*)print_str[3], "                     ");
			sprintf((char*)print_str[4], "                     ");
			break;
		case 2:         //ˮλ���ݽ���
			days = time / (3600*24);           //time�д洢��������������ת��Ϊ��Ӧ��xx:xx:xx:xx����ʽ��ʾ
			hours = time % (3600*24) /3600;
			mintues = time % (3600*24) % 3600 /60;
			seconds = time % (3600*24) %3600 % 60;
		
			sprintf((char*)print_str[0], "      ADC_Data       ");
			sprintf((char*)print_str[1], "   V:%.2lfV          ",voltage_val);
			sprintf((char*)print_str[2], "   H:%dcm            ",high_val);
			sprintf((char*)print_str[3], "   Level:%d          ",level);	
			sprintf((char*)print_str[4], "   TIME:%02d:%02d:%02d:%02d   ",days,hours,mintues,seconds);
			break;
		case 3:         //ˮλ��������
			sprintf((char*)print_str[0], "      ADC_Para       ");
			sprintf((char*)print_str[1], "   Level1:%dcm       ",tmp_threshold1);
			sprintf((char*)print_str[2], "   Level2:%dcm       ",tmp_threshold2);
			sprintf((char*)print_str[3], "   Level3:%dcm       ",tmp_threshold3);
			sprintf((char*)print_str[4], "                     ");
			break;
	}
	
	LCD_SetTextColor(White);                              //������ɫ����Ϊ��ɫ
	LCD_DisplayStringLine(Line1, (u8 *)print_str[0]);     //��ӡ��һ�е��ַ���
	
	//����ǰ��dht11��������
	if(b1_flag == 1) {
		//����b2_count_dht11��ֵ������ʾĳһ��ֵ��������޸�
		if(b2_count_dht11 == 1)
			LCD_SetTextColor(Green);   
		else
			LCD_SetTextColor(White);
		LCD_DisplayStringLine(Line3, (u8 *)print_str[1]);
				
		if(b2_count_dht11 == 2)
			LCD_SetTextColor(Green);
		else
			LCD_SetTextColor(White);
		LCD_DisplayStringLine(Line5, (u8 *)print_str[2]);
	}
	
	//����ǰ��ˮλ��������
	else if(b1_flag == 3) {
		//����b2_count_adc��ֵ������ʾĳһ��ֵ��������޸�
		if(b2_count_adc == 1)       
			LCD_SetTextColor(Green);
		else
			LCD_SetTextColor(White);
		LCD_DisplayStringLine(Line3, (u8 *)print_str[1]);
				
		if(b2_count_adc == 2)
			LCD_SetTextColor(Green);
		else
			LCD_SetTextColor(White);
		LCD_DisplayStringLine(Line5, (u8 *)print_str[2]);
				
		if(b2_count_adc == 3)
			LCD_SetTextColor(Green);
		else
			LCD_SetTextColor(White);
		LCD_DisplayStringLine(Line7, (u8 *)print_str[3]);
	}
	
	//����ǰ�����ݽ��棬������ʾ����
	else {
		LCD_DisplayStringLine(Line3, (u8 *)print_str[1]);
		LCD_DisplayStringLine(Line5, (u8 *)print_str[2]);
		LCD_DisplayStringLine(Line7, (u8 *)print_str[3]);
	}
		

	LCD_DisplayStringLine(Line9, (u8 *)print_str[4]);    //ֻ��ˮλ���ݽ����о�������
}

