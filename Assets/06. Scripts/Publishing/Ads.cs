using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour {
    void Start () {
        ShowAd();
    }

    public void ShowAd () {
        if (Advertisement.IsReady()) {
            Advertisement.Show();
        }
    }
}
