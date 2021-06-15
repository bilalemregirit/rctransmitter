

#include <Wire.h> 
#include <LiquidCrystal_I2C.h>
#include <LcdBarGraphRobojax.h>


LiquidCrystal_I2C lcd(0x27, 20, 4);

LcdBarGraphRobojax lbgi(&lcd, 6, 13, 2);
LcdBarGraphRobojax lbgs(&lcd, 6, 1, 2);
LcdBarGraphRobojax lbgp(&lcd, 15, 2,2);

byte menu = 1;
int sayfa = 0;
int sdurum = 0;

int sancak ;
int iskele ;

void setup()
{
	lcd.begin();
  Serial.begin(9600);
	lcd.backlight();
	arayuz();
}

void loop()
{
            iskele = map(analogRead(A3),0,1023,103,-222);
            sancak = map(analogRead(A1),0,1023,0,313);
 

  if (digitalRead(5) == 1)
  {
    lcd.clear();
    menu--;
    sdurum--;
    if(sdurum < 0)
     {
      lcd.clear();
      sdurum = 0; 
      }
    delay(100);    
    }
    if (digitalRead(6) == 1)
  {
    lcd.clear();
    menu++;
    
    delay(100);
    }
   if(menu >= 1 || menu <= 5)
    {
      arayuz();
      }
    
   if(menu > 6)
    {
      menu = 6;
      }
      
   if(menu < 1)
    {
      menu = 1;
      }
   
   if (digitalRead(4) == 1)
    {
     lcd.clear();
     sdurum++;
     delay(200);
     Serial.println("aaaaaa");
     }


   if(sayfa > 0)
   {
    sayfalar();
    }
   if(sayfa = 0)
   {
    for(int x; x>1; x++)
    {
      lcd.clear();
      }
    }
                Serial.print("menu="); 
                Serial.println(menu);
                Serial.print("sayfad="); 
                Serial.println(sdurum);


    
}

  void arayuz()
  {
    switch(menu)
    {
      case 0:
       menu = 1;
       break;
      case 1:

      lcd.setCursor(1,0);
      lcd.print(">Motor Durum");
      lcd.setCursor(1,1);
      lcd.print(" Dumen Durum");
      lcd.setCursor(1,2);
      lcd.print(" Pil Durumu");
      lcd.setCursor(1,3);
      lcd.print(" Motor Sicaklik");
    
    if (sdurum > 0)
     {
      lcd.clear();
      sayfa = 1; 
      menu = 6;    
      }
           
       break; 
      case 2:
  
      lcd.setCursor(1,0);
      lcd.print(" Motor Durum");
      lcd.setCursor(1,1);
      lcd.print(">Dumen Durum");
      lcd.setCursor(1,2);
      lcd.print(" Pil Durumu");
      lcd.setCursor(1,3);
      lcd.print(" Motor Sicaklik");
        
    if (sdurum > 0)
     {
      lcd.clear();
      sayfa = 2; 
      menu = 6;    
      }
      
       break;
       case 3:
       
      lcd.setCursor(1,0);
      lcd.print(" Motor Durum");
      lcd.setCursor(1,1);
      lcd.print(" Dumen Durum");
      lcd.setCursor(1,2);
      lcd.print(">Pil Durumu");
      lcd.setCursor(1,3);
      lcd.print(" Motor Sicaklik");

        
    if (sdurum > 0)
     {
      lcd.clear();
      sayfa = 3; 
      menu = 6;    
      }
     
       break;
      case 4:
    
      lcd.setCursor(1,0);
      lcd.print(" Motor Durum");
      lcd.setCursor(1,1);
      lcd.print(" Dumen Durum");
      lcd.setCursor(1,2);
      lcd.print(" Pil Durumu");
      lcd.setCursor(1,3);
      lcd.print(">Motor Sicaklik");
        
    if (sdurum > 0)
     {
      lcd.clear();
      sayfa = 4; 
      menu = 6;    
      }

       break;
      case 5:
      
    
      lcd.setCursor(1,0);
      lcd.print(" Dumen Durum");
      lcd.setCursor(1,1);
      lcd.print(" Pil Durumu");
      lcd.setCursor(1,2);
      lcd.print(" Motor Sicaklik");
      lcd.setCursor(1,3);
      lcd.print(">Ayarlar");
        
    if (sdurum > 0)
     {
      lcd.clear();
      sayfa = 5; 
      menu = 6;    
      }
       break;
      case 6:

      
       break;
             
      
      }                   
    }
    
 void sayfalar()
       {
        
    

      while(sayfa == 1)
       {
         iskele = map(analogRead(A3),0,1023,103,-222);
         sancak = map(analogRead(A1),0,1023,0,313);
        lcd.setCursor(1,0);
        lcd.print("Iskele ");
        lcd.setCursor(13,0);
        lcd.print("Sancak ");
        lcd.setCursor(3,1);
        lcd.print(iskele);
        lcd.setCursor(15,1);
        lcd.print(sancak);
        lbgi.drawValue(sancak, 100);
        lbgs.drawValue(iskele, 100);
         if (digitalRead(5) == 1) break;
        }

        while(sayfa == 2)
       { 
        
         if(analogRead(A2) > 510 && analogRead(A2) < 520)
         {
           lcd.setCursor(6,1);
           lcd.print("Ortada");
           lcd.setCursor(6,2);
           lcd.print("        ");   
           lcd.setCursor(12,1);
           lcd.print("   "); 
         }
          if(analogRead(A2) <= 510)
         {
           lcd.setCursor(6,1);
           lcd.print("Iskelede");
           lcd.setCursor(6,2);
           lcd.print("        ");   
         }
          if(analogRead(A2) >= 520)
         {
           lcd.setCursor(6,1);
           lcd.print("Sancakta");
           lcd.setCursor(6,2);
           lcd.print("        ");   
         }
          if(analogRead(A2) == 1023 || analogRead(A2) == 0)
         {
           lcd.setCursor(6,2);
           lcd.print("Alabanda");  
         }
        Serial.println(analogRead(A2));
         
        if (digitalRead(5) == 1) break;
       }
         while(sayfa == 3)
       {
         iskele = map(analogRead(A3),0,1023,103,-222);
         lcd.setCursor(2,1);
         lcd.print("Pil Durumu; %");
         lcd.setCursor(15,1);
         lcd.print(iskele);
         lbgp.drawValue(iskele, 100);
         
        if (digitalRead(5) == 1) break;
       }
         while(sayfa == 4)
       {
         lcd.clear();
        if (digitalRead(5) == 1) break;
       }
         while(sayfa == 5)
       {
         lcd.clear();
        if (digitalRead(5) == 1) break;
       }
        }
    
