using UnityEngine;
using System.Collections;

public class CarPositionInit : MonoBehaviour
{
    public bool isPlayerDoingWholeStage;
    public static int selectedStage;
    public GameObject vr_Camera;

    public enum CurrentSectionNumbers
    {
        Uphill = 0,
        Crossroad,
        Parking,
        Unexpected,
        Accel,
    }



    void Start()
    {
        SetCarPosition(selectedStage);
    }

    void SetCarPosition(int p)
    {
        switch (p)
        {
            case (int)CarPositionEnum.StageType.Uphill:
                isPlayerDoingWholeStage = false;
                GameManager.instance.choiceFullCourseStage = false;
                transform.position = CarPositionVectors.uphillPosition;
                transform.rotation = Quaternion.Euler(CarPositionVectors.uphillRotation);
                break;
            case (int)CarPositionEnum.StageType.Crossroad:
                isPlayerDoingWholeStage = false;
                GameManager.instance.choiceFullCourseStage = false;
                transform.position = CarPositionVectors.crossroadPosition;
                transform.rotation = Quaternion.Euler(CarPositionVectors.crossroadRotation);
                break;
            case (int)CarPositionEnum.StageType.Parking:
                isPlayerDoingWholeStage = false;
                GameManager.instance.choiceFullCourseStage = false;
                transform.position = CarPositionVectors.parkingPosition;
                transform.rotation = Quaternion.Euler(CarPositionVectors.parkingRotation);
                break;
            case (int)CarPositionEnum.StageType.Sudden:
                isPlayerDoingWholeStage = false;
                GameManager.instance.choiceFullCourseStage = false;
                transform.position = CarPositionVectors.suddenPosition;
                transform.rotation = Quaternion.Euler(CarPositionVectors.suddenRotation);
                break;
            case (int)CarPositionEnum.StageType.Accel:
                isPlayerDoingWholeStage = false;
                GameManager.instance.choiceFullCourseStage = false;
                transform.position = CarPositionVectors.accelPosition;
                transform.rotation = Quaternion.Euler(CarPositionVectors.accelRotation);
                break;
            case (int)CarPositionEnum.StageType.WholeStage:
                isPlayerDoingWholeStage = true;
                GameManager.instance.choiceFullCourseStage = true;
                transform.position = CarPositionVectors.wholestagePosition;
                transform.rotation = Quaternion.Euler(CarPositionVectors.wholestageRotation);
                break;
            default:
                break;
        }

        vr_Camera.transform.rotation = transform.rotation;
    }
}
