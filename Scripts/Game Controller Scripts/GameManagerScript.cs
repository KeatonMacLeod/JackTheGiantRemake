using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

    public static GameManagerScript instance;
    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;
    [HideInInspector]
    public int score, coinScore, lifeScore;

    private void Awake()
    {
        MakeSingleton();
    }

    private void Start()
    {
        InitializeVariables();
    }

    void InitializeVariables()
    {
        //If we don't have any preferences
        if (!PlayerPrefs.HasKey("Game Initialized"))
        {
            GamePreferencesScript.SetEasyDifficultyState(0);
            GamePreferencesScript.SetEasyDifficultyHighScore(0);
            GamePreferencesScript.SetEasyDifficultyCoinScore(0);

            GamePreferencesScript.SetMediumDifficultyState(1);
            GamePreferencesScript.SetMediumDifficultyHighScore(0);
            GamePreferencesScript.SetMediumDifficultyCoinScore(0);

            GamePreferencesScript.SetHardDifficultyState(0);
            GamePreferencesScript.SetHardDifficultyHighScore(0);
            GamePreferencesScript.SetHardDifficultyCoinScore(0);

            GamePreferencesScript.SetMusicState(0);

            //Now we have player preferences, so set "Game Initialized" any time the user 
            //uses this application in the future.
            PlayerPrefs.SetInt("Game Initialized", 1);
        }
    }

    //Singleton pattern makes us have one instance of this class that doesn't get destroyed
    //as we switch between menus.
    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnLevelWasLoaded()
    {
        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            if (gameRestartedAfterPlayerDied)
            {
                GameplayControllerScript.instance.SetScore(score);
                GameplayControllerScript.instance.SetCoinScore(coinScore);
                GameplayControllerScript.instance.SetLifeScore(lifeScore);
                PlayerScoreScript.scoreCount = score;
                PlayerScoreScript.coinCount = coinScore;
                PlayerScoreScript.lifeCount = lifeScore;
            }
            else if (gameStartedFromMainMenu)
            {
                PlayerScoreScript.scoreCount = 0;
                PlayerScoreScript.coinCount = 0;
                PlayerScoreScript.lifeCount = 2;
                GameplayControllerScript.instance.SetScore(0);
                GameplayControllerScript.instance.SetCoinScore(0);
                GameplayControllerScript.instance.SetLifeScore(2);
            }
        }
    }

    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if (lifeScore < 0)
        {
            //Set Easy Difficulty Scores
            if (GamePreferencesScript.GetEasyDifficultyState() == 1)
            {
                int highScore = GamePreferencesScript.GetEasyDifficultyHighScore();
                int coinHighScore = GamePreferencesScript.GetEasyDifficultyCoinScore();

                if (score > highScore)
                {
                    GamePreferencesScript.SetEasyDifficultyHighScore(score);
                }
                if (coinScore > coinHighScore)
                {
                    GamePreferencesScript.SetEasyDifficultyCoinScore(coinScore);
                }
            }

            //Set Medium Difficulty Scores
            if (GamePreferencesScript.GetMediumDifficultyState() == 1)
            {
                int highScore = GamePreferencesScript.GetMediumDifficultyHighScore();
                int coinHighScore = GamePreferencesScript.GetMediumDifficultyCoinScore();

                if (score > highScore)
                {
                    GamePreferencesScript.SetMediumDifficultyHighScore(score);
                }
                if (coinScore > coinHighScore)
                {
                    GamePreferencesScript.SetMediumDifficultyCoinScore(coinScore);
                }
            }

            //Set Hard Difficulty Scores
            if (GamePreferencesScript.GetHardDifficultyState() == 1)
            {
                int highScore = GamePreferencesScript.GetHardDifficultyHighScore();
                int coinHighScore = GamePreferencesScript.GetHardDifficultyCoinScore();

                if (score > highScore)
                {
                    GamePreferencesScript.SetHardDifficultyHighScore(score);
                }
                if (coinScore > coinHighScore)
                {
                    GamePreferencesScript.SetHardDifficultyCoinScore(coinScore);
                }
            }

            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = false;
            GameplayControllerScript.instance.GameOverShowPanel(score,coinScore);
        }

        else
        {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

            gameRestartedAfterPlayerDied = true;
            gameStartedFromMainMenu = false;

            GameplayControllerScript.instance.PlayerDiedRestartTheGame();
        }
    }

}