#include "adc.h"

/* ADC1�ĳ�ʼ�� */
void Adc_Init(void) {
	//����GPIO��ADC�ĳ�ʼ���ṹ��
	GPIO_InitTypeDef GPIO_InitStructure;
	ADC_InitTypeDef ADC_InitStructure;
	
	//����ADCʱ��
	RCC_ADCCLKConfig(RCC_PCLK2_Div4);
	//����GPIOB��ADC1��ʱ��
  RCC_APB2PeriphClockCmd(RCC_APB2Periph_ADC1 | RCC_APB2Periph_GPIOB, ENABLE);
	
	//����GPIOB��������ʼ��GPIOB  ע��PB0���ڽ��հ����ϵ�λ��������
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0; 
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AIN;             //ģ������ģʽ
  GPIO_Init(GPIOB, &GPIO_InitStructure);
	
	//����ADC1��������ʼ��ADC1
	ADC_InitStructure.ADC_Mode = ADC_Mode_Independent;        //����ģʽ
  ADC_InitStructure.ADC_ScanConvMode = DISABLE;             //��ʹ������ɨ��
  ADC_InitStructure.ADC_ContinuousConvMode = DISABLE;       //��ʹ����������
  ADC_InitStructure.ADC_ExternalTrigConv = ADC_ExternalTrigConv_None;      //��ʹ���ⲿ��������ʹ���������
  ADC_InitStructure.ADC_DataAlign = ADC_DataAlign_Right;    //�����Ҷ���  
  ADC_InitStructure.ADC_NbrOfChannel = 1;                   //ͨ����Ϊ1
  ADC_Init(ADC1, &ADC_InitStructure); 
	
	//����ͨ������ΪADC1��ͨ��8��ͨ����Ϊ1�����ò���ʱ��
	ADC_RegularChannelConfig(ADC1,ADC_Channel_8,1,ADC_SampleTime_55Cycles5);    
  
  //ʹ��ADC1
	ADC_Cmd(ADC1, ENABLE);
	
	//ADC��λ
  ADC_ResetCalibration(ADC1);  
  while(ADC_GetResetCalibrationStatus(ADC1));

  //ADCУ׼
	ADC_StartCalibration(ADC1);   
  while(ADC_GetCalibrationStatus(ADC1));
}

/* ADC���ݲ������� */
u16 Adc_Get_Val(void) {
	u16 tmp;  
	ADC_SoftwareStartConvCmd(ADC1, ENABLE);                     //ʹ��ADC�������
	while(ADC_GetFlagStatus(ADC1, ADC_FLAG_EOC) == RESET);      //�ȴ��������
	tmp = ADC_GetConversionValue(ADC1);                        //���ɼ������ݱ�����tmp��ʱ������
	ADC_SoftwareStartConvCmd(ADC1, DISABLE);                    //��ֹADC�������
	
	return tmp;
}

/* ADC������ֵ�������˲��� */
u16 Adc_Get_Val_ave(void) {
	u32 tmp = 0;
	u8 i;
	for(i=0;i<10;i++) {         //ȡʮ�εĲ���ֵ����ƽ��ֵ����
		tmp += Adc_Get_Val();
	}
	tmp = tmp / 10;
	
	return tmp;                 //����ʮ�β���ƽ��ֵ���
}

u16 adc_val;                    //ADC������ȡ��ֵ�����ڸ�ADC��12λADC�����Բ���ת��Ϊ�����źſɷ�Ϊ0-4095�ݣ�ÿ��ռ3.3V��1/4096
double voltage_val;             //ת����õ��ĵ�ѹֵ
u16 voltage_val_count = 1000;   //ADC������ʱ��������1s�ɼ�һ��ADC����
u8 voltage_val_flag = 0;        //ADC������־
u16 high_val = 0;               //�ɵ�ѹֵת������ģ��ˮλ

u16 threshold1 = 100, threshold2 = 200, threshold3 = 300;                 //ˮλ��ֵ1,2,3
u16 tmp_threshold1 = 100, tmp_threshold2 = 200, tmp_threshold3 = 300;     //��ʱˮλ��ֵ1,2,3
u8 level = 0, tmp_level = 0;    //��ǰˮλ�ȼ�����ʱˮλ�ȼ�����ʱˮλ�ȼ��Ĵ�����Ϊ���ж��Ƿ���ˮλ�ȼ��ı仯
u32 time = 0;                   //ˮλ����ʱ��

/* ADC�ɼ���ˮλ��ˮλ�ȼ���ȷ������
ˮλ�ȼ���ȷ����
��ǰˮλС�ڻ������ֵ1���ȼ�Ϊ0����ǰˮλ������ֵ1��С�ڻ������ֵ2���ȼ�Ϊ1��
��ǰˮλ������ֵ2��С�ڻ������ֵ3���ȼ�Ϊ2����ǰˮλ������ֵ3���ȼ�Ϊ3 */
void Adc_Get_Voltage_Val(void) {
	if(voltage_val_flag) {                            //���ﵽADC�ɼ�ʱ������ɼ�����
		voltage_val_flag = 0;                           //��־λ����
		voltage_val_count = 1000;                       //����������ʱ��������׼����һ�ε����ݲɼ�
		adc_val = Adc_Get_Val();                        //�õ�ADC�ɼ���ֵ
		voltage_val = (double)adc_val / 4095 * 3.3;     //��ADC�ɼ��õ���ֵת��Ϊ��Ӧ�ĵ�ѹֵ
		high_val = voltage_val * (400 / 3.3);           //����Ӧ�ĵ�ѹֵת��Ϊģ��ˮλֵ�����ˮλ4��
		
		//��ȡ��ǰˮλ�ȼ�
		if(high_val <= threshold1) {
			tmp_level = 0;
		}
		else if(high_val > threshold1 && high_val <= threshold2) {
			tmp_level = 1;
		}
		else if(high_val > threshold2 && high_val <= threshold3) {
			tmp_level = 2;
		}
		else if(high_val > threshold3) {
			tmp_level = 3;
		}
		
		//�����»�ȡ��ˮλ�ȼ���ǰˮλ�ȼ��������ˮλ����ʱ�����㣬���¿�ʼ��ʱ
		if(tmp_level != level) {
			time = 0;
		}
		else {
			time++;
		}
		
		//����ʱˮλ�ȼ���ֵ��ˮλ�ȼ��������������»�ȡ��ˮλ�ȼ�д��EEPROM
		level = tmp_level;
		_24c02_Write_Time_Level();
	}
}


