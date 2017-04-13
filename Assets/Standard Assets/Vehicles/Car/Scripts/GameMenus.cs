using UnityEngine;
using System.Collections;

public class GameMenus : MonoBehaviour {
	// 플레이어가 메뉴를 선택 중입니까?
	public static bool isPlayerSelectingMenus = false;
    //오르막길일 경우 브레이크 다르게 구현하기 위한 변수. CarController 스크립트 관련.
    
    public static bool uphill;

	// 메뉴 선택 시 보여줄 텍스트 내용
	public static string resultText = "";

    // 현재 어떤 스테이지인지
    void SetStageUphill(bool isUphill)
    {
        uphill = isUphill;
    }
}
