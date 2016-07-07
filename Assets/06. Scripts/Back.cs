using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour {
    public GameObject back;
	// Use this for initialization
	void Start () {
        back.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Pauseclick()
    {
        back.SetActive(true);
    }
    public void OnClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void PauseClose()
    {
        back.SetActive(false);
    }
}
