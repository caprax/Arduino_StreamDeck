#include <Keypad.h>
//Keypad setup
const byte SATIR = 4;
const byte SUTUN= 3;
char keys[SATIR][SUTUN] = {
{'1','2','3'},
{'4','5','6'},
{'7','8','9'},
{'*','0','#'}
};
byte rowPins[SATIR] = { 9, 8, 7, 6 };
byte colPins[SUTUN] = { 12, 11, 10 };
Keypad kpd = Keypad( makeKeymap(keys), rowPins, colPins, SATIR, SUTUN );
//SerialPort Setup
String receivedData = "";
bool flag = false;
//Serial Input Check
void serialEvent()
{
  while (Serial.available())
  {
    
    char inChar = (char)Serial.read();
    receivedData += inChar;
    if(inChar == '\n')
    {
      flag = 1;
    }
  }
}
//Connection test function
void waitfor(){
  char hash = '#';
  if (Serial.find(hash))
  {
    flag = 1;
  }
  else{flag = 0;
  Serial.println('#');}
}
void setup()
{
  
  pinMode(13,OUTPUT);
  Serial.begin(9600);
  receivedData.reserve(4);
//Connection Test
while (flag == 0) {
  digitalWrite(13,1);
    waitfor();
  }
  digitalWrite(13,0);
  flag = 0;
}

void loop()
{
  char key = kpd.getKey();
  if(key)
  {
    Serial.println(key);
    
  }
//  if (flag == 1)
//  {
//    Serial.println(receivedData);
//    flag = false;
//  }
  
}


