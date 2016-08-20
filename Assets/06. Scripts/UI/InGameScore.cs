using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class InGameScore : MonoBehaviour {

   public Text textScore;
   public int totalScore = 0;
   private int scoreBuffer;

	void Start () {
        if (SceneManager.GetActiveScene().name == "HBJ_PracticeScene")
        {
            DisplayScore(0);
        }
        else if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            DisplayScore(PlayerPrefs.GetInt("SCORE", scoreBuffer));
        }
	}

	void Update () {

	}

    public void ScoreSave()
    {
        PlayerPrefs.SetInt("TOTAL_SCORE", totalScore);
        PlayerPrefs.SetInt("SCORE", scoreBuffer);
    }
    public void DisplayScore(int score)
    {
        totalScore += score;
        textScore.text = totalScore.ToString();
        scoreBuffer += score;
    }
    
}
