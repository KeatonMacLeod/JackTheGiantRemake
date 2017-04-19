using UnityEngine;
using System.Collections;

public static class GamePreferencesScript {

    public static string easyDifficulty = "easyDifficulty";
    public static string mediumDifficulty = "mediumDifficulty";
    public static string hardDifficulty = "hardDifficulty";

    public static string easyDifficultyHighScore = "easyDifficultyHighScore";
    public static string mediumDifficultyHighScore = "mediumDifficultyHighScore";
    public static string hardDifficultyHighScore = "hardDifficultyHighScore";


    public static string easyDifficultyCoinScore = "easyDifficultyCoinScore";
    public static string mediumDifficultyCoinScore = "mediumDifficultyCoinScore";
    public static string hardDifficultyCoinScore = "hardDifficultyCoinScore";

    public static string isMusicOn = "isMusicOn";

    //NOTE: We are going to use integers to represent boolean values.
    // 0 -> false, 1 -> true

    public static int GetMusicState()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.isMusicOn);
    }

    public static void SetMusicState(int state)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.isMusicOn, state);
    }

    public static int GetEasyDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.easyDifficulty);
    }

    public static void SetEasyDifficultyState(int state)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.easyDifficulty, state);
    }

    public static int GetMediumDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.mediumDifficulty);
    }

    public static void SetMediumDifficultyState(int state)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.mediumDifficulty, state);
    }
    
    public static int GetHardDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.hardDifficulty);
    }

    public static void SetHardDifficultyState(int state)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.hardDifficulty, state);
    }

    public static int GetEasyDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.easyDifficultyHighScore);
    }

    public static void SetEasyDifficultyHighScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.easyDifficultyHighScore, score);
    }

    public static int GetMediumDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.mediumDifficultyHighScore);
    }

    public static void SetMediumDifficultyHighScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.mediumDifficultyHighScore, score);
    }

    public static int GetHardDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.hardDifficultyHighScore);
    }

    public static void SetHardDifficultyHighScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.hardDifficultyHighScore, score);
    }

    public static  int GetEasyDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.easyDifficultyCoinScore);
    }

    public static void SetEasyDifficultyCoinScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.easyDifficultyCoinScore, score);
    }

    public static int GetMediumDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.mediumDifficultyCoinScore);
    }

    public static void SetMediumDifficultyCoinScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.mediumDifficultyCoinScore, score);
    }

    public static int GetHardDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.hardDifficultyCoinScore);
    }

    public static void SetHardDifficultyCoinScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.hardDifficultyCoinScore, score);
    }

}
