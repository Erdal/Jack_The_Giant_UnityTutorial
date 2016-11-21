using UnityEngine;
using System.Collections;

public class CouldSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] clouds; //Store our cloud objects
    //distence bweteen our objects
    private float distanceBetweenClouds = 3f;
    //help position our cloud objects
    private float minX, maxX;
    //Last clouds Y postion
    private float lastCloudPositionY;
    //Controll the X postiion of our clouds when spawning
    private float controlX;

    [SerializeField]
    private GameObject[] collectables; //store collectable items
    //Postiion the player
    private GameObject player;

    void Awake()
    {
        controlX = 0;
        SetMinAndMax();
        CreateClouds();
    }


    //Here we are making sure when we make our objects that they are not to far off screen for the palyer to see or use
    void SetMinAndMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }

    //Here we will randomise the postiton of our game objects
    void Shuffle(GameObject[] arrayToShuffle)
    {
        for(int i = 0; i < arrayToShuffle.Length; i++)
        {
            GameObject temp = arrayToShuffle[i];
            int random = Random.Range(i, arrayToShuffle.Length);
            arrayToShuffle[i] = arrayToShuffle[random];
            arrayToShuffle[random] = temp;
        }
    }

    //I'll let you guess :D
    void CreateClouds()
    {
        Shuffle(clouds);

        float positionY = 0f;

        //Forcing zig zar postiion
        for(int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;
            temp.y = positionY;

            if(controlX == 0)
            {
                temp.x = Random.Range(0.0f, maxX);
                controlX = 1;
            }
            else if(controlX == 1)
            {
                temp.x = Random.Range(0.0f, minX);
                controlX = 2;
            }
            else if (controlX == 2)
            {
                temp.x = Random.Range(1.0f, maxX);
                controlX = 3;
            }
            else if (controlX == 3)
            {
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0;
            }

            lastCloudPositionY = positionY;
            clouds[i].transform.position = temp;
            positionY -= distanceBetweenClouds;
        }
    }
} // CloudSpawner
