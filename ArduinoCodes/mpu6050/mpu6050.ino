 #include<Wire.h>
const int MPU=0x68; 
int16_t AcX,AcY,AcZ,Tmp,GyX,GyY,GyZ;

void setup(){
  Wire.begin();
  Wire.beginTransmission(MPU);
  Wire.write(0x6B); 
  Wire.write(0);    
  Wire.endTransmission(true);
  Serial.begin(9600);
}
void loop(){
  Wire.beginTransmission(MPU);
  Wire.write(0x3B);  
  Wire.endTransmission(false);
  Wire.requestFrom(MPU,12,true);  
  AcX=Wire.read()<<8|Wire.read();    
  AcY=Wire.read()<<8|Wire.read();  
  AcZ=Wire.read()<<8|Wire.read();  
  GyX=Wire.read()<<8|Wire.read();  
  GyY=Wire.read()<<8|Wire.read();  
  GyZ=Wire.read()<<8|Wire.read();  

  AcX = map(AcX, -20000, 20000, -99, 99);
  AcY = map(AcY, -20000, 20000, -99, 99);
  AcZ = map(AcZ, -20000, 20000, -99, 99);
 
  GyX = map(GyX, -20000, 20000, -99, 99);
  GyY = map(GyY, -20000, 20000, -99, 99);
  GyZ = map(GyZ, -20000, 20000, -99, 99);

  
  Serial.print(AcX); Serial.print(",");
  Serial.print(AcY); Serial.print(",");
  Serial.print(AcZ); Serial.print(",");

  Serial.print(GyX); Serial.print(",");
  Serial.print(GyY); Serial.print(",");
  Serial.print(GyZ); 
  Serial.println("");
  Serial.flush();
  delay(25);
 
  
}
