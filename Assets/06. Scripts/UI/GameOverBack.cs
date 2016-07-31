using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameOverBack : MonoBehaviour {
    public GameObject Back;
    private InGameScore ingamescore;
	// Use this for initialization
	void Start () {
        ingamescore = GameObject.Find("Score").GetComponent<InGameScore>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void OnGameOver()
    {
        ingamescore.ScoreSave();
        SceneManager.LoadScene(2);

    }
}
