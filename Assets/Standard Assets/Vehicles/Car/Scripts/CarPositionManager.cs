using UnityEngine;
using System.Collections;

public class CarPositionManager : MonoBehaviour {
	private static CarPositionManager _instance;
	public static CarPositionManager Instance {
		get {
			if (_instance == null) {
				GameObject go = new GameObject ("CarPositionManager");
				go.AddComponent <CarPositionManager>();
			}
			return _instance;
		}
	}
	public int SelectedStage;	// 이 변수는 게임이 돌아가는 내내 현재 어떤 스테이지를 담고있습니다. CarPositionEnum.cs 참고
	void Awake(){
		_instance = this;
	}
}
