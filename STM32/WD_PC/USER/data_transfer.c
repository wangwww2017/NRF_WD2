#include "data_transfer.h"


#define BYTE0(dwTemp)       (*(char *)(&dwTemp))
#define BYTE1(dwTemp)       (*((char *)(&dwTemp) + 1))
#define BYTE2(dwTemp)       (*((char *)(&dwTemp) + 2))
#define BYTE3(dwTemp)       (*((char *)(&dwTemp) + 3))


//
uint8_t NRF24L01_RXDATA[RX_PLOAD_WIDTH];//nrf24l01接收到的数据
uint8_t NRF24L01_TXDATA[TX_PLOAD_WIDTH];//nrf24l01需要发送的数据
//u8  TX_ADDRESS[TX_ADR_WIDTH]= {0xE1,0xE2,0xE3,0xE4,0xE5};	//本地地址
//u8  RX_ADDRESS[RX_ADR_WIDTH]= {0xE1,0xE2,0xE3,0xE4,0xE5};	//接收地址

u8 data_send[40];

extern short temp;


void Uart_DTSend_Buf(unsigned char *DataToSend , u8 data_num)
{
	Usart1_Send_Buf(DataToSend,data_num);
}

void NRF_DTSend_Buf(unsigned char *DataToSend , u8 data_num)
{
	
		//NRF_TxPacket(DataToSend,data_num);
	  NRF24L01_TxPacket(DataToSend);
}



void Usart_Data_Anl(u8 *rec_data,u8 rx_len){

		u8 tx_data[32];
	  u8 tx_len;
		u8 i = 0;	
	/*
		tx_len = rec_data[3]+6;
	  for(i=0;i<tx_len;i++){
		
			tx_data[i] = rec_data[i];
		}
		
		Usart1_Send_Buf(tx_data,tx_len);
	*/
	 Usart1_Send_Buf(rec_data,rx_len);
}



void Uart_CheckEvent(void)		//负责与上位机通信,检查上位机是否有数据要发送
{
	TX_Mode();
	
	
	if(Rx_Ok0)
	{
		Rx_Ok0 = 0;
		delay_ms(50);
		//Usart1_Send_Buf(Rx_Buf,Rx_Buf[3]+5);
		
		NRF_DTSend_Buf(Rx_Buf,Rx_Buf[3]+5);
		
	}/*
	if(Rx_Ok1)
	{
		Rx_Ok1 = 0;
		
		Usart1_Send_Buf(Rx_Buf[1],Rx_Buf[0][3]+5);
		
		NRF_DTSend_Buf(Rx_Buf[1],Rx_Buf[1][3]+5);
		
	}*/
	RX_Mode();
	delay_ms(50);
}


void NRF_Check_Event(void){
	u8 rx_len = 0;
	u8 sta = 0;
	
	
	/*rx_len = NRF24L01_RxPacket(NRF24L01_RXDATA);
	//printf("%d",rx_len);
	if(rx_len)
		Usart1_Send_Buf(NRF24L01_RXDATA,rx_len );*/
	
	
	sta	= NRF24L01_Read_Reg(NRF24L01_READ_REG+STATUS);
//  printf("REC %d\r\n",sta);
	//接收到数据
	if(sta & 1<<RX_DR){
				//读取接收数据长度
				rx_len = NRF24L01_Read_Reg(R_RX_PL_WID);
				if(rx_len < 33){
					//读取数据	
					NRF24L01_Read_Buf(NRF24L01_RD_RX_PLOAD,NRF24L01_RXDATA,rx_len);
					//
					
					//Usart1_Send_Buf(NRF24L01_RXDATA,rx_len);
					
					Usart_Data_Anl(NRF24L01_RXDATA,rx_len);
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

/*
void Data_Receive_Anl(u8 *buff,u8 len){

   vs16 rc_value_temp;
		
	 if(!(Get_Sum(buff,len) == *(buff+len-1)))
				return;
	 if(!(*(buff) == 0xaa && *(buff+1)==0xab))
				return;
	 
	 if(*(buff+2) == 0x01)
		 Send_Check_NRF();
	 if(*(buff+2) == 0x02)
		 Send_Temp();
	 
}


//0x01
void Send_Check_NRF(void){
	u8 tx_len;
	
	data_send[tx_len++] = 0xaa;
	data_send[tx_len++] = 0xab;
	data_send[tx_len++] = 0x01;
	data_send[tx_len++] = 0;
	
	data_send[tx_len++] = 0xcc;
	data_send[tx_len++] = 0xcc;
	data_send[3] = tx_len - 4;
	data_send[tx_len++] = Get_Sum(data_send,tx_len+1);
	
	
	NRF_TxPacket(data_send,tx_len);
}
//0x02
void Send_Temp(void){

	u8 tx_len;
	
	data_send[tx_len++] = 0xaa;
	data_send[tx_len++] = 0xab;
	data_send[tx_len++] = 0x02;
	data_send[tx_len++] = 0;
	
	data_send[tx_len++] = BYTE0(temp);
	data_send[tx_len++] = BYTE1(temp);
	data_send[3] = tx_len - 4;
	data_send[tx_len++] = Get_Sum(data_send,tx_len+1);
	
	
	NRF_TxPacket(data_send,tx_len);

}
*/

