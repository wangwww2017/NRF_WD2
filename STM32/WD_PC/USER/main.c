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
				printf("NRF24L01 CHECK FAILED!\r\n");
		}
	printf("NRF24L01 CHECK OK!\r\n");
	

}

void Init(){

	SystemInit(); //ϵͳʱ������
	delay_init(72);	     //��ʱ��ʼ��
	NVIC_Configuration();
 	uart_init(9600);//����1��ʼ�� 
 	LED_Init();//LED��ʼ��
	
	NRF24L01_Init();
	//NRF_Mode(MODEL_RX,40);
	RX_Mode();
	//NRF_Mode(MODEL_RX2,40);
	delay_ms(500);
	//LCD_Init();//��ʼ��Һ�� 
	

}



int main(void)
{  	
   		   
/**/
	Init();

	Check_bsp();
	 
	 
	while(1)
	{	 
		
		NRF_Check_Event();
		Uart_CheckEvent();
		
	}	
}

