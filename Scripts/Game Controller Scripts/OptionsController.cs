using UnityEngine;
using System.Collections;

public class OptionsController : MonoBehaviour {

    [SerializeField]
    private GameObject easySign, mediumSign, hardSign;

	// Use this for initialization
	void Start () {
        SetTheDifficulty();
	}

    void SetInitialDifficulty(string difficulty)
    {
        switch(difficulty)
        {
            case "easy":
                easySign.SetActive(true);
                mediumSign.SetActive(false);
                hardSign.SetActive(false);
                break;

            case "medium":
                easySign.SetActive(false);
                mediumSign.SetActive(true);
                hardSign.SetActive(false);
                break;

            case "hard":
                easySign.SetActive(false);
                mediumSign.SetActive(false);
                hardSign.SetActive(true);
                break;
        }
    }

    void SetTheDifficulty()
    {
        if (GamePreferencesScript.GetEasyDifficultyState() == 1)
        {
            SetInitialDifficulty("easy");
        }

        else if (GamePreferencesScript.GetMediumDifficultyState() == 1)
        {
            SetInitialDifficulty("medium");
        }

        else if (GamePreferencesScript.GetHardDifficultyState() == 1)
        {
            SetInitialDifficulty("hard");
        }
    }

    public void EasyDifficulty()
    {
        GamePreferencesScript.SetEasyDifficultyState(1);
        GamePreferencesScript.SetMediumDifficultyState(0);
        GamePreferencesScript.SetHardDifficultyState(0);
        easySign.SetActive(true);
        mediumSign.SetActive(false);
        hardSign.SetActive(false);
    }

    public void MediumDifficulty()
    {
        GamePreferencesScript.SetEasyDifficultyState(0);
        GamePreferencesScript.SetMediumDifficultyState(1);
        GamePreferencesScript.SetHardDifficultyState(0);
        easySign.SetActive(false);
        mediumSign.SetActive(true);
        hardSign.SetActive(false);
    }

    public void HardDifficulty()
    {
        GamePreferencesScript.SetEasyDifficultyState(0);
        GamePreferencesScript.SetMediumDifficultyState(0);
        GamePreferencesScript.SetHardDifficultyState(1);
        easySign.SetActive(false);
        mediumSign.SetActive(false);
        hardSign.SetActive(true);
    }

    public void GoBackToMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
