using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIPlay : MonoBehaviour {
    public UnityEngine.UI.Image fade;
    float fades = 0.0f;
    float time = 0; 
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (fades >= 0.0f && time >= 2.0f)
        {
            fades += 0.1f;
            fade.color = new Color(255, 0, 0, fades);
            time = 2;
        }
        else if (fades >= 1.0f)
        {
            time = 0;

        }
    }
    public void PlayClick()
    {
        SceneManager.LoadScene(3);
    }
}
