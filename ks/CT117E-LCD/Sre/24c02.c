#include "24c02.h"

/* ��EEPROM��д�����ݵĺ���
�������ܣ�
address��Ҫд��ĵ�ַ
data��Ҫд�������
ָ����ܣ�
0x0aָ�����д������ */
void _24c02_Write(u8 address, u8 data) {
	I2CStart();               //I2C��������
	I2CSendByte(0xa0);        //Ҫд�����ݵ�����
	I2CWaitAck();             //�ȴ�Ӧ��
	I2CSendByte(address);     //����Ҫд��ĵ�ַ
	I2CWaitAck();
	I2CSendByte(data);        //����Ҫд�������
	I2CWaitAck();
	I2CStop();                //I2C����ֹͣ
}

/* ��EEPROM�ж�ȡ���ݵĺ���
�������ܣ�
address��Ҫ��ȡ���ݵĵ�ַ
ָ����ܣ�
0x0aָ�����д�����ݣ�0xa1ָ������ȡ���� */
u8 _24c02_Read(u8 address) {
	u8 tmp;                   //��ʱ���������ڴ洢��ȡ������
	
	I2CStart();               //I2C���߿���
	I2CSendByte(0xa0);        //д�����ݵ�ָ��
	I2CWaitAck();
	I2CSendByte(address);     //д��Ҫ��ȡ���ݵĵ�ַ
	I2CWaitAck();
	
	I2CStart();               //Ҫ������������
	I2CSendByte(0xa1);        //��ȡ���ݵ�ָ��
	I2CWaitAck();
	tmp = I2CReceiveByte();   //��ȡ���ݲ����浽��ʱ������
	I2CWaitAck();
	I2CStop();                //I2C����ֹͣ
	
	return tmp;
}

/* ����ǰ��ʪ����ֵ�洢��EEPROM
0x01�洢������������֣�0x02�洢�����С�����֣�0x03�洢������������֣�0x04�洢�����С������ */
void _24c02_Write_Temperature(void) {
		u16 tmp;
	
		//�洢�����
		tmp = max_T*100;               //�������100�����ܻ����С�����ֲ�0.1�����
		_24c02_Write(0x01, tmp / 100);
		Systick_Delay_Ms(5);           //����д��������Ҫ���ѽ϶�ʱ�䣬��ʱ�ɱ�֤���ݿ�������д��
		_24c02_Write(0x02, tmp % 100);
		Systick_Delay_Ms(5);
	
		//�洢�����
		tmp = min_T*100;
		_24c02_Write(0x03, tmp / 100);
		Systick_Delay_Ms(5);
		_24c02_Write(0x04, tmp % 100);
		Systick_Delay_Ms(5);
}

/* ����ǰˮλ��ֵ�洢��EEPROM
0x05��0x06���ڴ洢��ֵ1���ݣ�0x07��0x08���ڴ洢��ֵ2���ݣ�0x09��0x0a���ڴ洢��ֵ3���� */
void _24c02_Write_Threshold(void) {      //400����u8�����ƣ�Ҫ�������洢��Ԫʵ��
		//�洢��ֵ1
		_24c02_Write(0x05, threshold1 / 10);
		Systick_Delay_Ms(5);
		_24c02_Write(0x06, threshold1 % 10);
		Systick_Delay_Ms(5);
	
		//�洢��ֵ2
		_24c02_Write(0x07, threshold2 / 10);
		Systick_Delay_Ms(5);
		_24c02_Write(0x08, threshold2 % 10);
		Systick_Delay_Ms(5);
		
		//�洢��ֵ3
		_24c02_Write(0x09, threshold3 / 10);
		Systick_Delay_Ms(5);
		_24c02_Write(0x0a, threshold3 % 10);
		Systick_Delay_Ms(5);
}

/* ����ǰˮλ����ʱ���Լ�ˮλ�ȼ��洢��EEPROM
0x0b��0x0c��0x0d�Լ�0x0e�洢ˮλ����ʱ�䣬0x0f�洢��ǰˮλ�ȼ�
˵�����洢ˮλ�ȼ���Ϊ�˱�֤����ÿ��һ�ϵ磬ˮλ����ʱ�䶼�ٴδ�0��ʼ��ʱ */
void _24c02_Write_Time_Level(void) {
		_24c02_Write(0x0b, time / (3600*24));
		Systick_Delay_Ms(5);
		_24c02_Write(0x0c, time % (3600*24) / 3600);
		Systick_Delay_Ms(5);
		_24c02_Write(0x0d, time % (3600*24) % 3600 / 60);
		Systick_Delay_Ms(5);
		_24c02_Write(0x0e, time % (3600*24) % 3600 % 60);
		Systick_Delay_Ms(5);
	
		_24c02_Write(0x0f, level);
		Systick_Delay_Ms(5);
}

/* ��ȡ�洢��EEPROM�е���ʪ�ȼ�ˮλ��ֵ���� */
void _24c02_Read_Temprature_Threshold(void) {
	u8 tmp1,tmp2;
	
	//�����
	tmp1 = _24c02_Read(0x01);
	Systick_Delay_Ms(5);
	tmp2 = _24c02_Read(0x02);
	Systick_Delay_Ms(5);
	max_T = tmp_max = (tmp1*100 + tmp2) / 100.0;
	
	//�����
	tmp1 = _24c02_Read(0x03);
	Systick_Delay_Ms(5);
	tmp2 = _24c02_Read(0x04);
	Systick_Delay_Ms(5);
	min_T = tmp_min = (tmp1*100 + tmp2) / 100.0;
	
	//��ֵ1
	tmp1 = _24c02_Read(0x05);
	Systick_Delay_Ms(5);
	tmp2 = _24c02_Read(0x06);
	Systick_Delay_Ms(5);
	threshold1 = tmp_threshold1 = tmp1*10 + tmp2;
	
	//��ֵ2
	tmp1 = _24c02_Read(0x07);
	Systick_Delay_Ms(5);
	tmp2 = _24c02_Read(0x08);
	Systick_Delay_Ms(5);
	threshold2 = tmp_threshold2 = tmp1*10 + tmp2;
	
	//��ֵ3
	tmp1 = _24c02_Read(0x09);
	Systick_Delay_Ms(5);
	tmp2 = _24c02_Read(0x0a);
	Systick_Delay_Ms(5);
	threshold3 = tmp_threshold3 = tmp1*10 + tmp2;
}

/* ��ȡ�洢��EEPROM�е�ˮλ����ʱ���ˮλ�ȼ����� */
void _24c02_Read_Time_Level(void) {
	u8 d,h,m,s,tmp_level;
	
	d = _24c02_Read(0x0b);
	Systick_Delay_Ms(5);
	h = _24c02_Read(0x0c);
	Systick_Delay_Ms(5);	
	m = _24c02_Read(0x0d);
	Systick_Delay_Ms(5);
	s = _24c02_Read(0x0e);
	Systick_Delay_Ms(5);
	tmp_level = _24c02_Read(0x0f);
	Systick_Delay_Ms(5);
	
	time = d * (3600*24) + h * 3600 + m * 60 + s;
	level = tmp_level;
}

