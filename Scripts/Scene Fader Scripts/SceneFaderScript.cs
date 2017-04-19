using UnityEngine;
using System.Collections;

public class SceneFaderScript : MonoBehaviour {

    public static SceneFaderScript instance;

    [SerializeField]
    private GameObject fadePanel;

    [SerializeField]
    private Animator fadeAnim;

	// Use this for initialization
	void Awake () {
        MakeSingleton();
	}

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

    public void LoadLevel(string level)
    {
        StartCoroutine(FadeInOut(level));
    }

    IEnumerator FadeInOut(string level)
    {
        fadePanel.SetActive(true);
        fadeAnim.Play("FadeIn");
        yield return StartCoroutine(MyCoroutineScript.WaitForRealSeconds(.7f));
        Application.LoadLevel(level);
        fadeAnim.Play("FadeOut");
        yield return StartCoroutine(MyCoroutineScript.WaitForRealSeconds(.7f));
        fadePanel.SetActive(false);
    }
}
