using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    [HideInInspector]
    public bool moveCamera;

    private float speed = 1;
    private float acceleration = 0.2f;
    private float maxSpeed = 3.2f;

    private float easySpeed = 3.5f;
    private float mediumSpeed = 4.0f;
    private float hardSpeed = 4.5f;

	// Use this for initialization
	void Start () {
        
        //Set our speed based on the user preferences.
        if (GamePreferencesScript.GetEasyDifficultyState() == 1)
            maxSpeed = easySpeed;
        else if (GamePreferencesScript.GetMediumDifficultyState() == 1)
            maxSpeed = mediumSpeed;
        else if (GamePreferencesScript.GetHardDifficultyState() == 1)
            maxSpeed = hardSpeed;

        moveCamera = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (moveCamera)
        {
            MoveCamera();
        }
	}

    void MoveCamera()
    {
        Vector3 temp = transform.position;
        float oldY = temp.y;
        float newY = temp.y - (speed * Time.deltaTime);

        //This makes sure that temp.y doesn't go below oldY or above newY.
        temp.y = Mathf.Clamp(temp.y, oldY, newY);

        transform.position = temp;
        speed += acceleration * Time.deltaTime;

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }//MoveCamera
}
