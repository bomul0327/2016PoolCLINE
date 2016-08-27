using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour {
    //InGameScore.cs
    [SerializeField]
    private Text textTotalScore;
    private int totalScore = 0;

    //Pause.cs
    [SerializeField]
    private GameObject pauseObject;
    [SerializeField]
    private GameManager gameManager;

    //BestScore.cs
    [SerializeField]
    private GameObject bestScoreObject;
    [SerializeField]
    private Text textBestScore;
    private int bestScore = 0;

    //back,cs
    [SerializeField]
    private GameObject backObject;

    //restart.cs
    [SerializeField]
    private GameObject continueObject;

    [SerializeField]
    private Text textWaterDistance;

    void Start () {
        DisplayScore(0);

        bestScoreObject.SetActive(false);
        backObject.SetActive(false);
        continueObject.SetActive(false);

        bestScore = PlayerPrefs.GetInt("BestScore", bestScore);
        textBestScore.text = "BEST\n" + bestScore.ToString();
    }

    void SaveScore () {
        PlayerPrefs.SetInt("TotalScore", totalScore);
        if(totalScore > bestScore) {
            PlayerPrefs.SetInt("BestScore", totalScore);
        }
    }

    public void DisplayScore (int score) {
        totalScore = score;
        textTotalScore.text = totalScore.ToString();
    }

    public void DisplayWaterDistance (float dist) {
        textWaterDistance.text = string.Format("{0:N2}", dist);
    }

    public void OnBackClick () {
        SceneManager.LoadScene("MainUIScene");
        Time.timeScale = 1f;
    }

    public void OnGameOver () {
        SaveScore();
        SceneManager.LoadScene("GameOverScene");
    }

    public void OnPauseClick () {
        pauseObject.SetActive(false);
        backObject.SetActive(true);
        bestScoreObject.SetActive(true);
        continueObject.SetActive(true);

        Time.timeScale = 0f;
        gameManager.IsPaused = true;
    }

    public void OnContinueClick () {
        pauseObject.SetActive(true);
        backObject.SetActive(false);
        bestScoreObject.SetActive(false);
        continueObject.SetActive(false);

        gameManager.IsPaused = false;
        Time.timeScale = 1f;
    }
}
