using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour {
    public int probShowAds = 10;

    void Start() {
        if (Random.Range(0, 99) < probShowAds) {
            ShowAd();
        }
    }

    public void ShowAd () {
        if (Advertisement.IsReady()) {
            Advertisement.Show();
        }
    }
}
