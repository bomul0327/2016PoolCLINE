using UnityEngine;
using System.Collections;

public class InGameScore : MonoBehaviour {
    public GameObject InGamescore;
	// Use this for initialization
	void Start () {
        InGamescore.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Pauseclick()
    {
        InGamescore.SetActive(false);
    }
    public void Restartclick()
    {
        InGamescore.SetActive(true);
    }
}
