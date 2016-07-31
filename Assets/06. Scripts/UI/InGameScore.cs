using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class InGameScore : MonoBehaviour {

   public Text textscore;
   public int totalscore;
   private int scorebuffer;

	void Start () {
        if (SceneManager.GetActiveScene().name == "HBJ_PracticeScene")
        {
            displayscore(0);
        }
        else if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            displayscore(PlayerPrefs.GetInt("SCORE",scorebuffer));
        }
	}

	void Update () {
        //bestscore 게임종료가 아직 안나와서 게임 종료대신 임시로 V키를 넣고 V키를 누르면 스코어 저장으로 
        //만들었습니다.
        //게임 종료가 완성되면 그때 다시 수정하면 될 것 같네요.
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("V");
            PlayerPrefs.SetInt("TOTAL_SCORE", totalscore);           
            PlayerPrefs.SetInt("SCORE", scorebuffer);       
           // Time.timeScale = 0;                            
           
        }
	}
    public void Pauseclick()
    {       

    }
    public void Restartclick()
    {
   
  
    }
    public void displayscore(int score)
    {
        totalscore += score;       
        textscore.text = totalscore.ToString();
        scorebuffer += score;
    }
  
    
}
