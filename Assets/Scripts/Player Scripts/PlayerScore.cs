using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinClip, lifeClip;

    private CameraScript cameraScript;

    private Vector3 previousPosition;
    private bool countScore;

    public static int scoreCount;
    public static int lifeCount;
    public static int coinCount;

    void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }

	// Use this for initialization
	void Start ()
    {
        previousPosition = transform.position;
        countScore = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        CountScore();
	}

    void CountScore()
    { //We are checking to see if the user has moved down the map, if he has we increase teh scoreCount and we change the previousPostiion to
      //The players new postion and then contiue to check on repeat.
        if(countScore)
        {
            if(transform.position.y < previousPosition.y)
            {
                scoreCount++;
            }
            previousPosition = transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        //If player touches a coin
        if(target.tag == "Coin")
        {
            coinCount++; //Give them a coin
            Collectables(200, coinClip);
            target.gameObject.SetActive(false); //Turn off coin that player has grabbed
        }

        //If player touches a life
        if(target.tag == "Life")
        {
            lifeCount++;
            Collectables(300, lifeClip);
            target.gameObject.SetActive(false); //Turn off coin that player has grabbed
        }

        //If player touches the bounds of the playable area
        if(target.tag == "Bounds")
        {
            Death();
        }

        //If player touches deadly cloud
        if(target.tag == "Deadly")
        {
            Death();
        }
    }

    void Collectables(int scoreReward, AudioClip sound)
    {
        scoreCount += scoreReward; //Give them extra points
        AudioSource.PlayClipAtPoint(sound, transform.position); //Play the coin getting audio clip
    }

    void Death()
    {
        cameraScript.moveCamera = false; //Make camera stip moving
        countScore = false; //Stop counting score
        transform.position = new Vector3(500, 500, 0); //Move player outside of camera so the user thinks they are dead
        lifeCount--; //Take away a life from player
    }
}
