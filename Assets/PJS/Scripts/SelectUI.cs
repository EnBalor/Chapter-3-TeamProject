using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class SelectUI : MonoBehaviour
{
    //시작 버튼을 눌렀을 때 솔로모드, 코옵모드(차후 추가 가능) 선택 가능
    //솔로모드에 커서를 가져다 댈 경우 최고점수가 보임

    [SerializeField] private TextMeshProUGUI BestScoreText;

    private void Start()
    {
        LoadBestScore();
    }


    private void LoadBestScore()
    {
        int BestScore = PlayerPrefs.GetInt("BestScore", 0); // 저장된 최고 점수를 불러옵니다. 없으면 0을 반환합니다.
        BestScoreText.text = "Best Score: " + BestScore; // 최고 점수를 UI Text에 표시합니다.
    }

    public void SoloModeBtn()
    {
        SceneManager.LoadScene("PlayerTestScene");
    }

    public void CoOpBtn()
    {

    }

    public void StartSceneBtn()
    {
        SceneManager.LoadScene("StartScene");
    }

    

}
