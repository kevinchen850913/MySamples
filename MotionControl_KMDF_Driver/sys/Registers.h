#ifndef __REGISTERS_H_
#define __REGISTERS_H_

//*****************************************************************************
//  
//  File Name: Reg9656.h
// 
//  Description:  This file defines all the CPI APIC21 chip Registers.
// 
//  NOTE: These definitions are for memory-mapped register access only.
//
//*****************************************************************************

//-----------------------------------------------------------------------------   
// PCI Device/Vendor Ids.
//-----------------------------------------------------------------------------   
//#define MC8881P_PCI_VENDOR_ID               0x136C
//#define MC8881P_PCI_DEVICE_ID               0xA0F7
//
//#define APIC21_PCI_HDR_LENGTH            192
                                        
//-----------------------------------------------------------------------------   
// Expected size of the APIC21 on-board SRAM
//-----------------------------------------------------------------------------   
//#define APIC21_SRAM_SIZE                  (0x20000)//Max:128Kbyte
//                                                   
//
//typedef struct _ADAPTER_CONTROL_ {
//	unsigned int  PCI_ReadMode                 : 1;  // bit 0
//	unsigned int  PCI_ReadNoWriteMode          : 1;  // bit 1
//	unsigned int  PCI_WriteMode                : 1;  // bit 2
//	unsigned int  PCI_WRCompletionMode         : 1;  // bit 3
//	unsigned int  ApplicationWriteNoPrefetchRD : 1;  // bit 4
//	unsigned int  PCI_InitialLatencyEnable     : 1;  // bit 5
//	unsigned int  DataParityMode               : 1;  // bit 6
//	unsigned int  AdapterSoftwareReset         : 1;  // bit 7
//} ADAPTER_CONTROL;
//
//typedef struct _ADAPTER_STATUS_ {
//	unsigned int  PrefetchRDBufferFull  : 1;  // bit 0
//	unsigned int  DirectIORDBufferEmpty : 1;  // bit 1
//	unsigned int  DirectIORDBufferFull  : 1;  // bit 2
//	unsigned int  WRFIFOSpaceFull       : 1;  // bit 3
//	unsigned int  DetectTimerBorrow     : 1;  // bit 4
//	unsigned int  RDFIFOFlush           : 1;  // bit 5
//	unsigned int  WRFIFOFlush           : 1;  // bit 6
//	unsigned int  TimerStatusClear      : 1;  // bit 7
//} ADAPTER_STATUS;

//-----------------------------------------------------------------------------   
// Define the Interrupt Command Status Register (CSR)
//-----------------------------------------------------------------------------   
//typedef struct _INTERRUPT_FLAG_ {
//	unsigned int  IRQ0                   : 1;  // bit 0
//	unsigned int  IRQ1                   : 1;  // bit 1
//	unsigned int  IRQ2                   : 1;  // bit 2
//	unsigned int  IRQ3                   : 1;  // bit 3
//	unsigned int  RDBufferError          : 1;  // bit 4
//	unsigned int  WRFIFOError            : 1;  // bit 5
//	unsigned int  DirectIOBufferHalfFull : 1;  // bit 6
//	unsigned int  Reserved               : 1;  // bit 7
//} INTERRUPT_FLAG;
//
//typedef struct _INTERRUPT_CLEAR_ {
//	unsigned int  IRQ0                   : 1;  // bit 0
//	unsigned int  IRQ1                   : 1;  // bit 1
//	unsigned int  IRQ2                   : 1;  // bit 2
//	unsigned int  IRQ3                   : 1;  // bit 3
//	unsigned int  RDBufferError          : 1;  // bit 4
//	unsigned int  WRFIFOError            : 1;  // bit 5
//	unsigned int  DirectIOBufferHalfFull : 1;  // bit 6
//	unsigned int  Reserved               : 1;  // bit 7
//} INTERRUPT_CLEAR;
//
//typedef struct _LOCAL_CONTROL_ {
//	unsigned int  LocalBusWidth         : 2;  // bit 0-1
//	unsigned int  MemoryPrefetchEnable  : 1;  // bit 2
//	unsigned int  PrefetchCount         : 3;  // bit 3-5
//	unsigned int  DirectIOReadEnable    : 1;  // bit 6
//	unsigned int  DirectIORegisterSize  : 1;  // bit 7
//	unsigned int  IOAddressRegister     : 8;  // bit 8-15
//	unsigned int  MemoryRDAddressWait   : 1;  // bit 16
//	unsigned int  MemoryRDDataWait      : 2;  // bit 17-18
//	unsigned int  MemoryWRAddressWait   : 1;  // bit 19
//	unsigned int  MemoryWRDataWait      : 2;  // bit 20-21
//	unsigned int  MemoryAddressHoldTime : 1;  // bit 22
//	unsigned int  TimerClockControl     : 1;  // bit 23
//	unsigned int  IOAddressingMode      : 1;  // bit 24
//	unsigned int  IORDAddressWait       : 1;  // bit 25
//	unsigned int  IORDDataWait          : 2;  // bit 26-27
//	unsigned int  IOWRAddressWait       : 1;  // bit 28
//	unsigned int  IOWRDataWait          : 2;  // bit 29-30
//	unsigned int  IOAddressHoldTime     : 1;  // bit 31
//} LOCAL_CONTROL;

//typedef struct _EXTERNAL_INTERRUPT_CONTROL_ {
//	unsigned int  IRQ0_InterruptEnable : 1;    // bit 0
//	unsigned int  IRQ0_InterruptType : 1;      // bit 1
//	unsigned int  IRQ0_InterruptPriority : 1;  // bit 2
//	unsigned int  IRQ0_Polarity : 1;           // bit 3
//	unsigned int  IRQ1_InterruptEnable : 1;    // bit 4
//	unsigned int  IRQ1_InterruptType : 1;      // bit 5
//	unsigned int  IRQ1_InterruptPriority : 1;  // bit 6
//	unsigned int  IRQ1_Polarity : 1;           // bit 7
//	unsigned int  IRQ2_InterruptEnable : 1;    // bit 8
//	unsigned int  IRQ2_InterruptType : 1;      // bit 9
//	unsigned int  IRQ2_InterruptPriority : 1;  // bit 10
//	unsigned int  IRQ2_Polarity : 1;           // bit 11
//	unsigned int  IRQ3_InterruptEnable : 1;    // bit 12
//	unsigned int  IRQ3_InterruptType : 1;      // bit 13
//	unsigned int  IRQ3_InterruptPriority : 1;  // bit 14
//	unsigned int  IRQ3_Polarity : 1;           // bit 15
//} EXTERNAL_INTERRUPT_CONTROL;


#pragma warning(default:4214) 

//-----------------------------------------------------------------------------   
// APIC_REGS structure
//-----------------------------------------------------------------------------   
//typedef struct _APIC21_REGS_ {
//
//	unsigned char     Adapter_Control;         // 0x000 
//	unsigned char     Adapter_Status;          // 0x001 
//	unsigned char     Interrupt_Flag;          // 0x002 
//	unsigned char     Interrupt_Clear;         // 0x003 
//	LOCAL_CONTROL     Local_Control;           // 0x004
//    unsigned int      VirtualRegisterAddress;  // 0x008 
//    unsigned int      VirtualRegisterData;     // 0x00C 
//} APIC21_REGS, * PAPIC21_REGS; 

#endif  // __REGISTERS_H_
