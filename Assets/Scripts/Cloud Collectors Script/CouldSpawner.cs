﻿using UnityEngine;
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
        player = GameObject.Find("Player");

        for(int i = 0; i < collectables.Length; i++) //To de-activate the colectables since they start activated.
        {
            collectables[i].SetActive(false);
        }
    }

    void Start()
    {
        PositionThePlayer();
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

    void PositionThePlayer()
    {
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");

        for(int i = 0; i < darkClouds.Length; i++)
        {
            if(darkClouds[i].transform.position.y == 0f)
            {
                Vector3 t = darkClouds[i].transform.position;

                darkClouds[i].transform.position = new Vector3(cloudsInGame[0].transform.position.x, cloudsInGame[0].transform.position.y, cloudsInGame[0].transform.position.z);

                cloudsInGame[0].transform.position = t;
            }
        }

        Vector3 temp = cloudsInGame[0].transform.position;

        for(int i = 1; i < cloudsInGame.Length; i++)
        {
            if(temp.y < cloudsInGame[i].transform.position.y)
            {
                temp = cloudsInGame[i].transform.position;
            }
        }

        temp.y += 0.8f;
        player.transform.position = temp;

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Cloud" || target.tag == "Deadly")
        {
            if(target.transform.position.y == lastCloudPositionY)
            {
                Shuffle(clouds);
                Shuffle(collectables);
                Vector3 temp = target.transform.position;

                for (int i = 0; i < clouds.Length; i++)
                { //Spawning and actvating out clouds
                    if(!clouds[i].activeInHierarchy)
                    {
                        if (controlX == 0)
                        {
                            temp.x = Random.Range(0.0f, maxX);
                            controlX = 1;
                        }
                        else if (controlX == 1)
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

                        temp.y -= distanceBetweenClouds;
                        lastCloudPositionY = temp.y;

                        clouds[i].transform.position = temp;
                        clouds[i].SetActive(true);

                        int random = Random.Range(0, collectables.Length);
                        
                        //If the cloud is not a deadly one
                        if(clouds[i].tag != "Deadly")
                        {
                            //If the random collectable item is not active
                            if(!collectables[random].activeInHierarchy)
                            {
                                //We want to place the collectable object a ontop of the cloud
                                Vector3 temp2 = clouds[i].transform.position;
                                temp2.y += 0.7f;

                                //If the item we are spawning is a life
                                if(collectables[random].tag == "Life")
                                {
                                    //Checking to see if player has less then 2 lives since we dont want to spawn anymore if they dont
                                    if(PlayerScore.lifeCount < 2)
                                    {
                                        collectables[random].transform.position = temp2;
                                        collectables[random].SetActive(true);
                                    }
                                }
                                else
                                {
                                    collectables[random].transform.position = temp2;
                                    collectables[random].SetActive(true);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

} // CloudSpawner
