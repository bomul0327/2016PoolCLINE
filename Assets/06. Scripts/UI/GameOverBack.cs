﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameOverBack : MonoBehaviour {
    public GameObject Back;
	// Use this for initialization
	void Start () {
	
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
        SceneManager.LoadScene(2);
    }
}
