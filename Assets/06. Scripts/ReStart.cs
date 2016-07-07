using UnityEngine;
using System.Collections;

public class ReStart : MonoBehaviour {
    public GameObject restart;
	// Use this for initialization
	void Start () {
        restart.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Pauseclick()
    {
        restart.SetActive(true);
    }
    public void Onclick()
    {
        Time.timeScale = 1;
        restart.SetActive(false);
    }
}
