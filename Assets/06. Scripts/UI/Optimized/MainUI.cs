using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;

public class MainUI : MonoBehaviour {
    [SerializeField]
    private Image playButtonImage;
    [SerializeField]
    private GameObject logo;

    void Start () {
        StartCoroutine(LogoFade());
        StartCoroutine(PlayButtonFade());
    }

    public void OnPlayClick () {        
        SceneManager.LoadScene("InGameScene");
    }

    IEnumerator PlayButtonFade () {
        yield return new WaitForSeconds(2.0f);
        float fade = 0.0f;
        while (fade <= 1.0f) {
            fade += 0.1f;
            playButtonImage.color = new Color(1, 0,0, fade);                      
            yield return null;
        }
    }

    IEnumerator LogoFade () {
        yield return new WaitForSeconds(0.1f);
        Vector3 upMax = new Vector3(0f, 3f, 0f);
        Vector3 upMin = new Vector3(0f, 1f, 0f);
        Image logoImage = logo.GetComponent<Image>();
        float fade = 0.0f;
        while (fade <= 1.0f) {
            fade += 0.1f;
            logoImage.color = new Color(255, 255, 255, fade);
            yield return new WaitForSeconds(0.1f);
        }
        while (fade >= 1.0f && upMin.y <= upMax.y) {
            upMin.y += 0.1f;
            logo.transform.Translate(upMin, Space.Self);
            yield return null;
        }
    }
}
