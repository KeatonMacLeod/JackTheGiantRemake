using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 20;
    public float maxVelocity = 5;
    private Rigidbody2D playerBody;
    private Animator playerAnim;

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
    // FixedUpdate is called once every couple of frames
	void FixedUpdate () {
        PlayerMoveKeyboard();
	}
    
    void PlayerMoveKeyboard()
    {
        float forceX = 0;
        float vel = Mathf.Abs(playerBody.velocity.x);
        float x = Input.GetAxisRaw("Horizontal");

        if (x > 0)
        {
            playerAnim.SetBool("Walk", true);
            if (vel < maxVelocity)
            {
                forceX = speed; 
            }

            //Return the scale vector in the inspector panel with the same properties, but with x as player facing right
            Vector3 facingDirection = transform.localScale;
            facingDirection.x = 1; //The value of x in the inspector panel 
            transform.localScale = facingDirection;
        }

        else if (x < 0)
        {
            playerAnim.SetBool("Walk", true);
            if (vel < maxVelocity)
            {
                forceX = -speed;
            }

            //Return the scale vector in the inspector panel with the same properties, but with x as player facing left
            Vector3 facingDirection = transform.localScale;
            facingDirection.x = -1; //The value of negative x in the inspector panel 
            transform.localScale = facingDirection;
        }

        else if (x == 0)
        {
            playerAnim.SetBool("Walk", false);
        }

        //This takes a vector, so give it the new vector with the applied speed changes
        playerBody.AddForce(new Vector2(forceX, 0));
    }//PlayerMoveKeyboard
}
