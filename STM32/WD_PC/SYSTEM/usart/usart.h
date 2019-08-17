#ifndef __USART_H
#define __USART_H

#include "stdio.h"
#include "sys.h"

extern u8 Rx_Buf[32];	//两个32字节的串口接收缓存
extern u8 Rx_Ok0;		//接收完毕标志
extern u8 Rx_Ok1;
extern u8 USART_RX_BUF[64];     //接收缓冲,最大63个字节.末字节为换行符 
extern u8 USART_RX_STA;         //接收状态标记	

void uart_init(u32 bound);
void Usart1_Send_Buf(unsigned char *DataToSend , u8 data_num);

#endif
