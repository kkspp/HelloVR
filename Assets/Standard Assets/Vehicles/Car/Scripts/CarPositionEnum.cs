using UnityEngine;
using System.Collections;


public class CarPositionEnum : MonoBehaviour {

	public enum StageType { // 경사로 교차로 직각 돌발 가속 전체
		Uphill = 0,
		Crossroad,
		Parking,
		Sudden,
		Accel,
		WholeStage,
	}
}	