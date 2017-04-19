using UnityEngine;
using System.Collections;

public class PlayerMoveJoystick : MonoBehaviour {

    public float speed = 20;
    public float maxVelocity = 5;
    private Rigidbody2D playerBody;
    private Animator playerAnim;

    private bool moveLeft, moveRight;

    //First function executed
    void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (moveLeft)
            MoveLeft();
        if (moveRight)
            MoveRight();
	}

    public void SetMoveLeft(bool moveLeft)
    {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft;
    }

    public void StopMoving()
    {
        moveLeft = moveRight = false;
        playerAnim.SetBool("Walk", false);
    }

    void MoveLeft()
    {
        float forceX = 0;
        float vel = Mathf.Abs(playerBody.velocity.x);

        if (vel < maxVelocity)
        {
            forceX = -speed;
        }

        //Return the scale vector in the inspector panel with the same properties, but with x as player facing left
        Vector3 facingDirection = transform.localScale;
        facingDirection.x = -1; //The value of negative x in the inspector panel 
        transform.localScale = facingDirection;
        playerAnim.SetBool("Walk", true);
        playerBody.AddForce(new Vector2(forceX, 0));
    }

    void MoveRight()
    {
        float forceX = 0;
        float vel = Mathf.Abs(playerBody.velocity.x);

        if (vel < maxVelocity)
        {
            forceX = speed;
        }

        //Return the scale vector in the inspector panel with the same properties, but with x as player facing left
        Vector3 facingDirection = transform.localScale;
        facingDirection.x = 1; //The value of negative x in the inspector panel 
        transform.localScale = facingDirection;
        playerAnim.SetBool("Walk", true);
        playerBody.AddForce(new Vector2(forceX, 0));
    }
}
