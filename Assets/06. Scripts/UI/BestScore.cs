using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BestScore : MonoBehaviour {

    public GameObject Bestscore;
    private InGameScore Ingamescore;
    public Text textscore;
    private int bestscore = 0;
    private int total;

	void Start () {
        Ingamescore = GameObject.Find("Score").GetComponent<InGameScore>();
        if (SceneManager.GetActiveScene().name == "HBJ_PracticeScene")
        {
            Bestscore.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            Bestscore.SetActive(true);
        }
        bestscore = PlayerPrefs.GetInt("TOTAL_SCORE", Ingamescore.totalscore);

	}	
	
	void Update () {
        int temp = PlayerPrefs.GetInt("TOTAL_SCORE");
        //  Debug.Log(temp);
        if (temp >= bestscore)
        {
            PlayerPrefs.SetInt("TOTAL_SCORE", temp);
            bestscore = temp;
        }

        else if (temp <= bestscore)
        {
            PlayerPrefs.SetInt("TOTAL_SCORE", bestscore);
        }

        total = PlayerPrefs.GetInt("TOTAL_SCORE");
        if (SceneManager.GetActiveScene().name == "HBJ_PracticeScene")
        {
            textscore.text = " Best <color=0000>" + "\n" + total.ToString() + "</color>";
        }
        else if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            textscore.text = " Best <color=#000000>" + "\n" + total.ToString() + "</color>";
        }
	}

    public void Pauseclick()
    {

        Bestscore.SetActive(true);            
    }

    public void PauseClose()
    {
        Bestscore.SetActive(false);
    } 
    
}
