using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameplayControllerScript : MonoBehaviour {

    public static GameplayControllerScript instance;

    [SerializeField]
    private Text scoreText, coinText, lifeText, gameOverScoreText, gameOverCoinText;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel;

    [SerializeField]
    private GameObject readyButton;

	// Use this for initialization
	void Awake () {
        MakeInstance();
	}

    private void Start()
    {
        Time.timeScale = 0f;
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PauseGame()
    {
        //Stops the game.
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        //Reset the game.
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        //Application.LoadLevel("MainMenu");
        SceneFaderScript.instance.LoadLevel("MainMenu");
    }

    public void SetScore(int score)
    {
        scoreText.text = "x" + score;
    }

    public void SetCoinScore(int coinScore)
    {
        coinText.text = "x" + coinScore;
    }

    public void SetLifeScore(int lifeScore)
    {
        lifeText.text = "x" + lifeScore;
    }

    public void GameOverShowPanel(int finalScore, int finalCoinScore)
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = "" + finalScore;
        gameOverCoinText.text = "" + finalCoinScore;
        StartCoroutine("GameOverLoadMainMenu");
    }

    IEnumerator GameOverLoadMainMenu()
    {
        yield return new WaitForSeconds(3);
        //Application.LoadLevel("MainMenu");
        SceneFaderScript.instance.LoadLevel("MainMenu");
    }

    public void PlayerDiedRestartTheGame()
    {
        StartCoroutine("PlayerDiedRestart");
    }

    IEnumerator PlayerDiedRestart()
    {
        yield return new WaitForSeconds(1);
        //Application.LoadLevel("Gameplay");
        SceneFaderScript.instance.LoadLevel("Gameplay");
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        readyButton.SetActive(false);
    }
}
