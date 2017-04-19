using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

    [SerializeField]
    private Text scoreText, coinText;

	// Use this for initialization
	void Start () {
        SetScoreBasedOnDifficulty();
	}

    void SetScore(int score, int coinScore)
    {
        scoreText.text = "" + score;
        coinText.text = "" + coinScore;
    }

    void SetScoreBasedOnDifficulty()
    {
        if (GamePreferencesScript.GetEasyDifficultyState() == 1)
        {
            SetScore(GamePreferencesScript.GetEasyDifficultyHighScore(), GamePreferencesScript.GetEasyDifficultyCoinScore());
        }

        else if (GamePreferencesScript.GetMediumDifficultyState() == 1)
        {
            SetScore(GamePreferencesScript.GetMediumDifficultyHighScore(), GamePreferencesScript.GetMediumDifficultyCoinScore());
        }

        else if (GamePreferencesScript.GetHardDifficultyState() == 1)
        {
            SetScore(GamePreferencesScript.GetHardDifficultyHighScore(), GamePreferencesScript.GetHardDifficultyCoinScore());
        }
    }

    public void GoBackToMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
