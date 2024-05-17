using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class SelectUI : MonoBehaviour
{
    //시작 버튼을 눌렀을 때 솔로모드, 코옵모드(차후 추가 가능) 선택 가능, 솔로모드에 커서를 가져다 댈 경우 최고점수가 보임

    public void SoloModeBtn()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void CoOpBtn()
    {

    }

    public void StartSceneBtn()
    {
        SceneManager.LoadScene("StartScene");
    }

    

}
