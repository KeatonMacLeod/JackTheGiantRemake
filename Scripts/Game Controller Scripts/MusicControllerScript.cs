using UnityEngine;
using System.Collections;

public class MusicControllerScript : MonoBehaviour {

    public static MusicControllerScript instance;
    private AudioSource audioSource;

	// Use this for initialization
	void Awake () {
        MakeSingleton();
        audioSource = GetComponent<AudioSource>();
	}//Awake

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
    }//MakeSingleton

    public void PlayMusic(bool play)
    {
        if (play)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }//PlayMusic

}
