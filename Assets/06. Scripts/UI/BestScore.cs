using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BestScore : MonoBehaviour {

    public GameObject Bestscore;
    private InGameScore Ingamescore;
    public Text textscore;
    private int InGameScore = 0;
    private int total;
    private int Best;

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
        InGameScore = PlayerPrefs.GetInt("TOTAL_SCORE", Ingamescore.totalscore);
        Best = PlayerPrefs.GetInt("Best_SCORE",total);       
	}	
	
	void Update () {
     
        if (Best >= InGameScore)
        {
            PlayerPrefs.SetInt("TOTAL_SCORE", Best);           
            total = Best;
            PlayerPrefs.SetInt("Best_SCORE", total);
        }

        else if (Best <= InGameScore)
        {
            PlayerPrefs.SetInt("TOTAL_SCORE", InGameScore);
            total = InGameScore;
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

    public void Pauseclick()
    {

        Bestscore.SetActive(true);            
    }

    public void PauseClose()
    {
        Bestscore.SetActive(false);
    } 
    
}
