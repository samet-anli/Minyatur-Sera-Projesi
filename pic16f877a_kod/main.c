#include <16F877A.h>
//#fuses XT,NOWDT,NOPROTECT,NOBROWNOUT,NOLVP,NOPUT,NOWRT,NOCPD
#fuses HS,NOWDT,NOPROTECT,NOLVP 
#device ADC = 10

#include "add_lcd.h"
#include "ds18b20.h"
#include "dht11.h"

#use fast_io(B)
#use fast_io(C)

#use delay(clock = 8MHz)

#use rs232(baud=9600, xmit=pin_c6, rcv = pin_c7 , parity=N, stop=1 )
//#use rs232(baud=900, parity=N, xmit=PIN_C6, rcv=PIN_C7, bits=8, Stream=RF)

// timer
int sayac = 0, saniye = 0;

char gelenVeri;

char x = 223;
char yuzde = 37;

// bitki : 0 yok , 1 = gul , 2 = marul , 3 = cilek , sifir = 0
char bitki  = '0';
char durum1 = '0';
char durum2 = '0';
char durum3 = '0';
char seriportON_OFF = '0';

// Degiskenlerimiz..
int toprakNem = 0;
int suSeviye = 0;
int ldr = 0;
int toprakNemError = 0;
int fanNem = 0; // Fan'i kontrol eder deger  Ve Hava Nem
int fanSicaklik = 0;

 /*
    if     (gelenVeri == 'g') bitki = 1;
   else if(gelenVeri == 'm') bitki = 2;
   else if(gelenVeri == 'c') bitki = 3;
   else if(gelenVeri == 's') bitki = 0;
   */
   
#int_rda // veri gelince calisan kesme
void kesme()
{
   gelenVeri = getch();
   
   if     (gelenVeri == 'g') bitki = '1';
   else if(gelenVeri == 'm') bitki = '2';
   else if(gelenVeri == 'c') bitki = '3';
   else if(gelenVeri == 's') // SIFIRLAMA
   {
   bitki  = '0';
   durum1 = '0';
   durum2 = '0';
   durum3 = '0';
   seriportON_OFF = '0';
   saniye  = 0 ;
   }
   if     (gelenVeri == 't') durum1 = '0';
   else if(gelenVeri == 'y') durum1 = '1';
   
   if     (gelenVeri == 'u') durum2 = '0';
   else if(gelenVeri == 'i') durum2 = '1';
   
   if     (gelenVeri == 'b') durum3 = '0';
   else if(gelenVeri == 'n') durum3 = '1';
   
   if     (gelenVeri == 'x') seriportON_OFF = '0';
   else if(gelenVeri == 'w') seriportON_OFF = '1';
   
   
   
   write_eeprom(0,bitki);
   write_eeprom(1,durum1);
   write_eeprom(2,durum2);
   write_eeprom(3,durum3);
   
   
}



#int_TIMER0
void timer0_kesmesi() {
   if(++sayac == 61)    // timer0 61 kez ta?t?ysa
   {                   // 61 x 16.3 ms = 1 sn s?re ge?mi?tir
   if(bitki != '0')
      saniye++;
      
      // Seri portun Acilmesi
         
         if(seriportON_OFF == '1')
         {
            
            printf("Su Seviye: %c%d\n",yuzde, suSeviye);
            printf("Toprak -------");
            printf("Nem      :%c%d\n",yuzde, toprakNem);
            printf("Sicaklik:%fC ",temp);
            
            printf("----------------");
            printf("Hava ---------");
            printf("Nem      :%c%d\n",yuzde, fanNem);
            printf("Sicaklik:%dC", fanSicaklik);
            printf("----------------");
            printf("Isik Siddeti: %d", ldr);
            printf("--------------");
         
         }
   }  
}


