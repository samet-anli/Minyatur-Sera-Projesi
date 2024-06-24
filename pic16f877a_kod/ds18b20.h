

#define DS18B20_PIN PIN_B1
#use delay(clock = 8MHz)

signed int16 raw_temp;
float temp;

int1 ds18b20_start(){
  output_low(DS18B20_PIN);                         
  output_drive(DS18B20_PIN);                       
  delay_us(500);                                  
  output_float(DS18B20_PIN);                       
  delay_us(100);                                   
  if (!input(DS18B20_PIN)) {
    delay_us(400);                                 
    return TRUE;                                   
  }
  return FALSE;
}

void ds18b20_write_bit(int1 value){
  output_low(DS18B20_PIN);
  output_drive(DS18B20_PIN);                       
  delay_us(2);                                    
  output_bit(DS18B20_PIN, value);
  delay_us(80);                                    
  output_float(DS18B20_PIN);                     
  delay_us(2);                                    
}

void ds18b20_write_byte(int8 value){
  int8 i;
  for(i = 0; i < 8; i++)
    ds18b20_write_bit(bit_test(value, i));
}

int1 ds18b20_read_bit(void) {
  int1 value;
  output_low(DS18B20_PIN);
  output_drive(DS18B20_PIN);                      
  delay_us(2);
  output_float(DS18B20_PIN);                       
  delay_us(5);                                    
  value = input(DS18B20_PIN);
  delay_us(100);                                   
  return value;
}

int8 ds18b20_read_byte(void) {
  int8 i, value = 0;
  for(i = 0; i  < 8; i++)
    shift_right(&value, 1, ds18b20_read_bit());
  return value;
}

int1 ds18b20_read(int16 *raw_temp_value) {
  if (!ds18b20_start())                     
    return FALSE;
  ds18b20_write_byte(0xCC);                 
  ds18b20_write_byte(0x44);                 
  while(ds18b20_read_byte() == 0);          
  if (!ds18b20_start())                     
    return FALSE;                           
  ds18b20_write_byte(0xCC);                 
  ds18b20_write_byte(0xBE);                
  *raw_temp_value = ds18b20_read_byte();    
  *raw_temp_value |= (int16)(ds18b20_read_byte()) << 8;     
  return TRUE;                                
}

