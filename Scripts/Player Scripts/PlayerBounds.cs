using UnityEngine;
using System.Collections;


public class PlayerBounds : MonoBehaviour {

    private float minX;
    private float maxX;

	// Use this for initialization
	void Start () {
        SetMinAndMaxX();
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

    // Update is called once per frame
    void Update () {
        if (transform.position.x < minX)
        {
            Vector3 temp = transform.position;
            temp.x = minX;
            transform.position = temp;
        }
        else if (transform.position.x > maxX)
        {
            Vector3 temp = transform.position;
            temp.x = maxX;
            transform.position = temp;
        }
	}//Update
}
