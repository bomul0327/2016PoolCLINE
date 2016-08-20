using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BestScore : MonoBehaviour {

    public GameObject bestScore;
    private InGameScore Ingamescore;//인게임 스코어를 받아오기 위한 변수
    public Text textscore;
    private int inGameScore = 0;//인게임 스코어를 받아와서 베스트 스코어랑 비교
    private int total;
    private int best;

	void Start () {
        Ingamescore = GameObject.Find("Score").GetComponent<InGameScore>();
        if (SceneManager.GetActiveScene().name == "HBJ_PracticeScene")
        {
            bestScore.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            bestScore.SetActive(true);
        }
        inGameScore = PlayerPrefs.GetInt("TOTAL_SCORE", Ingamescore.totalScore);
        best = PlayerPrefs.GetInt("Best_SCORE",total);       
	}	
	
	void Update () {
     
        if (best >= inGameScore)
        {
            PlayerPrefs.SetInt("TOTAL_SCORE", best);           
            total = best;
            PlayerPrefs.SetInt("Best_SCORE", total);
        }

        else if (best <= inGameScore)
        {
            PlayerPrefs.SetInt("TOTAL_SCORE",inGameScore);
            total = inGameScore;
            PlayerPrefs.SetInt("Best_SCORE", total);
        }   

    
        if (SceneManager.GetActiveScene().name == "HBJ_PracticeScene")
        {
            textscore.text = " Best <color=0000>" + "\n" + total.ToString() + "</color>";
        }
        else if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            textscore.text = " Best <color=#000000>" + "\n" + total.ToString() + "</color>";
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
