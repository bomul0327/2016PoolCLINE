using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPlay : MonoBehaviour {
    public Image fade;
    float fades = 0.0f;
    float time = 0; 

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
