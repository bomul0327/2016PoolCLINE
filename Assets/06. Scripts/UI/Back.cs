using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour {
    public GameObject back; //Pause 버튼 터치시 뒤로가기 위한 변수

	void Start () {
       back.SetActive(false);
	}
	
	
	void Update () {
	
	}
    public void PauseClick()
    {
        back.SetActive(true);
    }
    public void OnClick() //로고 씬으로 돌아가는 버튼
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void PauseClose()
    {
        back.SetActive(false);
    }
}
