using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public float wheelAngle = 0;
		public int gearState = 1;
        public float accel = 0f;
        public float brake = 0;

        //핸들
        public Transform steeringWheel;


        public void getWheelAngle(float angle)
        {
            wheelAngle = angle;
        }

        public void getAccel(float accel)
        {
            this.accel = Math.Abs(accel-32767) / 65536;
        }
        
        public void getBrake(float brake)
        {
            this.brake = Math.Abs(brake - 32767) / 65536 / 1.5f;
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
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("SelectStage");
            }

            // pass the input to the car!

            /*
            // 이부분부터 키보드
            h = Input.GetAxis ("Horizontal");
			v = Input.GetAxis ("Vertical");;
			if (Input.GetKey (KeyCode.B)) {
				b = 0.55f;
			} else if (Input.GetKeyUp (KeyCode.B)) {
				b = 0;
			}
            else if (Input.GetKey (KeyCode.Escape))
            {
                SceneManager.LoadScene("SelectStage");
            }
            
            // 이부분까지 키보드  
            */

            
            //이부분부터 Joystick

            //로지텍 마우스포커싱 잡다한 버그. 마우스 포커싱을 다른곳으로 하면 accel이 -0.5로 튐.
            if (accel == -0.5)
                accel = 0;

            h = wheelAngle/32767;   //핸들
            v = accel;              //악셀
            b = brake;              //브레이크

            //여기까지 Joystick

            if (Input.GetKey(KeyCode.UpArrow))
            {
                v = 1;
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                v = 0;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                v = -1;
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                v = 0;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                h = 1;
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                h = 0;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                h = -1;
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                h = 0;
            }
            if (Input.GetKey(KeyCode.B))
            {
                b = 0.7f;
            }
            else if (Input.GetKeyUp(KeyCode.B))
            {
                b = 0;
            }



            steeringWheel.transform.localRotation = Quaternion.Euler(h * (-450), 0.0f, 0.0f);

            if ( gearState==-1)
                v = v * (-1);

#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            //m_Car.Move(h, v, b, handbrake);
            m_Car.Move(h, v, b, handbrake, gearState);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
