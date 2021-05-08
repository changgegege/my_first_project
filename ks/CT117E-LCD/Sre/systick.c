#include "systick.h"

/* Systick参数配置函数：修改不使能中断 */
uint32_t SysTick_Config_H(uint32_t ticks)
{
	if ((ticks - 1UL) > SysTick_LOAD_RELOAD_Msk) return 1UL; 

  SysTick->LOAD  = (uint32_t)(ticks - 1UL);                        
  NVIC_SetPriority (SysTick_IRQn, (1UL << __NVIC_PRIO_BITS) - 1UL); 
  SysTick->VAL   = 0UL;      
  SysTick->CTRL &= ~SysTick_CTRL_CLKSOURCE_Msk;	
	SysTick->CTRL &= ~SysTick_CTRL_TICKINT_Msk;
  SysTick->CTRL = SysTick_CTRL_ENABLE_Msk;    
	
  return 0UL;                                                  
}

/*毫秒级别延时函数*/
void Systick_Delay_Ms(uint32_t time)
{
	u32 i;
	SysTick_Config_H(SystemCoreClock/8/1000);
	
	for(i=0;i<time;i++)
		while(!((SysTick->CTRL) & (1<<16)));    //如果计数器还没到0就空转
}

/*微秒级别延时函数*/
void Systick_Delay_Us(uint32_t time)
{
	u32 i;
	SysTick_Config_H(SystemCoreClock/8/1000000);
	
	for(i=0;i<time;i++)
		while(!((SysTick->CTRL) & (1<<16)));    //如果计数器还没到0就空转
}
