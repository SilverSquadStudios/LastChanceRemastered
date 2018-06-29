using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

    /*
     * This is the value that determines how high chance will jump
     */
    public float jumpPower = 10.0f;

    /*
     * This is the Rigidbody reference to the chance rigidbody.
     */
    Rigidbody2D myRigidBody;

    /*
     * This is the jump constant used to move the character up. Only change to tweak power.
     */
    public float JUMP_CONSTANT = 20.0f;

    /*
     * Bool to determine if 1 jump per click. 
     */
    public bool isGrounded = false;

    //This is the movement constant that the camera and chance uses. Can be used to speed up or slow down.
    private static float MOVEMENT_CONSTANT = 20.0f;

    //The score value
    public static int score = 0;

    // Use this for initialization
    void Start () {
        myRigidBody = transform.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigidBody.AddForce(Vector3.up * (jumpPower * myRigidBody.mass * JUMP_CONSTANT));
            isGrounded = false;
        }
        transform.Translate(Vector3.right * MOVEMENT_CONSTANT * Time.deltaTime);
    }

    /**
     * Getter for the MOVEMENT_CONSTANT
     */
    public static float getMovement()
    {
        return MOVEMENT_CONSTANT;
    }

    public static void test()
    {
        spawnPlatform.spawnPlatformCoin();
    }
    
    
    /**
     * Setter for the MOVEMENT_CONSTANT
     */
     public void setMovement(float value)
    {
        MOVEMENT_CONSTANT = value;
    }

    /**
     * This Function changes the boolean tag once the character hits the ground to 
     * continue movement else double jumping might happen.
     */
    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.collider.tag)
        {
            case "Ground":
                isGrounded = true;
                break;
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Collider2D>().tag == "coin")
        {
            Destroy(other.gameObject);
        }
    }

    /*
     *This function also does the same thing as the function above.
     */
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    /*
     * This turns the boolean off after chance leaves the platform.
     */
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }

}
