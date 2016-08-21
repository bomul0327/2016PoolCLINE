using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameOverBack : MonoBehaviour {

    private InGameScore inGameScore;
	// Use this for initialization
	void Start () {
        inGameScore = GameObject.Find("Score").GetComponent<InGameScore>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnClick()//로고화면으로돌아가기
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void OnGameOver()//스코어 저장하고 게임 오버씬으로 전환
    {
        inGameScore.ScoreSave();
        SceneManager.LoadScene(2);

    }
}
