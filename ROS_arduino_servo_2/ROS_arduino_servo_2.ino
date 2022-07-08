/*
 * rosserial Servo Control Example
 *
 * This sketch demonstrates the control of hobby R/C servos
 * using ROS and the arduiono
 * 
 * For the full tutorial write up, visit
 * www.ros.org/wiki/rosserial_arduino_demos
 *
 * For more information on the Arduino Servo Library
 * Checkout :
 * http://www.arduino.cc/en/Reference/Servo
 */

#if (ARDUINO >= 100)
 #include <Arduino.h>
#else
 #include <WProgram.h>
#endif

#include <Servo.h> 
#include <ros.h>
#include <geometry_msgs/Twist.h>

ros::NodeHandle  nh;

Servo servo1, servo2;

void servo_cb( const geometry_msgs::Twist& angle_msg){
  int angle1=angle_msg.angular.z;
  int angle2=angle_msg.angular.y;
  angle1=map(angle1,90,270,120,0);
  angle2=map(angle2,90,270,120,0);
  angle1=constrain(angle1,0,120);
  angle2=constrain(angle2,0,120);
  servo1.write(angle1);
  servo2.write(angle2);
  digitalWrite(13, HIGH-digitalRead(13));  //toggle led  
}


ros::Subscriber<geometry_msgs::Twist> sub("arduino_servo", servo_cb);

void setup(){
  pinMode(13, OUTPUT);

  nh.initNode();
  nh.subscribe(sub);
  servo1.attach(8);
  servo2.attach(9); //attach it to pin 9
}

void loop(){
  nh.spinOnce();
  delay(1);
}
