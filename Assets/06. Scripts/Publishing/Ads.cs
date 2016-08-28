using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour {

    public int prob = 20;

    void Start() {
        if (Random.Range(0, 99) < PlayerPrefs.GetInt("ProbShowAds", prob)) {
            ShowAd();
        }
    }

    public void ShowAd () {
        if (Advertisement.IsReady()) {
            Advertisement.Show();
        }
    }
}
