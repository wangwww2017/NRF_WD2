#include "data_transfer.h"
#include "ds18b20.h"

#define BYTE0(dwTemp)       (*(char *)(&dwTemp))
#define BYTE1(dwTemp)       (*((char *)(&dwTemp) + 1))
#define BYTE2(dwTemp)       (*((char *)(&dwTemp) + 2))
#define BYTE3(dwTemp)       (*((char *)(&dwTemp) + 3))


//
uint8_t NRF24L01_RXDATA[RX_PLOAD_WIDTH];//nrf24l01接收到的数据
uint8_t NRF24L01_TXDATA[TX_PLOAD_WIDTH];//nrf24l01需要发送的数据
//u8  TX_ADDRESS[TX_ADR_WIDTH]= {0xE1,0xE2,0xE3,0xE4,0xE5};	//本地地址
//u8  RX_ADDRESS[RX_ADR_WIDTH]= {0xE1,0xE2,0xE3,0xE4,0xE5};	//接收地址



extern short temp;


void NRF_Check_Event(void){
	u8 rx_len = 0;
	u8 sta = 0;
	
	sta	= NRF24L01_Read_Reg(NRF24L01_READ_REG+STATUS);

	//接收到数据
	if(sta & 1<<RX_DR){
				//读取接收数据长度
				rx_len = NRF24L01_Read_Reg(R_RX_PL_WID);
		    
				if(rx_len < 33){
					//读取数据	
					NRF24L01_Read_Buf(NRF24L01_RD_RX_PLOAD,NRF24L01_RXDATA,rx_len);
					Usart1_Send_Buf(NRF24L01_RXDATA,rx_len);
					//分析数据
					Data_Receive_Anl(NRF24L01_RXDATA,rx_len);
				
				}else{

					NRF24L01_Write_Reg(NRF24L01_FLUSH_RX,0xff);	
				}
	}
	
	if(sta & (1<<TX_DS))
	{
		//LED1_ONOFF();
	}
	////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////
	if(sta & (1<<MAX_RT))
	{
		if(sta & 0x01)	//TX FIFO FULL
		{
			NRF24L01_Write_Reg(NRF24L01_FLUSH_TX,0xff);
		}
	}
	////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////
	NRF24L01_Write_Reg(NRF24L01_WRITE_REG + STATUS, sta);

}


u8 Get_Sum(u8 *buff,u8 len){
	u8 i = 0,sum = 0;
	for(i=0;i<(len-1);i++){
		sum+=*(buff+i);
	}
  return sum;
}


void Data_Receive_Anl(u8 *buff,u8 len){

   vs16 rc_value_temp;
	
	 if(!(Get_Sum(buff,buff[3]+5) == *(buff+buff[3]+5-1)))
				return;
	 if(!(*(buff) == 0xaa && *(buff+1)==0xab))
				return;
	
	 TX_Mode();
	 delay_ms(50);
	 if(*(buff+2) == 0x01)  //检查连接
	 {
		
			Send_Check_NRF();
   }
		 
	 if(*(buff+2) == 0x02)  //获取温度
	 {
		
		 Send_Temp();
	 }
		 
	 RX_Mode();
	 delay_ms(50);
}


//0x01
void Send_Check_NRF(void){
	u8 tx_len=0;
	u8 data_send[32];
	
	data_send[tx_len++] = 0xaa;
	data_send[tx_len++] = 0xab;
	data_send[tx_len++] = 0x01;
	data_send[tx_len++] = 0;
	
	data_send[tx_len++] = 0xcc;
	data_send[tx_len++] = 0xcc;
	data_send[3] = tx_len - 4;
	data_send[tx_len++] = Get_Sum(data_send,tx_len+1);
	//data_send[tx_len++] = 0xaf;
	
	Usart1_Send_Buf(data_send , tx_len);
	
	//NRF_TxPacket(data_send,tx_len);
	//NRF24L01_TxPacket(data_send,tx_len);
	while(!(NRF24L01_TxPacket(data_send, tx_len) == TX_OK));	
		
}
//0x02
void Send_Temp(void){

	u8 tx_len=0;
	u8 data_send[32];

	data_send[tx_len++] = 0xaa;
	data_send[tx_len++] = 0xab;
	data_send[tx_len++] = 0x02;
	data_send[tx_len++] = 0;
	temp=DS18B20_Get_Temp();
	//data_send[tx_len++] = BYTE0(temp);   //(temp&0xff00)>>8;  
	//data_send[tx_len++] = BYTE1(temp);// temp&0xff;  
		if(temp<0)
	{
		data_send[tx_len++]  = '-';
		temp= temp*(-1); 
	}
	else
	{
		data_send[tx_len++] = temp/1000+0x30;
	}
	data_send[tx_len++] = temp%1000/100+0x30;
	data_send[tx_len++] = temp%1000%100/10+0x30;
	data_send[tx_len++] = temp%100%100%10+0x30;
	data_send[3] = tx_len - 4;
	data_send[tx_len++] = Get_Sum(data_send,tx_len+1);
	//data_send[tx_len++] = 0xaf;
	
	Usart1_Send_Buf(data_send , tx_len);
	
	//NRF_TxPacket(data_send,tx_len);
 while(!(NRF24L01_TxPacket(data_send, tx_len) == TX_OK));

 //  while(!(NRF24L01_TxPacket("SEND TEMP", tx_len) == TX_OK));
	//NRF24L01_TxPacket(data_send,tx_len);	
	
	 
}


