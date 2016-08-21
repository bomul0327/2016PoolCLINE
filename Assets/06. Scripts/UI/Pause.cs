using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    public GameObject pause;
    private GameManager gameManager;

	void Start () {
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();        
        gameManager.IsPaused = false;
	}
	
	void Update () {
    
	}
    public void PauseClick()//pause클릭 했을 때 
    {
        pause.SetActive(false);
        Time.timeScale = 0.0f;   
        gameManager.IsPaused = true;
    }
    public void PauseClose()//pause 닫았을 때
    {
        pause.SetActive(true);
        gameManager.IsPaused = false;
    }

  
}
