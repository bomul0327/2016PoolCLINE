using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StarCtrlUI : MonoBehaviour {

    private Image image;

	// Use this for initialization
	IEnumerator Start () {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        image = GetComponent<Image>();
        yield return new WaitForSeconds(Random.Range(0, 6));
        StartCoroutine(FadeIn());
        yield return null;
	}
	
    IEnumerator FadeIn () {
        float toFade = 0f;
        image.CrossFadeAlpha(toFade, 6, true);
        yield return new WaitForSeconds(Random.Range(6, 10));
        StartCoroutine(FadeOut());
        yield return null;
    }

    IEnumerator FadeOut () {
        float toFade = 1f;
        image.CrossFadeAlpha(toFade, 6, true);
        yield return new WaitForSeconds(Random.Range(6, 10));
        StartCoroutine(FadeIn());
        yield return null;
    }
}