void main()
{
      
   //ADC
   setup_adc(adc_clock_div_32); 
   setup_adc_ports(AN0_AN1_AN2_AN3_AN4); 

   
   
   // Bitki Secim icin --
   
   set_tris_c(0xF8);
   set_tris_b(0xF2);
   
   output_c(0);
   output_b(0);
    // timer
   setup_timer_0(RTCC_INTERNAL|RTCC_DIV_32|RTCC_8_bit);      //16.3 ms overflow
   enable_interrupts(INT_TIMER0); //kesme aktif
   
   
   // rs232 icin
   enable_interrupts(int_rda); // int_rda kesmesi aaktif
   enable_interrupts(GLOBAL);

   
    
   lcd_init();
   lcd_putc('\f');                                
   lcd_gotoxy(1, 1);
   
   printf(lcd_putc, "  **  SERA  **  ");
   printf(lcd_putc, "\n   OTOMASYONU   ");
   delay_ms(1000);
   
   printf(lcd_putc,"\f");
   printf(lcd_putc, "Basliyor...");
  
  // ROM deki verilern �ekilmesi
   bitki  = read_eeprom(0);
   durum1 = read_eeprom(1);
   durum2 = read_eeprom(2);
   durum3 = read_eeprom(3);
   printf(lcd_putc,"\f");
   printf(lcd_putc, "Basliyor1ee...");
   
   int i = 0;
   // bitkinin saate bildirilmesi
   if(bitki == '1')
      {
         
         delay_ms(400);
         output_high(pin_c0);
         delay_ms(400);
         output_low(pin_c0);
      }
      else if(bitki == '2')
      {
         for (i=0;i<2;i++)
         {
         delay_ms(400);
         output_high(pin_c0);
         delay_ms(400);
         output_low(pin_c0);
         delay_ms(400);
         }
      }
      else if(bitki == '3')
      {
         for (i=0;i<3;i++)
         {
         delay_ms(400);
         output_high(pin_c0);
         delay_ms(400);
         output_low(pin_c0);
         delay_ms(400);
         }
      }
      
      
      //  Durumlarin Gonderilmesi
      if(durum3 == '1')
      {
      for (i=0;i<3;i++)
         {
         delay_ms(400);
         output_high(pin_c1);
         delay_ms(400);
         output_low(pin_c1);
         delay_ms(400);
         
         }
      }
      else if(durum2 == '1')
      {
         for (i=0;i<3;i++)
         {
         delay_ms(400);
         output_high(pin_c1);
         delay_ms(400);
         output_low(pin_c1);
         
         }
      }
      else if(durum1 == '1')
      {
         delay_ms(400);
         output_high(pin_c1);
         delay_ms(400);
         output_low(pin_c1);
      }
   
 
     printf(lcd_putc,"\f");
   printf(lcd_putc, "Basliyor2st...");
   
 // Ana Dongunun Girisi
 //_------
   while(TRUE)
   {
 
    
   // Butun sinyaller her an okunuyor
   
      // Su Seviye
      set_adc_channel(1);
      suSeviye =  read_adc() * 0.1;
      // Toprak Nem
      set_adc_channel(0);
      toprakNem =  read_adc() * 0.1;
      // LDR
      set_adc_channel(2);
      ldr =  read_adc() * 0.1;
      
     // toprakSicaklik
      if(ds18b20_read(&raw_temp)) 
     {
      temp = (float)raw_temp / 16;               
                              
      toprakNemError = 0;
                                 
      }
      else {
      toprakNemError = 1;                
      }
        printf(lcd_putc,"\f");
   printf(lcd_putc, "dht1r...");
      // DHT11 
         Time_out = 0;
         Start_signal();
         if(check_response())
         {                     // Sensorden tepki varsa 
         RH_byte1 = Read_Data();                 // okuma RH byte1
         RH_byte2 = Read_Data();                 // okuma RH byte2
         T_byte1 = Read_Data();                  // okuma T byte1
         T_byte2 = Read_Data();                  // okuma T byte2
         Checksum = Read_Data();                 // okuma checksum
         if(Time_out)
         {  
            if(10 >saniye > 5 )
            {     
               lcd_putc('\f');                       // LCD clear
               lcd_gotoxy(5, 1);                     // Go to column 5 row 1
               lcd_putc("Time out!");
            }
         }
         else
         {
          if(CheckSum == ((RH_Byte1 + RH_Byte2 + T_Byte1 + T_Byte2) & 0xFF))
          {
            message1[9]  = T_Byte1/10  + 48;
            message1[10]  = T_Byte1%10  + 48;
            message1[12] = T_Byte2/10  + 48;
            message2[9]  = RH_Byte1/10 + 48;
            message2[10]  = RH_Byte1%10 + 48;
            message2[12] = RH_Byte2/10 + 48;
            message1[13] = 223; // Degree symbol
            // message1 --> Sicaklik bilgisi
            // mesaage2 --> Nem bilgisi
              printf(lcd_putc,"\f");
   printf(lcd_putc, "dht2...");
            // int to char
            if(message2[9] == '0')        fanNem = 0;
            else if(message2[9] == '1')   fanNem = 10;
            else if(message2[9] == '2')   fanNem = 20;
            else if(message2[9] == '3')   fanNem = 30;
            else if(message2[9] == '4')   fanNem = 40;
            else if(message2[9] == '5')   fanNem = 50;
            else if(message2[9] == '6')   fanNem = 60;
            else if(message2[9] == '7')   fanNem = 70;
            else if(message2[9] == '8')   fanNem = 80;
            else if(message2[9] == '9')   fanNem = 90;
            
            if(message2[10] == '0')        fanNem += 0;
            else if(message2[10] == '1')   fanNem += 1;
            else if(message2[10] == '2')   fanNem += 2;
            else if(message2[10] == '3')   fanNem += 3;
            else if(message2[10] == '4')   fanNem += 4;
            else if(message2[10] == '5')   fanNem += 5;
            else if(message2[10] == '6')   fanNem += 6;
            else if(message2[10] == '7')   fanNem += 7;
            else if(message2[10] == '8')   fanNem += 8;
            else if(message2[10] == '9')   fanNem += 9;
            
            // Fan S�cakl�k
            if(message1[9] == '0')        fanSicaklik = 0;
            else if(message1[9] == '1')   fanSicaklik = 10;
            else if(message1[9] == '2')   fanSicaklik = 20;
            else if(message1[9] == '3')   fanSicaklik = 30;
            else if(message1[9] == '4')   fanSicaklik = 40;
            else if(message1[9] == '5')   fanSicaklik = 50;
            else if(message1[9] == '6')   fanSicaklik = 60;
            else if(message1[9] == '7')   fanSicaklik = 70;
            else if(message1[9] == '8')   fanSicaklik = 80;
            else if(message1[9] == '9')   fanSicaklik = 90;
            
            if(message2[10] == '0')        fanSicaklik += 0;
            else if(message1[10] == '1')   fanSicaklik += 1;
            else if(message1[10] == '2')   fanSicaklik += 2;
            else if(message1[10] == '3')   fanSicaklik += 3;
            else if(message1[10] == '4')   fanSicaklik += 4;
            else if(message1[10] == '5')   fanSicaklik += 5;
            else if(message1[10] == '6')   fanSicaklik += 6;
            else if(message1[10] == '7')   fanSicaklik += 7;
            else if(message1[10] == '8')   fanSicaklik += 8;
            else if(message1[10] == '9')   fanSicaklik += 9;
            
          }
            else
            {
               if(10 >saniye > 5 )
               {
                   lcd_putc('\f');                       // LCD clear
                   lcd_gotoxy(1, 1);                     // Go to column 1 row 1
                   lcd_putc("Checksum Error!");
               }
            
            }
          }
        }
        else {
         if(20 >saniye > 10 )
         {
            lcd_putc('\f');                          // LCD clear
            lcd_gotoxy(3, 1);                        // Go to column 3 row 1
            lcd_putc("No response");
            lcd_gotoxy(1, 2);                        // Go to column 1 row 2
            lcd_putc("from the DHT11");
         }
            
        }
               
            
            
            
      // Genel Ekran temizleme
      lcd_putc('\f');

      // Su pompasinin Kontrol� 
      if(input(PIN_C3) == 1)  output_high(PIN_B0); // SuPompasi Aktif
      else                    output_low(PIN_B0);
      
      
      //  Fan kontorol
      if(bitki == '1')
      {  
         //
         if(fanNem > 70)   output_high(PIN_B2); 
         else              output_low (PIN_B2);
      }
      else if(bitki == '2')
      {
         if(fanNem > 75)   output_high(PIN_B2); 
         else              output_low (PIN_B2);
      }
      else if(bitki == '3')
      {
         if(fanNem > 80)   output_high(PIN_B2); 
         else              output_low (PIN_B2);
      }
      
      
      // Led kontrol
      // Sadece Tohum Zamaninda Ve Mevye Zamaninda 
      
      if(ldr > 8) // Gece degilse.
      {
         if(durum3 == '1')
         {
            if(ldr < 70)  output_high(PIN_B3);
            else          output_low (PIN_B3);
         }
         else if(durum1 == '0')
         {
            output_low (PIN_B3);
         }
         else
         {
            if(ldr < 30) output_high(PIN_B3);
            else         output_low (PIN_B3);
         }
      }
      else
      {
         output_low (PIN_B3);
      }
      
      
      // Sistemin Offline durumu
      
      if(bitki != '0' )
      {
         if(saniye > 15)
         {  // Su deposu seviyesi
            
            printf(lcd_putc, "SU DEPOSU SEVIYE");
            lcd_gotoxy(7,2);
            lcd_putc("%");
             printf(lcd_putc, "%d",suSeviye);
            
            delay_ms(500);
            
            if(saniye == 20) saniye = 0;
         }
         
         else if(saniye > 10)
         {  // Toprak sicaklik  ve Nem
         
            lcd_gotoxy(1, 1); 
            printf(lcd_putc, "TOPRAK NEM:");
            lcd_putc(" %");
            printf(lcd_putc, "%d",toprakNem);
            
            if(toprakNemError == 0)
            {
            lcd_gotoxy(1, 2);  
            printf(lcd_putc, "SICAKLIK:%f%cC",temp, x);
            }
            else {
            lcd_gotoxy(5, 2);   
            printf(lcd_putc, " Error! "); 
            }
            delay_ms(500); 
            
         }
         else if(saniye > 5)
         {     
         
         
            lcd_gotoxy(1, 1);                     // Go to column 1 row 1
            printf(lcd_putc, message1);           // Display message1
            lcd_gotoxy(1, 2);                     // Go to column 1 row 2
            printf(lcd_putc, message2); 
         
         
         }
         else
         {  //Isik Siddeti
            
            lcd_gotoxy(1, 1); 
            printf(lcd_putc, "  ISIK SIDDETI");
            lcd_gotoxy(2,2);
            printf(lcd_putc, ":%d Durum:%c%c%c", ldr,durum1,durum2,durum3);
            
            delay_ms(500);
            
         }
         
         
         
//-----------         
      }
      else
      {
      printf(lcd_putc,"Bitki Secimi\nYapiniz...");
      delay_ms(50);
      
      }
   }
}


