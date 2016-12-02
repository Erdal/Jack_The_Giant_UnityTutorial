using UnityEngine;
using System.Collections;

public class PlayerMoveJoystick : MonoBehaviour {

    public float speed = 8f, maxVelocity = 4f;
    private Rigidbody2D myBody;
    private Animator anim;
    private bool moveLeft, moveRight; //Going to use to move both left and right

    //First thing to be activated on startup
    void Awake()
    {
        //Object "Player" Rigidbody is now a varable
        myBody = GetComponent<Rigidbody2D>();
        //Object "Player" Animator is now a varable
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(moveLeft)
        {
            MoveLeft();
        }
        else if(moveRight)
        {
            MoveRight();
        }
    }

    public void SetMoveLeft(bool moveLeft)
    {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft;
    }

    public void StopMoving()
    {
        moveLeft = moveRight = false;
        anim.SetBool("Walk", false); //Setting the animator false makes us stop walking (at least with our animation)
    }

    void MoveLeft()
    {
        float forceX = 0f; //Create our float each time
        float vel = Mathf.Abs(myBody.velocity.x); //Get velocity of our rigged body

        //If velocity is less then our max then make forceX = -speed
        if (vel < maxVelocity)
        {
            forceX = -speed;
        }

        //These lines change the direction our player is facing
        Vector3 temp = transform.localScale;
        temp.x = -1f;
        transform.localScale = temp;

        anim.SetBool("Walk", true); //Setting the animator to walk
        myBody.AddForce(new Vector2(forceX, 0));
    }

    void MoveRight()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        //If velocity is less then our max then make forceX = speed
        if (vel < maxVelocity)
        {
            forceX = speed;
        }

        //These lines change the direction our player is facing
        Vector3 temp = transform.localScale;
        temp.x = 1f;
        transform.localScale = temp;

        anim.SetBool("Walk", true); //Setting the animator to walk
        myBody.AddForce(new Vector2(forceX, 0));
    }
}
