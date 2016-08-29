using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StarCtrlSprite : MonoBehaviour {

    private SpriteRenderer sRend;

	// Use this for initialization
	IEnumerator Start () {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        sRend = GetComponent<SpriteRenderer>();
        yield return new WaitForSeconds(Random.Range(0, 6));
        StartCoroutine(FadeIn());
        yield return null;
	}
	
    IEnumerator FadeIn () {
        float fade = 1.0f;
        float randomTime = Random.Range(6, 10);
        while (fade >= 0.0f) {
            fade -= Time.deltaTime / randomTime;
            sRend.color = new Color(255, 255, 255, fade);
            yield return null;
        }
        StartCoroutine(FadeOut());
        yield return null;
    }

    IEnumerator FadeOut () {
        float fade = 0.0f;
        float randomTime = Random.Range(6, 10);
        while (fade <= 1.0f) {
            fade += Time.deltaTime / randomTime;
            sRend.color = new Color(255, 255, 255, fade);
            yield return null;
        }
        StartCoroutine(FadeIn());
        yield return null;
    }
}
