using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GooglePlayService : MonoBehaviour {
    public static GooglePlayService Instance;

    //Google Services
    private bool IsConnectedToGoogleServices;

    // Use this for initialization
    void Awake () {
        Instance = this;
    }

    void Start () {
        //Google Services
        PlayGamesPlatform.Activate();
        ConnectToGoogleServices();
    }

    public bool ConnectToGoogleServices () {
        if (!IsConnectedToGoogleServices) {
            Social.localUser.Authenticate((bool success) => {
                IsConnectedToGoogleServices = success;
            });
        }

        return IsConnectedToGoogleServices;
    }
}
