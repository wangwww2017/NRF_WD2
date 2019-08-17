#ifndef _DATA_TRANSFER_H_
#define _DATA_TRANSFER_H_

#include "sys.h"
#include "delay.h"
#include "24l01.h"
#include "usart.h"

extern uint8_t NRF24L01_RXDATA[RX_PLOAD_WIDTH];//nrf24l01���յ�������
extern uint8_t NRF24L01_TXDATA[TX_PLOAD_WIDTH];//nrf24l01��Ҫ���͵�����
//extern u8  TX_ADDRESS[TX_ADR_WIDTH];	//���ص�ַ
//extern u8  RX_ADDRESS[RX_ADR_WIDTH];	//���յ�ַ




void Data_Receive_Anl(u8 *buff,u8 len);
void Send_Check_NRF(void);
void Send_Temp(void);
void NRF_Check_Event(void);
u8 Get_Sum(u8 *buff,u8 len);

#endif
