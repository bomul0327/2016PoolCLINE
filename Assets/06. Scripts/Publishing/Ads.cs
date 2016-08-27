using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour {
    private int prob = 10;

    void Start() {
        if (Random.Range(0, 99) < prob) {
            ShowAd();
        }
    }

    public void ShowAd () {
        if (Advertisement.IsReady()) {
            Advertisement.Show();
        }
    }
}
