using UnityEngine;
using System.Collections;

public class Blockpause : MonoBehaviour {
    public GameObject block;
	// Use this for initialization
	void Start () {
        block.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void pauseOn()
    {
        block.SetActive(false);
   
    }
    public void pauseclose()
    {
        block.SetActive(true);

    }
}
