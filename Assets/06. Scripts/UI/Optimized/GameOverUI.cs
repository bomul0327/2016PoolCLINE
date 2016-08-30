using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

//This Script includes GooglePlayService codes.
//TODO: Need Separate from UI codes.
public class GameOverUI : MonoBehaviour {
    [SerializeField]
    private Text textTotalScore;
    [SerializeField]
    private Text textBestScore;

    private int totalScore;
    private int bestScore;

	void Start () {
        totalScore = PlayerPrefs.GetInt("TotalScore", 0);
        bestScore = PlayerPrefs.GetInt("BestScore", 0);

        textTotalScore.text = "SCORE\n" + totalScore.ToString();
        textBestScore.text = "BEST\n" + bestScore.ToString();

        //Google Play Games
        GooglePlayService.Instance.ConnectToGoogleServices();

        Social.ReportScore(PlayerPrefs.GetInt("BestScore", 0), "CgkI99CpsJILEAIQBg", (bool success) => {
            if (success) {
                Debug.Log("BestScore updated to Leaderboard");
            }
            else {
                Debug.Log("BestScore did not updated to Leaderboard");
            }
        });
        Social.ReportProgress("CgkI99CpsJILEAIQBQ", 100.0f, (bool success) => {
            if (success) {
                Debug.Log("Get Achievement");
            }
            else {
                Debug.Log("Did not get Achievement");
            }
        });
    }
    
    public void OnBackClick () {
        SceneManager.LoadScene("MainUIScene");
    }

    public void OnLeaderboardClick () {
        if (Social.localUser.authenticated) {
            Social.ShowLeaderboardUI();
        }
        else {
            GooglePlayService.Instance.ConnectToGoogleServices();
            Debug.Log("Not connected to Google Play Services");
        }
    }

    public void OnAchievementClick () {
        if (Social.localUser.authenticated) {
            Social.ShowAchievementsUI();
        }
        else {
            GooglePlayService.Instance.ConnectToGoogleServices();
            Debug.Log("Not connected to Google Play Services");
        }
    }

    public void OnNoAdsClick () {
        IAPManager.Instance.BuyNoAds();
        Social.ReportProgress("CgkI99CpsJILEAIQAQ", 100.0f, (bool success) => {
            if (success) {
                Debug.Log("Get Achievement");
            }
            else {
                GooglePlayService.Instance.ConnectToGoogleServices();
                Debug.Log("Did not get Achievement");
            }
        });
    }

}
