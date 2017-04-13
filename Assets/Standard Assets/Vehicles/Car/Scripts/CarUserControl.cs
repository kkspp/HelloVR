using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        //LogitechSteeringWheel test = GameObject.Find("Car").GetComponent<LogitechSteeringWheel>();
        public float wheelAngle = 0;
		public int gearState = 1;
        public void getWheelAngle(float angle)
        {
            wheelAngle = angle;
        }

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            
        }

		public void SetGearState(int gearStateNum)
		{
			this.gearState = gearStateNum;
		}

        private void FixedUpdate()
        {
            float h=0, v=0, b=0;


            // pass the input to the car!
            // 속 력 을 프 린 트 하 기 
            //			print(m_Car.CurrentSpeed);
            //			print(m_Car.CurrentSteerAngle);

            // 이부분부터 키보드
            //h = CrossPlatformInputManager.GetAxis("Horizontal");
            //v = CrossPlatformInputManager.GetAxis("Vertical");

			h = Input.GetAxis ("Horizontal");
			v = Input.GetAxis ("Vertical");
			Debug.Log (v);

			if (Input.GetKeyDown (KeyCode.B)) {
				b = 0.99f;
			} else if (Input.GetKeyUp (KeyCode.B)) {
				b = 0;
			}

            // 이부분까지 키보드  
             

			/*
            //이부분부터 Joystick
            //h = CrossPlatformInputManager.GetAxis("HorizontalJoystick");
            h = wheelAngle/32767;
            v = (CrossPlatformInputManager.GetAxis("VerticalJoystick") + 1 ) /2 ;
            b = (CrossPlatformInputManager.GetAxis("BreakJoystick") + 1 ) /2 ;

			*/
            //Debug.Log(h);
            
            //여기까지 Joystick

			v = gearState * v;

#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, b, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
