using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BestScore : MonoBehaviour {

    public GameObject bestScore;
    private InGameScore inGameScoreInst;//인게임 스코어를 받아오기 위한 변수
    public Text textscore;
    private int inGameScore = 0;//인게임 스코어를 받아와서 베스트 스코어랑 비교
    private int total;
    private int best;

	void Start () {
        inGameScoreInst = GameObject.Find("Score").GetComponent<InGameScore>();
        if (SceneManager.GetActiveScene().name == "InGameScene")
        {
            bestScore.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            bestScore.SetActive(true);
        }
        inGameScore = PlayerPrefs.GetInt("TotalScore", inGameScoreInst.totalScore);
        best = PlayerPrefs.GetInt("BestScore",total);       
	}	
	
	void Update () {
     
        if (best >= inGameScore)
        {
            PlayerPrefs.SetInt("TotalScore", best);           
            total = best;
            PlayerPrefs.SetInt("BestScore", total);
        }

        else if (best <= inGameScore)
        {
            PlayerPrefs.SetInt("TotalScore",inGameScore);
            total = inGameScore;
            PlayerPrefs.SetInt("BestScore", total);
        }   

    
        if (SceneManager.GetActiveScene().name == "InGameScene")
        {
            textscore.text = "BEST\n" + total.ToString();
        }
        else if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            textscore.text = "BEST\n" + total.ToString();
        }
	}

    public void PauseClick()
    {

        bestScore.SetActive(true);            
    }

    public void PauseClose()
    {
        bestScore.SetActive(false);
    } 
    
}
