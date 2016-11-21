using UnityEngine;
using System.Collections;

public class CouldSpawner : MonoBehaviour {

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


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
} // CloudSpawner
