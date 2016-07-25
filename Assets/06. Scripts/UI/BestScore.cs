using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BestScore : MonoBehaviour {

    public GameObject score;

    public Text textscore;
    private int bestscore=0;
	
	void Start () {
        score.SetActive(false);
        bestscore = PlayerPrefs.GetInt("TOTAL_SCORE");   
	}	
	
	void Update () {
        
	}

    public void Pauseclick()
    {

        int temp = PlayerPrefs.GetInt("TOTAL_SCORE");
        Debug.Log(temp);

        score.SetActive(true);
        if (temp >= bestscore)
        {
            PlayerPrefs.SetInt("TOTAL_SCORE", temp);
            bestscore = temp;
        }

        else if (temp <= bestscore)
        {
            PlayerPrefs.SetInt("TOTAL_SCORE", bestscore);
        }

        int total = PlayerPrefs.GetInt("TOTAL_SCORE");       
        textscore.text = "Best <color=0000>" + "\n" + total.ToString() + "</color>";        
    }

    public void PauseClose()
    {
        score.SetActive(false);
    } 
    
}
