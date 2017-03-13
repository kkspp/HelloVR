using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Vehicles.Car{					// CarContoller 스크립트에 접근하기 위해서 Asset.Vehicles.Car 네임스페이스를 공유합니다
	[RequireComponent(typeof (CarController))]				// CarController 컴포넌트를 받아옵니다.
	public class UphillCheckArea : MonoBehaviour {
		private const float UPHILL_MAX_SPEED_LIMIT = 20.0f;
		private const float UPHILL_MIN_SPEED_LIMIT = 0.1f; 	// 속력은 0에 수렴 할 뿐 완벽한 0이 될 수 없으므로 float형으로 민감도를 결정합니다. [권장: 0.0~0.1]
		private const int WARN_MAX_SPEED = 0;				// Warn() 함수에서 파라미터에 들어갈 상수입니다. [0: 과속, ...]
			
		CarController m_CarController;						// CarController 내에 있는 멤버 변수들을 받아오기 위해
		GameObject m_Car;									// 실제 운전하는 Car 오브젝트						
		BoxCollider m_BoxCol;								// 경사로에 자동차가 있는지 체크하기 위한 BoxCollider

		private float m_TimeLimit = 3.0f;					// 정지 시간
		private bool m_IsPlayerPassedUphill = false;		// 경사로 구간을 성공/실패 유무에 상관 없이 한번의 기능 시험동안 1회만 체크하도록 boolean 변수 선언

		void Awake() {
			GetComponents ();								// 컴포넌트들을 받아옵니다.

		}

		void OnTriggerStay(Collider other)					// 경사로 위에 올라가면 ? (수민이 형꺼랑 통일 (collider.bounds.contains 사용 안하기로))
		{
			if (other.tag == "Player" && !m_IsPlayerPassedUphill) {		// 포함한 오브젝트의 태그가 Player(자동차)이고 경사로를 처음 지나는 상태라면 ?
				CheckVelocity ();										// 속력을 체크합니다.
			}
		}

		void CheckVelocity(){
			if (this.m_CarController.CurrentSpeed >= UPHILL_MAX_SPEED_LIMIT) {			// 만약 최대 속력보다 크면 ?		
				Warn (WARN_MAX_SPEED);													// Warn() 함수 실행 (최대 속력 경고)
			} else if (this.m_CarController.CurrentSpeed < UPHILL_MIN_SPEED_LIMIT) {	// 만약 최소 속력보다 작으면 ?
				print("3초동안 정지하세요");
				StartCoroutine ("CarStopped");											// 코루틴을 실행합니다.
			}
			// 코루틴이 존재하면 코루틴을 중지시켜야 하는 부분이 꼭 필요하므로 
			// 만약 최소 속력보다 크면 항상 코루티는 중지 시키기 위해서 분기 생성
			// 이 분기가 없다면 한번만 속력을 0으로 만들고 출발해 버려도 코루틴이 이미 시작되었으므로 언제나 '합격'하게됌 
			else if (this.m_CarController.CurrentSpeed > UPHILL_MIN_SPEED_LIMIT) {	
				print("3초동안 정지하세요");
				StopCoroutine ("CarStopped");
			}
		}

		void Warn(int WARN_CODE){	
			switch (WARN_CODE) {
			case WARN_MAX_SPEED:
				StopCoroutine ("CarStopped");
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

		IEnumerator CarStopped(){												// 3초를 새기 위한 코루틴
			yield return new WaitForSeconds (this.m_TimeLimit);
			print ("경사로 구간 통과");
			this.m_IsPlayerPassedUphill = true;									// 이미 경사로 테스트를 응시하였습니다.
		}
	}
}