using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

    //Make these fields visible in the inspector panel
    [SerializeField]
    private GameObject[] clouds;
    [SerializeField]
    private GameObject[] collectables;
    private GameObject player;

    private float distanceBetweenClouds = 3;
    private float minX;
    private float maxX;
    private float lastCloudPositionY;
    private float controlX;

    private void Awake()
    {
        controlX = 0;
        SetMinAndMaxX();
        CreateClouds();
        player = GameObject.Find("Player");

        //Deactivate the initial collectables at the start of the game.
        for (int a = 0; a < collectables.Length; a++)
        {
            collectables[a].SetActive(false);
        }
    }

    // Use this for initialization
    void Start () {
        PositionThePlayer();
	}
	
    void SetMinAndMaxX()
    {
        //Converting the screen coordinates into world coordinates eg.) Where the user clicks in the game -->
        //and translating into where the click is happening in the Unity game world a.k.a. the white outline Main Camera.
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        //Use 0.5 so the at least half the cloud will always be visible on screen in case it chooses the lowest min or highest max value.
        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }//SetMinAndMax

    //Randomizes the position of our GameObjects
    void Shuffle(GameObject[] shuffleArray)
    {
        for (int a = 0; a < shuffleArray.Length; a++)
        {
            GameObject temp = shuffleArray[a];
            int random = Random.Range(a, shuffleArray.Length);
            shuffleArray[a] = shuffleArray[random];
            shuffleArray[random] = temp;
        }
    }//Shuffle

    void CreateClouds()
    {
        Shuffle(clouds);
        float positionY = 0;

        for (int a = 0; a < clouds.Length; a++)
        {
            Vector3 temp = clouds[a].transform.position;
            temp.y = positionY;
            temp.x = Random.Range(minX, maxX);

            //4 Possible Ranges of Positions, make a zig-zag pattern with the clouds.
            if (controlX == 0)
            {
                temp.x = Random.Range(0, maxX);
                controlX = 1;
            }
            else if (controlX == 1)
            {
                temp.x = Random.Range(0, minX);
                controlX = 1;
            }
            else if (controlX == 2)
            {
                temp.x = Random.Range(1.0f, minX);
                controlX = 3;
            }
            else if (controlX == 4)
            {
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0;
            }

            lastCloudPositionY = positionY;
            clouds[a].transform.position = temp;
            positionY -= distanceBetweenClouds;

        }//for

    }//CreateClouds

    void PositionThePlayer()
    {
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] clouds = GameObject.FindGameObjectsWithTag("Cloud");

        //Make sure the first cloud is a non-deadly cloud
        for (int a = 0; a < darkClouds.Length; a++)
        {
            if (darkClouds[a].transform.position.y == 0)
            {
                Vector3 swapOne = darkClouds[a].transform.position;
                //Swap it with the clouds position
                darkClouds[a].transform.position = new Vector3(clouds[0].transform.position.x,
                                                               clouds[0].transform.position.y,
                                                               clouds[0].transform.position.z);
                clouds[0].transform.position = swapOne;
            }//if
        }//for

        Vector3 swapTwo = clouds[0].transform.position;

        //Make sure a "good cloud" spawns on top and the player is above it.
        for (int b = 0; b < clouds.Length; b++)
        {
            if (swapTwo.y < clouds[b].transform.position.y)
            {
                swapTwo = clouds[b].transform.position;
            }
        }//for

        swapTwo.y += .7f;
        player.transform.position = swapTwo;
    }//PositionThePlayer

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Cloud" || target.tag == "Deadly")
        {
            if (target.transform.position.y == lastCloudPositionY)
            {
                Shuffle(clouds);
                Shuffle(collectables);

                Vector3 temp = target.transform.position;

                for (int a = 0; a < clouds.Length; a++)
                {
                    if (!clouds[a].activeInHierarchy)
                    {
                        //4 Possible Ranges of Positions, make a zig-zag pattern with the clouds.
                        if (controlX == 0)
                        {
                            temp.x = Random.Range(0, maxX);
                            controlX = 1;
                        }
                        else if (controlX == 1)
                        {
                            temp.x = Random.Range(0, minX);
                            controlX = 1;
                        }
                        else if (controlX == 2)
                        {
                            temp.x = Random.Range(1.0f, minX);
                            controlX = 3;
                        }
                        else if (controlX == 4)
                        {
                            temp.x = Random.Range(-1.0f, minX);
                            controlX = 0;
                        }

                        temp.y -= distanceBetweenClouds;
                        lastCloudPositionY = temp.y;
                        clouds[a].transform.position = temp;
                        clouds[a].SetActive(true);

                        int random = Random.Range(0, collectables.Length);

                        //If we're on a good cloud
                        if (clouds[a].tag != "Deadly")
                        {
                            //If the collectable is not active in the game already
                            if (!collectables[random].activeInHierarchy)
                            {
                                Vector3 temp2 = clouds[a].transform.position;
                                temp2.y += 0.7f;

                                if (collectables[random].tag == "Life" && PlayerScoreScript.lifeCount < 2)
                                {
                                    collectables[random].transform.position = temp2;
                                    collectables[random].SetActive(true);
                                }
                                else
                                {
                                    collectables[random].transform.position = temp2;
                                    collectables[random].SetActive(true);
                                }
                            }
                        }

                    }//if

                }//for

            }//if

        }//if

    }//OnTriggerEnter2D
}
