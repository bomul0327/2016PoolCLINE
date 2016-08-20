using UnityEngine;
using System.Collections;

public class ReStart : MonoBehaviour {
    public GameObject restart;
	
	void Start () {
        restart.SetActive(false);
	}	

	void Update () {
	
	}
    public void PauseClick()
    {
        restart.SetActive(true);
    }
    public void OnClick()
    {
        Time.timeScale = 1;
        restart.SetActive(false);
    }
}
