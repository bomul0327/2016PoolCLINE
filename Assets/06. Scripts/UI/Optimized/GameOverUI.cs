using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	}
    
    public void OnBackClick () {
        SceneManager.LoadScene("MainUIScene");
    }  
	
    public void OnLeaderboardClick() {

    }

    public void OnAchievementClick() {

    }

    public void OnNoAdsClick() {
        IAPManager.Instance.BuyNoAds();
    }
}
