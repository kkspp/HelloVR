using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using System;

public class PointController : MonoBehaviour
{
    public Image loading;
    public GameObject Point;
    DatabaseReference reference;
    DatabaseReference userRef;
    void Start()
    {
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://unity-a3597.firebaseio.com/");//경로설정
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://dangen-c1cd9.firebaseio.com/");//경로설정
        reference = FirebaseDatabase.DefaultInstance.RootReference;// ref 인스턴스를 가져온다.
        //reference.SetRawJsonValueAsync(json);

    }
    void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(Point.transform.position, Point.transform.forward * 20.0f, Color.green);
        if (Physics.Raycast(Point.transform.position, Point.transform.forward, out hit, 20.0f))
        {
            loading.fillAmount += (1.0f / 3.0f) * Time.deltaTime;
            if (loading.fillAmount == 1)
            {
                if (GameMenus.isPlayerSelectingMenus)
                {
                    loading.fillAmount = 0;
                    MenuEvents(hit.collider.name);
                    // 만약 플레이어가 스테이지를 선택 중이라면    
                }
                else if (!GameMenus.isPlayerSelectingMenus)
                {
                    loading.fillAmount = 0;
                    LoadStage(hit.collider.name);
                }

                loading.fillAmount = 0;
            }
        }
        else
        {
            loading.fillAmount = 0;
        }
    }
    void LoadStage(string targetName)
    {
        switch (targetName)
        {
            case "Uphill":
                CarPositionInit.selectedStage = (int)CarPositionEnum.StageType.Uphill;
                Debug.Log("uphil");
                break;
            case "Crossroad":
                CarPositionInit.selectedStage = (int)CarPositionEnum.StageType.Crossroad;
                break;
            case "Parking":
                CarPositionInit.selectedStage = (int)CarPositionEnum.StageType.Parking;
                break;
            case "Sudden":
                CarPositionInit.selectedStage = (int)CarPositionEnum.StageType.Sudden;
                break;
            case "Accel":
                CarPositionInit.selectedStage = (int)CarPositionEnum.StageType.Accel;
                break;
            case "WholeStage":
                CarPositionInit.selectedStage = (int)CarPositionEnum.StageType.WholeStage;
                break;
            case "OpenGround":
                break;
            default:
                break;
        }
        if (targetName == "OpenGround")
            UnityEngine.SceneManagement.SceneManager.LoadScene("OpenGround");
        else
            // 이미 상단 case 문에서 포지션을 조정 했으므로, 어떤 스테이지를 Gaze하던 Driving 씬을 불러옵니다. 
            UnityEngine.SceneManagement.SceneManager.LoadScene("Driving");
    }

    // 메뉴 선택하기
    void MenuEvents(string targetName)
    {
        switch (targetName)
        {
            case "NewGame":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Login");
                break;
            case "ToSelectStage":
                UnityEngine.SceneManagement.SceneManager.LoadScene("SelectStage");
                break;
            case "Retry":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Driving");
                break;
            case "SaveNewGame":
                Debug.Log("savve");
                Save();
                UnityEngine.SceneManagement.SceneManager.LoadScene("Login");
                break;
            default:
                break;
        }
        // 변수 재 할당 (false가 기본)
        GameMenus.isPlayerSelectingMenus = false;
    }
    void Save()
    {
        Userdata user = UserdataObject.instance.userdata;
        Debug.Log("name:" + SubmitStudentNumber.name);

        string userJson = JsonUtility.ToJson(user);
        string uphilJson = JsonUtility.ToJson(user.uphil);
        string signalJson = JsonUtility.ToJson(user.signal);
        string accelationJson = JsonUtility.ToJson(user.accelation);
        string parkingJson = JsonUtility.ToJson(user.parking);
        string unexceptedJson = JsonUtility.ToJson(user.unexcepted);
        Debug.Log(user.parking.getSuccess());
        userRef = reference.Child("user").Child(SubmitStudentNumber.name);
        string key = userRef.Child("user").Child(SubmitStudentNumber.name).Push().Key;


        userRef.Child(key).SetRawJsonValueAsync(userJson);
        userRef.Child(key).Child("uphill").SetRawJsonValueAsync(uphilJson);
        userRef.Child(key).Child("signal").SetRawJsonValueAsync(signalJson);
        userRef.Child(key).Child("accelation").SetRawJsonValueAsync(accelationJson);
        userRef.Child(key).Child("parking").SetRawJsonValueAsync(parkingJson);
        userRef.Child(key).Child("unexcepted").SetRawJsonValueAsync(unexceptedJson);

    }
}
