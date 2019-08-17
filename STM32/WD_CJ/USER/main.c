#include "led.h"
#include "delay.h"
#include "sys.h"
#include "key.h"
#include "usart.h"
#include "lcd.h"
#include "spi.h"
#include "flash.h"
#include "24l01.h"
#include "ds18b20.h"
#include "data_transfer.h"



short temp = 0; 



void Check_bsp(){
		
	while(NRF24L01_Check())//���NRF
		{
			LCD_ShowString(60,110,"NRF Check Failed!");
			delay_ms(500);		  
			LCD_ShowString(60,110,"Please Check!        ");
			delay_ms(500);
			LED0=!LED0;//DS0��˸
		}
		LCD_ShowString(60,110,"NRF Ready!     ");	 
		POINT_COLOR=RED;//��������Ϊ��ɫ	   
			
		RX_Mode();
		//TX_Mode(); 
		//NRF_Mode(MODEL_TX2,40);

		while(DS18B20_Init())//��ʼ��DS18B20,����18B20
		{
			LCD_ShowString(60,130,"DS18B20 Check Failed!");
			delay_ms(500);		  
			LCD_ShowString(60,130,"Please Check!        ");
			delay_ms(500);
			LED0=!LED0;//DS0��˸
		}
		LCD_ShowString(60,130,"DS18B20 Ready!     ");	 
		POINT_COLOR=BLUE;//��������Ϊ��ɫ	   
		LCD_ShowString(60,150, "Temperate:   . C");	 

}

void Init(){

	SystemInit(); //ϵͳʱ������
	delay_init(72);	     //��ʱ��ʼ��
	NVIC_Configuration();
 	uart_init(9600);//����1��ʼ�� 
 	LED_Init();//LED��ʼ��
//	KEY_Init();
	NRF24L01_Init();
	//NRF_Mode(MODEL_TX,40);
	
	
	
	LCD_Init();//��ʼ��Һ�� 
	
	POINT_COLOR=RED;//��������Ϊ��ɫ	   
	LCD_ShowString(60,50,"Mini STM32");	
	LCD_ShowString(60,70,"WD_NRF ");	

	LCD_ShowString(60,90,"2014/1/1");

}

void Display_Temp(){

		
		if(temp<0)
		{
			temp=-temp;
			LCD_ShowChar(140,150,'-',16,0);//��ʾ����	
		}						 
		LCD_ShowNum(148,150,temp/10,2,16);//��ʾ�¶�ֵ	  
		LCD_ShowNum(172,150,temp%10,1,16);//��ʾ�¶�ֵ
		//printf("t1:%d\n",temp);
		delay_ms(200);
		LED0=!LED0;

}


int main(void)
{  	
	
	/**/
	Init();
  
	Check_bsp();
	
	while(1)
	{	 
	
		temp=DS18B20_Get_Temp();
		
		//Send_Temp();
		NRF_Check_Event();
	
		Display_Temp();	
		
	}	
}

