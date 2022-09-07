
#include <MPU6050_tockn.h>
#include <Wire.h>

#define pinLedX 12
#define pinLedY 11
#define pinLedZ 10


#define MPU6050_ADDR         0x68 // PIN AD0 to GND
//#define MPU6050_ADDR         0x69 // PIN AD0 to VCC


#define DEBUG
MPU6050 mpu6050(Wire);

// Variables  
float anguloX;
float anguloY;
float anguloZ;

unsigned long controleTempo;

void setup() {
  Serial.begin(9600);
  
  Wire.begin();
  mpu6050.begin();
  mpu6050.calcGyroOffsets(true);

  pinMode(pinLedX,OUTPUT);
  pinMode(pinLedY,OUTPUT);
  pinMode(pinLedZ,OUTPUT);

  
  #ifdef DEBUG
    Serial.println("End Setup");
  #endif  
}

void loop() {
  mpu6050.update();
  
  anguloX = mpu6050.getAngleX();
  anguloY = mpu6050.getAngleY();
  anguloZ = mpu6050.getAngleZ();

}


