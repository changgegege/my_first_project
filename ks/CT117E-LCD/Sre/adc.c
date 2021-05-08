#include "adc.h"

/* ADC1的初始化 */
void Adc_Init(void) {
	//定义GPIO和ADC的初始化结构体
	GPIO_InitTypeDef GPIO_InitStructure;
	ADC_InitTypeDef ADC_InitStructure;
	
	//设置ADC时钟
	RCC_ADCCLKConfig(RCC_PCLK2_Div4);
	//开启GPIOB和ADC1的时钟
  RCC_APB2PeriphClockCmd(RCC_APB2Periph_ADC1 | RCC_APB2Periph_GPIOB, ENABLE);
	
	//配置GPIOB参数及初始化GPIOB  注：PB0用于接收板子上电位器的数据
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0; 
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AIN;             //模拟输入模式
  GPIO_Init(GPIOB, &GPIO_InitStructure);
	
	//配置ADC1参数及初始化ADC1
	ADC_InitStructure.ADC_Mode = ADC_Mode_Independent;        //独立模式
  ADC_InitStructure.ADC_ScanConvMode = DISABLE;             //不使用连续扫描
  ADC_InitStructure.ADC_ContinuousConvMode = DISABLE;       //不使用连续采样
  ADC_InitStructure.ADC_ExternalTrigConv = ADC_ExternalTrigConv_None;      //不使用外部触发，即使用软件触发
  ADC_InitStructure.ADC_DataAlign = ADC_DataAlign_Right;    //数据右对齐  
  ADC_InitStructure.ADC_NbrOfChannel = 1;                   //通道数为1
  ADC_Init(ADC1, &ADC_InitStructure); 
	
	//规则通道配置为ADC1的通道8，通道数为1，配置采样时间
	ADC_RegularChannelConfig(ADC1,ADC_Channel_8,1,ADC_SampleTime_55Cycles5);    
  
  //使能ADC1
	ADC_Cmd(ADC1, ENABLE);
	
	//ADC复位
  ADC_ResetCalibration(ADC1);  
  while(ADC_GetResetCalibrationStatus(ADC1));

  //ADC校准
	ADC_StartCalibration(ADC1);   
  while(ADC_GetCalibrationStatus(ADC1));
}

/* ADC数据采样函数 */
u16 Adc_Get_Val(void) {
	u16 tmp;  
	ADC_SoftwareStartConvCmd(ADC1, ENABLE);                     //使能ADC软件触发
	while(ADC_GetFlagStatus(ADC1, ADC_FLAG_EOC) == RESET);      //等待采样完成
	tmp = ADC_GetConversionValue(ADC1);                        //将采集的数据保存在tmp临时变量中
	ADC_SoftwareStartConvCmd(ADC1, DISABLE);                    //禁止ADC软件触发
	
	return tmp;
}

/* ADC采样中值函数（滤波） */
u16 Adc_Get_Val_ave(void) {
	u32 tmp = 0;
	u8 i;
	for(i=0;i<10;i++) {         //取十次的采样值进行平均值计算
		tmp += Adc_Get_Val();
	}
	tmp = tmp / 10;
	
	return tmp;                 //返回十次采样平均值结果
}

u16 adc_val;                    //ADC采样获取的值，由于该ADC是12位ADC，所以采样转化为数字信号可分为0-4095份，每份占3.3V的1/4096
double voltage_val;             //转换后得到的电压值
u16 voltage_val_count = 1000;   //ADC采样延时毫秒数，1s采集一次ADC数据
u8 voltage_val_flag = 0;        //ADC采样标志
u16 high_val = 0;               //由电压值转化到的模拟水位

u16 threshold1 = 100, threshold2 = 200, threshold3 = 300;                 //水位阈值1,2,3
u16 tmp_threshold1 = 100, tmp_threshold2 = 200, tmp_threshold3 = 300;     //临时水位阈值1,2,3
u8 level = 0, tmp_level = 0;    //当前水位等级及临时水位等级，临时水位等级的存在是为了判断是否有水位等级的变化
u32 time = 0;                   //水位持续时间

/* ADC采集及水位和水位等级的确定函数
水位等级的确定：
当前水位小于或等于阈值1，等级为0；当前水位大于阈值1，小于或等于阈值2，等级为1；
当前水位大于阈值2，小于或等于阈值3，等级为2；当前水位大于阈值3，等级为3 */
void Adc_Get_Voltage_Val(void) {
	if(voltage_val_flag) {                            //若达到ADC采集时间间隔则采集数据
		voltage_val_flag = 0;                           //标志位清零
		voltage_val_count = 1000;                       //重新设置延时毫秒数，准备下一次的数据采集
		adc_val = Adc_Get_Val();                        //得到ADC采集的值
		voltage_val = (double)adc_val / 4095 * 3.3;     //将ADC采集得到的值转换为相应的电压值
		high_val = voltage_val * (400 / 3.3);           //将相应的电压值转化为模拟水位值，最高水位4米
		
		//获取当前水位等级
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
		
		//若最新获取的水位等级与前水位等级不相符，水位持续时间清零，重新开始计时
		if(tmp_level != level) {
			time = 0;
		}
		else {
			time++;
		}
		
		//将临时水位等级赋值给水位等级变量，并且最新获取的水位等级写入EEPROM
		level = tmp_level;
		_24c02_Write_Time_Level();
	}
}


