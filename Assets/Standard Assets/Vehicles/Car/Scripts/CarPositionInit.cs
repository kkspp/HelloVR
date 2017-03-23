using UnityEngine;
using System.Collections;

public class CarPositionInit : MonoBehaviour {

	public static int selectedStage;

	void Awake(){
		SetCarPosition (selectedStage);
	}
	
	void SetCarPosition(int p){
		switch (p) {
		case (int)CarPositionEnum.StageType.Uphill:
			transform.position = CarPositionVectors.uphillPosition;
			transform.rotation = Quaternion.Euler (CarPositionVectors.uphillRotation);
			print ("uphill");
			break;
		case (int)CarPositionEnum.StageType.Crossroad:
			transform.position = CarPositionVectors.crossroadPosition;
			transform.rotation = Quaternion.Euler (CarPositionVectors.crossroadRotation);
			print ("uphill");
			break;
		case (int)CarPositionEnum.StageType.Parking:
			transform.position = CarPositionVectors.parkingPosition;
			transform.rotation = Quaternion.Euler (CarPositionVectors.parkingRotation);
			print ("park");
			break;
		case (int)CarPositionEnum.StageType.Sudden:
			transform.position = CarPositionVectors.suddenPosition;
			transform.rotation = Quaternion.Euler (CarPositionVectors.suddenRotation);
			print ("uphill");
			break;
		case (int)CarPositionEnum.StageType.Accel:
			transform.position = CarPositionVectors.accelPosition;
			transform.rotation = Quaternion.Euler (CarPositionVectors.accelRotation);
			print ("uphill");
			break;
		case (int)CarPositionEnum.StageType.WholeStage:
			transform.position = CarPositionVectors.wholestagePosition;
			transform.rotation = Quaternion.Euler (CarPositionVectors.wholestageRotation);
			print ("uphill");
			break;
		default:
			break;
		}
	}
}
