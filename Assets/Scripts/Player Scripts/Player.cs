using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 8f, maxVelocity = 4f;
    private Rigidbody2D myBody;
    private Animator anim;

    //First thing to be activated on startup
    void Awake()
    {
        //Object "Player" Rigidbody is now a varable
        myBody = GetComponent<Rigidbody2D>();
        //Object "Player" Animator is now a varable
        anim = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Called every 3-4 frames, good movments
    void FixedUpdate()
    {
        PlayerMoveKeyboard();
    }

    //Move object by keyboard
    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        if(h > 0)
        {
            if(vel < maxVelocity)
            {
                forceX = speed;
            }

            Vector3 temp = transform.localScale;
            temp.x = 1.3f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
        }
        else if(h < 0)
        {
            if(vel < maxVelocity)
            {
                forceX = -speed;
            }

            Vector3 temp = transform.localScale;
            temp.x = -1f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        myBody.AddForce(new Vector2(forceX, 0));
    }

} //Player
