using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    public GameObject pause;
    private GameManager gamemanager;

	// Use this for initialization
	void Start () {
        gamemanager = GameObject.Find("Main Camera").GetComponent<GameManager>();        
        gamemanager.IsPaused = false;
        Debug.Log(gamemanager.IsPaused);
	}
	
	// Update is called once per frame
	void Update () {
    
	}
    public void PauseClick()//pause클릭 했을 때 
    {
        pause.SetActive(false);
        Time.timeScale = 0.0f;   
        gamemanager.IsPaused = true;
        Debug.Log(gamemanager.IsPaused);
    }
    public void PauseClose()//pause 닫았을 때
    {
        pause.SetActive(true);
        gamemanager.IsPaused = false;
        Debug.Log(gamemanager.IsPaused);
    }

  
}
