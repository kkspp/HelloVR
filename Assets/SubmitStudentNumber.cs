using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SubmitStudentNumber : MonoBehaviour
{
    public Button m_Submit;
    public static string name;
    // Use this for initialization
    void Start()
    {
        Button btn = m_Submit.GetComponent<Button>();
        btn.onClick.AddListener(Submit);
        Text text;


    }

    void Submit()
    {
        print("Game Start");
        Debug.Log(name = GameObject.Find("InputStudentNumber").GetComponent<InputField>().text);
        UnityEngine.SceneManagement.SceneManager.LoadScene("SelectStage");

    }
}