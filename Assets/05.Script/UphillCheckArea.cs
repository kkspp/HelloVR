using UnityEngine;

using System.Collections;

namespace UnityStandardAssets.Vehicles.Car{					// CarContoller 스크립트에 접근하기 위해서 Asset.Vehicles.Car 네임스페이스를 공유합니다
	[RequireComponent(typeof (CarController))]				// CarController 컴포넌트를 받아옵니다.
	public class UphillCheckArea : MonoBehaviour {
        
        private const float UPHILL_MAX_SPEED_LIMIT = 20.0f;
		private const float UPHILL_MIN_SPEED_LIMIT = 0.1f; 	// 속력은 0에 수렴 할 뿐 완벽한 0이 될 수 없으므로 float형으로 민감도를 결정합니다. [권장: 0.0~0.1]
		private const int WARN_MAX_SPEED = 0;               // Warn() 함수에서 파라미터에 들어갈 상수입니다. [0: 과속, ...]
        float Times;
		CarController m_CarController;						// CarController 내에 있는 멤버 변수들을 받아오기 위해
		GameObject m_Car;									// 실제 운전하는 Car 오브젝트						
		BoxCollider m_BoxCol;								// 경사로에 자동차가 있는지 체크하기 위한 BoxCollider

		private float m_TimeLimit = 3.0f;					// 정지 시간
		private bool m_IsPlayerPassedUphill = false;		// 경사로 구간을 성공/실패 유무에 상관 없이 한번의 기능 시험동안 1회만 체크하도록 boolean 변수 선언

		void Awake() {
			GetComponents ();								// 컴포넌트들을 받아옵니다.

		}

        void OnTriggerEnter(Collider other)
        {
            print("3초동안 정지하세요");
        }
        void OnTriggerStay(Collider other)					// 경사로 위에 올라가면 ? (수민이 형꺼랑 통일 (collider.bounds.contains 사용 안하기로))
		{
			if (other.tag == "Player" && !m_IsPlayerPassedUphill) {		// 포함한 오브젝트의 태그가 Player(자동차)이고 경사로를 합격못했으면!
				CheckVelocity ();										// 속력을 체크합니다.
                if (this.m_CarController.CurrentSpeed < UPHILL_MIN_SPEED_LIMIT)
                {
                    Times += Time.deltaTime;
                    Debug.Log(Times);
                    if (Times >= 3) //3초를 멈췄으면!
                    {
                        print("경사로 구간 정차 완료");
                        this.m_IsPlayerPassedUphill = true;                  // 경사로테스트 합격
                    }
                    
                }
			}
		}
        void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player" && this.m_IsPlayerPassedUphill == false)
            GameObject.Find("GameManager").SendMessage("UphillFail");
        }

        void CheckVelocity(){
			if (this.m_CarController.CurrentSpeed >= UPHILL_MAX_SPEED_LIMIT) {			// 만약 최대 속력보다 크면 ?		
				Warn (WARN_MAX_SPEED);													// Warn() 함수 실행 (최대 속력 경고)
			} 
		}

		void Warn(int WARN_CODE){	
			switch (WARN_CODE) {
			case WARN_MAX_SPEED:
				print("20km/h를 넘어서 실패하였습니다");
				GameObject.Find("GameManager").SendMessage("UphillFail");		// 스코어를 업데이트 하기위한 SendMessage
				this.m_IsPlayerPassedUphill = true;								// 이미 경사로 테스트를 응시하였습니다.
				break;
			}
		}

		void GetComponents(){
			this.m_BoxCol = GetComponent<BoxCollider> ();
			this.m_Car = GameObject.Find ("Car");
			this.m_CarController = m_Car.GetComponent<CarController> ();
		}

		
	}
}