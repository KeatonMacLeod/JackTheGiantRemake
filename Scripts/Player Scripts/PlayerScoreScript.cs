using UnityEngine;
using System.Collections;

public class PlayerScoreScript : MonoBehaviour {

    [SerializeField]
    private AudioClip coinClip, lifeClip;

    private CameraScript cameraScript;
    private Vector3 previousPosition;
    private bool countScore;

    public static int scoreCount;
    public static int lifeCount;
    public static int coinCount;

    private void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
        previousPosition = transform.position;
        countScore = true;
    }

    // Use this for initialization
    void Start () {
        previousPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        CountScore();
	}

    void CountScore()
    {
        if (countScore)
        {
            if (transform.position.y < previousPosition.y)
            {
                scoreCount++;
            }
            previousPosition = transform.position;
            GameplayControllerScript.instance.SetScore(scoreCount);
        }
    }//CountScore

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Coin")
        {
            coinCount++;
            scoreCount += 200;
            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            target.gameObject.SetActive(false);

            GameplayControllerScript.instance.SetScore(scoreCount);
            GameplayControllerScript.instance.SetCoinScore(coinCount);
        }

        else if (target.tag == "Life")
        {
            lifeCount++;
            scoreCount += 300;
            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            target.gameObject.SetActive(false);

            GameplayControllerScript.instance.SetScore(scoreCount);
            GameplayControllerScript.instance.SetLifeScore(lifeCount);
        }

        else if (target.tag == "Bounds" || target.tag == "Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;
            //Move Player outside of Camera view.
            transform.position = new Vector3(500, 500, 0);
            lifeCount--;

            GameManagerScript.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
        }

    }
}
