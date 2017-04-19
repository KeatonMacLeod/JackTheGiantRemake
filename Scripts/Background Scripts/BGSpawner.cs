using UnityEngine;
using System.Collections;

public class BGSpawner : MonoBehaviour {

    private GameObject[] backgrounds;
    private float lastYPosition;

	// Use this for initialization
	void Start () {
        GetBackgroundsAndSetLastY();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void GetBackgroundsAndSetLastY()
    {
        //Get all Game Objects with the tag "Background"
        //Game objects doesn't sort them by any order, that's why we need to do the for-loop below.
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        lastYPosition = backgrounds[0].transform.position.y;

        //We already have y position of the one at index 0
        //Go through the rest and make sure we have the correct "lastYPosition"
        for (int a = 1; a < backgrounds.Length; a++)
        {
            if (lastYPosition > backgrounds[a].transform.position.y)
            {
                lastYPosition = backgrounds[a].transform.position.y;
            }//if

        }//for

    }//GetBackgroundsAndSetLastY

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Background")
        {
            if (target.transform.position.y == lastYPosition)
            {
                Vector3 temp = target.transform.position;
                float height = ((BoxCollider2D)target).size.y;
                Debug.Log(height);
                for (int a = 0; a < backgrounds.Length; a++)
                {
                    if (!backgrounds[a].activeInHierarchy)
                    {
                        temp.y -= height;
                        lastYPosition = temp.y;
                        backgrounds[a].transform.position = temp;
                        backgrounds[a].SetActive(true);
                    }//if

                }//for

            }//if

        }//if

    }//OnTriggerEnter2D

}//BGSpawner
