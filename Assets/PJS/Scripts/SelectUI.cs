using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class SelectUI : MonoBehaviour
{
    //���� ��ư�� ������ �� �ַθ��, �ڿɸ��(���� �߰� ����) ���� ����
    //�ַθ�忡 Ŀ���� ������ �� ��� �ְ������� ����

    [SerializeField] private TextMeshProUGUI BestScoreText;

    private void Start()
    {
        LoadBestScore();
    }


    private void LoadBestScore()
    {
        int BestScore = PlayerPrefs.GetInt("BestScore", 0); // ����� �ְ� ������ �ҷ��ɴϴ�. ������ 0�� ��ȯ�մϴ�.
        BestScoreText.text = "Best Score: " + BestScore; // �ְ� ������ UI Text�� ǥ���մϴ�.
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
