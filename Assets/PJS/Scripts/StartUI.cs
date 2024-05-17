using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void StartBtn()
    {
        //시작 버튼을 눌렀을 때 솔로모드, 코옵모드(차후 추가 가능) 선택 가능, 솔로모드에 커서를 가져다 댈 경우 최고점수가 보임
        SceneManager.LoadScene("SelectScene");
    }

    public void ExitBtn()
    {
        //게임 종료
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit(); 최종버전
    }
}
