#ifndef __USART_H
#define __USART_H

#include "stdio.h"
#include "sys.h"

extern u8 Rx_Buf[32];	//����32�ֽڵĴ��ڽ��ջ���
extern u8 Rx_Ok0;		//������ϱ�־
extern u8 Rx_Ok1;
extern u8 USART_RX_BUF[64];     //���ջ���,���63���ֽ�.ĩ�ֽ�Ϊ���з� 
extern u8 USART_RX_STA;         //����״̬���	

void uart_init(u32 bound);
void Usart1_Send_Buf(unsigned char *DataToSend , u8 data_num);

#endif
