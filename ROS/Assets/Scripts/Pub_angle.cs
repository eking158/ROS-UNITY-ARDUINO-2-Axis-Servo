/*
© Siemens AG, 2017-2018
Author: Dr. Martin Bischoff (martin.bischoff@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class Pub_angle : UnityPublisher<MessageTypes.Geometry.Twist>
    {
        public Transform servo_1, servo_2;
        int Angle_1, Angle_2;

        private MessageTypes.Geometry.Twist message;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void FixedUpdate()
        {
            UpdateMessage();
        }

        private void InitializeMessage()
        {
            message = new MessageTypes.Geometry.Twist();
        }
        private void UpdateMessage()
        {

            Angle_1 = (int)servo_1.transform.localEulerAngles.y;
            Angle_2 = (int)servo_2.transform.localEulerAngles.z;
            Debug.Log("servo1: "+Angle_1+" "+ "servo2: " + Angle_2 + " " );
           
            message.angular.y=Angle_2;
            message.angular.z=Angle_1;
            Publish(message);
        }
    }
}
