//////////////////////////////////////////////////////////////////////////
////                               DS1302.C                           ////
////                     Driver for Real Time Clock                   ////
////                                                                  ////
////  rtc_init()                                   Call after power up////
////                                                                  ////
////  rtc_set_datetime(day,mth,year,dow,hour,min)  Set the date/time  ////
////                                                                  ////
////  rtc_get_date(day,mth,year,dow)               Get the date       ////
////                                                                  ////
////  rtc_get_time(hr,min,sec)                     Get the time       ////
////                                                                  ////
////  rtc_write_nvr(address,data)                  Write to NVR       ////
////                                                                  ////
////  data = rtc_read_nvr(address)                 Read from NVR      ////
////                                                                  ////
//////////////////////////////////////////////////////////////////////////
////        (C) Copyright 1996,2003 Custom Computer Services          ////
//// This source code may only be used by licensed users of the CCS C ////
//// compiler.  This source code may only be distributed to other     ////
//// licensed users of the CCS C compiler.  No other use, reproduction////
//// or distribution is permitted without written permission.         ////
//// Derivative programs created using this software in object code   ////
//// form are not restricted in any way.                              ////
//////////////////////////////////////////////////////////////////////////

#ifndef RTC_SCLK



#define RTC_RST  PIN_A0
#define RTC_SCLK PIN_A1
#define RTC_IO   PIN_A2

#endif


void write_ds1302_byte(BYTE cmd) {
   BYTE i;

   for(i=0;i<=7;++i) {
      output_bit(RTC_IO, shift_right(&cmd,1,0) );
      output_high(RTC_SCLK);
      output_low(RTC_SCLK);
   }
}

void write_ds1302(BYTE cmd, BYTE data) {

   output_high(RTC_RST);
   write_ds1302_byte(cmd);
   write_ds1302_byte(data);
   output_low(RTC_RST);
}

BYTE read_ds1302(BYTE cmd) {
   BYTE i,data;

   output_high(RTC_RST);
   write_ds1302_byte(cmd);

   for(i=0;i<=7;++i) {
      shift_right(&data,1,input(RTC_IO));
      output_high(RTC_SCLK);
      delay_us(2);
      output_low(RTC_SCLK);
      delay_us(2);
   }
   output_low(RTC_RST);
   return(data);
}

void rtc_init() {
   BYTE x;
   output_low(RTC_RST);
   delay_us(2);
   output_low(RTC_SCLK);
   write_ds1302(0x8e,0);
   write_ds1302(0x90,0xa6);
   x=read_ds1302(0x81);
   if((x & 0x80)!=0)
     write_ds1302(0x80,0);
}

void rtc_set_datetime(BYTE day, BYTE mth, BYTE year, BYTE dow, BYTE hr, BYTE min) {
   write_ds1302(0x86,day);
   write_ds1302(0x88,mth);
   write_ds1302(0x8c,year);
   write_ds1302(0x8a,dow);
   write_ds1302(0x84,hr);
   write_ds1302(0x82,min);
   write_ds1302(0x80,0);
}

void rtc_get_date(BYTE& day, BYTE& mth, BYTE& year, BYTE& dow) {
   day = read_ds1302(0x87);
   mth = read_ds1302(0x89);
   year = read_ds1302(0x8d);
   dow = read_ds1302(0x8b);
}


void rtc_get_time(BYTE& hr, BYTE& min, BYTE& sec) {
   hr = read_ds1302(0x85);
   min = read_ds1302(0x83);
   sec = read_ds1302(0x81);
}

void rtc_write_nvr(BYTE address, BYTE data) {
   write_ds1302(address|0xc0,data);
}

BYTE rtc_read_nvr(BYTE address) {
    return(read_ds1302(address|0xc1));
}
