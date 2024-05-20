using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
   
    public void StartBtn()
    {
       
        SceneManager.LoadScene("SelectScene");
    }

    public void ExitBtn()
    {
        //게임 종료
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit(); 최종버전
    }
}
