using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems; //Allows us to detect touch on the screen.

public class JoystickScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

    PlayerMoveJoystick playerMove;

    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMoveJoystick>();
    }

    //This function tells us when we release a button
    public void OnPointerUp(PointerEventData data)
    {
        playerMove.StopMoving();
    }

    //This function tells us when we push / hold a button
    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "LeftJoystickButton")
        {
            playerMove.SetMoveLeft(true);
        }
        else
        {
            playerMove.SetMoveLeft(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
