using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    [SerializeField]
    private Button musicButton;

    [SerializeField]
    private Sprite[] musicIcons;

	// Use this for initialization
	void Start () {
        CheckToPlayMusic();
	}

    void CheckToPlayMusic()
    {
        if (GamePreferencesScript.GetMusicState() == 1)
        {
            MusicControllerScript.instance.PlayMusic(true);
            //Display the music off icon
            musicButton.image.sprite = musicIcons[1];
        }
        else
        {
            MusicControllerScript.instance.PlayMusic(false);
            //Display the music on icon
            musicButton.image.sprite = musicIcons[0];
        }
    }

    public void StartGame()
    {
        GameManagerScript.instance.gameStartedFromMainMenu = true;
        // Application.LoadLevel("Gameplay");
        SceneFaderScript.instance.LoadLevel("Gameplay");
    }//StartGame
    
    public void HighScoreMenu()
    {
        Application.LoadLevel("HighScoreScene");
    }//HighScoreMenu

    public void OptionsMenu()
    {
        Application.LoadLevel("OptionsScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MusicButton()
    {
        if (GamePreferencesScript.GetMusicState() == 0)
        {
            GamePreferencesScript.SetMusicState(1);
            MusicControllerScript.instance.PlayMusic(true);
            musicButton.image.sprite = musicIcons[1];
        }
        else if (GamePreferencesScript.GetMusicState() == 1)
        {
            GamePreferencesScript.SetMusicState(0);
            MusicControllerScript.instance.PlayMusic(false);
            musicButton.image.sprite = musicIcons[0];
        }
    }//MusicButton
}
