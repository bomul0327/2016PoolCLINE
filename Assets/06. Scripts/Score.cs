using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
    public GameObject score;
	// Use this for initialization
	void Start () {
        score.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void Pauseclick()
    {
        score.SetActive(true);
    }
    public void PauseClose()
    {
        score.SetActive(false);
    }
}
