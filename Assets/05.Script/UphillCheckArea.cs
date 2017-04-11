using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Vehicles.Car{					// CarContoller 스크립트에 접근하기 위해서 Asset.Vehicles.Car 네임스페이스를 공유합니다
	[RequireComponent(typeof (CarController))]				// CarController 컴포넌트를 받아옵니다.
	public class UphillCheckArea : MonoBehaviour {
		public CarPositionInit carPositionInit;
		public GameObject timeLeft;
		private TextMesh timeLeftText;
		private const float UPHILL_MAX_SPEED_LIMIT = 20.0f;
		private const float UPHILL_MIN_SPEED_LIMIT = 0.1f; 	// 속력은 0에 수렴 할 뿐 완벽한 0이 될 수 없으므로 float형으로 민감도를 결정합니다. [권장: 0.0~0.1]
		private const int WARN_MAX_SPEED = 0;               // Warn() 함수에서 파라미터에 들어갈 상수입니다. [0: 과속, ...]
		float Times = 3f;
		CarController m_CarController;						// CarController 내에 있는 멤버 변수들을 받아오기 위해
		GameObject m_Car;									// 실제 운전하는 Car 오브젝트						
        public GameManager gameManager;

		void Awake() {
			GetComponents ();								// 컴포넌트들을 받아옵니다.

		}

		//경사로 구간 진입
		void OnTriggerEnter(Collider other)
		{
            if (other.tag == "Player")
            {
                GameManager.instance.currentStage = 1;

                if (GameManager.instance.currentStage != GameManager.instance.pastStage + 1
                    && GameManager.instance.choiceFullCourseStage == true)
                {
                    Debug.Log("currentStage" + GameManager.instance.currentStage + "past" + GameManager.instance.pastStage);
                    gameManager.GetComponent<GameManager>().SendMessage("WrongPath");
                }
                else
                {
                    GameManager.instance.pastStage = 1;
                }

                print("3초동안 정지하세요");
                // 남은시간 UI키 
                timeLeft.SetActive(true);
            }

		}

		void OnTriggerStay(Collider other)					// 경사로 위에 올라가면 ? (수민이 형꺼랑 통일 (collider.bounds.contains 사용 안하기로))
		{
			// 포함한 오브젝트의 태그가 Player(자동차)이고 경사로를 합격못했으면!
			if (other.tag == "Player" && !GameManager.instance.isPlayerPassedUphill) {
				if (this.m_CarController.CurrentSpeed < UPHILL_MIN_SPEED_LIMIT)
				{
					Times -= Time.deltaTime;
					timeLeftText.text = "남은 시간: " + Times.ToString("N1"); // 남 은 시 간 텍 스 트 로 표 시 



					Debug.Log(Times);
					if (Times <= 0) //3초를 멈췄으면!
					{
						print("경사로 구간 정차 완료");
						GameManager.instance.isPlayerPassedUphill = true;                  // 경사로테스트 합격
						timeLeft.SetActive (false); // 남 은 시 간 숨 기 기 

					}
				}
			}
		}

		void OnTriggerExit(Collider other)
		{
			if (other.tag == "Player" && GameManager.instance.isPlayerPassedUphill == false)
			{
				print(carPositionInit.isPlayerDoingWholeStage);
				GameManager.instance.SuccessSound = false;
				GameMenus.resultText = "경사로구간 실격입니다!";
				GameMenus.isPlayerSelectingMenus = true;
				SceneManager.LoadScene("MenusWhenPlayerFails");//실격처리

			}

			if (!carPositionInit.isPlayerDoingWholeStage && other.tag == "Player" && GameManager.instance.isPlayerPassedUphill == true)
			{
				GameManager.instance.SuccessSound = true;
				GameMenus.resultText = "합격입니다.경사로구간 연습이 종료되었습니다!";
				GameMenus.isPlayerSelectingMenus = true;
				SceneManager.LoadScene("MenusWhenPlayerFails");
			}
			if (other.tag == "Player" && GameManager.instance.isPlayerPassedUphill == true)
			{
				GameManager.instance.SendMessage("playSound");
			}
		}

		void GetComponents(){
			this.m_Car = GameObject.Find ("Car");
			this.m_CarController = m_Car.GetComponent<CarController> ();
			timeLeftText = timeLeft.GetComponentInChildren<TextMesh>();
			timeLeft.SetActive (false);
		}


	}
}