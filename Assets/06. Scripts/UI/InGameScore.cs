using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class InGameScore : MonoBehaviour {

   public Text textscore;
   public int totalscore = 0;
   private int scorebuffer;

	void Start () {
        if (SceneManager.GetActiveScene().name == "HBJ_PracticeScene")
        {
            displayscore(0);
        }
        else if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            displayscore(PlayerPrefs.GetInt("SCORE", scorebuffer));
        }
	}

	void Update () {

	}

    public void ScoreSave()
    {
        PlayerPrefs.SetInt("TOTAL_SCORE", totalscore);
        PlayerPrefs.SetInt("SCORE", scorebuffer);
    }
    public void displayscore(int score)
    {
        totalscore += score;
        textscore.text = totalscore.ToString();
        scorebuffer += score;
    }
    
}
