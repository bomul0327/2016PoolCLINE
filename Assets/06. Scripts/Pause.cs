﻿using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
  
	// Use this for initialization
	void Start () {	
     
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void Pauseclick()
    {
            Time.timeScale = 0.0f;        
    }
  
}