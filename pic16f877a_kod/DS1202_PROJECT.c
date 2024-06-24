#include <16f628a.h>

#fuses HS,NOWDT,NOPROTECT, NOBROWNOUT, NOLVP

#use delay (clock = 4000000)
#include "add_lcd.h"                                                
#include "DS1302.C"  

#use fast_io(a)
#use fast_io(b)

int saniye, dakika, saat, gun, ay, yil, haftanin_gunu;

// 0 bitki yok 
// 1 gul
// 2 marul
// 3 cilek
char bitki = '0';
int1 haber1 = 0;
int1 haber2 = 0;
int1 haber3 = 0;

// durumlar
int1 durum1 = 0;
int1 durum2 = 0;
int1 durum3 = 0;

int8 x = 0;
int8 y = 0;



int main()
{  

   
   
   set_tris_a(0x10);
   set_tris_b(0x08);
   output_a(0);
   lcd_init();
   rtc_init();
   
   //------- pwm ----------
  // setup_psp(PSP_DISABLED);    // asenkton haberlesme
  // setup_spi(SPI_SS_DISABLED); // yazdirma hizmeti arayuzu
  // setup_timer_0(RTCC_INTERNAL|RTCC_DIV_1);
  // setup_timer_1(T1_DISABLED); 
  // setup_timer_2(T2_DIV_BY_16,255,1); // PWM icin timer2 kullaniliyor 
   // maksimum 255 olarak ayarladik
   
   //**************************
   //day - mounth - year - dow - saat - minute
   rtc_set_datetime(29, 11, 22, 2, 8, 9); 
   
   //----- pwm ----
   //setup_ccp1(CCP_PWM);
   //setup_ccp1(CCP_PWM);
   //set_pwm1_duty(k);
   //delay_us(20);
   
   // Sistemin basladigi gun
   rtc_get_date(gun, ay, yil, haftanin_gunu);
   int8 sistemBaslamaGunu = gun;
   
while(TRUE)
   {
      
      
      rtc_get_time(saat, dakika, saniye);
      rtc_get_date(gun, ay, yil, haftanin_gunu);
      
      
      
      if(saat == 8) // Sadece sabah 8 de sulama yapilir.
      {
         // Sulama Sistemi
         if(bitki == '1')   // Gul
         {
            if(durum1 == 1 && durum2 == 1 && durum3 == 1)
            // Meyve Durumu
            {
               // 2 gunde 1 4 dakika 
               if(sistemBaslamaGunu %2 == 0 && dakika < 4 ) output_high(pin_a3);
               else output_low(pin_a3);
            }
            else if(durum1 == 1 && durum2 == 1 && durum3 == 0 )
            //Ciceklenme Durumu
            {
               //  2 g�nde 1 4 dk
               if(sistemBaslamaGunu %2 == 0 && dakika < 4 ) output_high(pin_a3);
               else output_low(pin_a3);
            }
            else if(durum1 == 1 && durum2 == 0 && durum3 == 0)
            //Cimlenme Durumu
            {
               // sabah 8 4 dakika - herg�n
               if(dakika <  4) output_high(pin_a3);
               else {   output_low(pin_a3);  }
            }
            else
            // Tohum Hali
            {
               // 2 dakika - herg�n
               if(dakika <  2) output_high(pin_a3);
               else {   output_low(pin_a3);  }
            }
         }// Saat 8 olmal�n�n s�sl� parantezi
         }
         else if(bitki == '2')  // Marul
         {
            if(durum1 == 1 && durum2 == 1 && durum3 == 1)
            // Meyve Durumu
            {
               //  2 g�nde 1 - 4 dk
               if(sistemBaslamaGunu %2 == 0 && dakika < 4 ) output_high(pin_a3);
               else output_low(pin_a3);
            }
            else if(durum1 == 1 && durum2 == 1 && durum3 == 0 )
            //Ciceklenme Durumu
            {
               //  2 g�nde 1 - 4 dk
               if(sistemBaslamaGunu %2 == 0 && dakika < 4 ) output_high(pin_a3);
               else output_low(pin_a3);
            }
            else if(durum1 == 1 && durum2 == 0 && durum3 == 0)
            //Cimlenme Durumu
            {
               //  2 g�nde 1 - 3 dk
               if(sistemBaslamaGunu %2 == 0 && dakika < 3 ) output_high(pin_a3);
               else output_low(pin_a3);
            }
            else
            // Tohum Hali
            {
               // 2 dakika - herg�n
               if(dakika <  2) output_high(pin_a3);
               else {   output_low(pin_a3);  }
            }
         
         }
         else if(bitki == '3')  // �ilek
         {
            if(durum1 == 1 && durum2 == 1 && durum3 == 1)
            // Meyve Durumu
            {
                //  2 g�nde 1 - 3 dk
               if(sistemBaslamaGunu %2 == 0 && dakika < 3 ) output_high(pin_a3);
               else output_low(pin_a3);
            }
            else if(durum1 == 1 && durum2 == 1 && durum3 == 0 )
            //Ciceklenme Durumu
            {
               //  2 g�nde 1 - 4 dk
               if(sistemBaslamaGunu %2 == 0 && dakika < 4 ) output_high(pin_a3);
               else output_low(pin_a3);
            }
            else if(durum1 == 1 && durum2 == 0 && durum3 == 0)
            //Cimlenme Durumu
            {
               //  2 g�nde 1 - 3 dk
               if(sistemBaslamaGunu %2 == 0 && dakika < 3 ) output_high(pin_a3);
               else output_low(pin_a3);
            }
            else
            // Tohum Hali
            {
               // 2 dakika - herg�n
               if(dakika <  2) output_high(pin_a3);
               else {   output_low(pin_a3);  }
            }
         
         }
            
         
      
         
      printf(lcd_putc, "\f%02d:%02d:%02d  ",saat, dakika, saniye);
      switch(haftanin_gunu)
      {
      case 1: printf(lcd_putc,"P.TESI" );   break ;
      case 2: printf(lcd_putc,"SALI" );     break ;
      case 3: printf(lcd_putc,"CARSAMBA" ); break ;
      case 4: printf(lcd_putc,"PERSEMBE" ); break ;
      case 5: printf(lcd_putc,"CUMA" );     break ;
      case 6: printf(lcd_putc,"C.TESI" );   break ;
      case 7: printf(lcd_putc,"PAZAR" );    break ;
      }
      printf(lcd_putc, "\n%02d:%02d:%02d  "gun, ay, yil);
      
     
      // x in alinmasi
      if(haber2 == 0)
      {
         // bitkinin alinmasi
         if(input(pin_B3) == 1)
         {
            haber1 = 1;
            delay_ms(50);
         }
         else if(haber1 == 1)
         {
            x++;
            haber1 = 0;
            delay_ms(50);
         }
         // x e g�re bitki se�imi
         if(x == 1) bitki = '1';
         else if(x == 2) bitki = '2';
         else if(x == 3) bitki = '3';
         
         
         // durumlarin alimasi
         if(input(pin_a4) == 1)
         {
            haber3 = 1;
            delay_ms(50);
         }
         else if(haber3 == 1)
         {
            y++;
            haber3 = 0;
            delay_ms(50);
         }
         
         // y  ye gore durum alin masi
         if(y == 1)      
         {
            durum1 = 1;
         }
         else if(y == 2) 
         {
            durum1 = 1;
            durum2 = 1;
         }
         else if(y == 3)
         {
            durum1 = 1;
            durum2 = 1;
            durum3 = 1;
         }
         
         if(saniye == 8)   haber2 = 1;
         
            
      }
      
      
      
      
      
      
      // bitki degerine gore bitkinin yaz�lmas� (sonsuz)
      lcd_gotoxy(11,2);
      if(bitki == '1')  printf(lcd_putc, "GUL");
      
      lcd_gotoxy(11,2);
      if(bitki == '2')  printf(lcd_putc, "MARUL");
     
      if(bitki == '3')  printf(lcd_putc, "CILEK");
      
      
      delay_ms(300);
   }
   return 0;
}
