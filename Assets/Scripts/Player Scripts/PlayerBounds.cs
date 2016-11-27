﻿using UnityEngine;
using System.Collections;

public class PlayerBounds : MonoBehaviour
{
    private float minX, maxX;

	// Use this for initialization
	void Start()
    {
        SetMinAndMax();
	}

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < minX)
        {
            Vector3 temp = transform.position;
            temp.x = minX;
            transform.position = temp;
        }

        if(transform.position.x > maxX)
        {
            Vector3 temp = transform.position;
            temp.x = maxX;
            transform.position = temp;
        }

    }

    void SetMinAndMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxX = bounds.x;
        minX = -bounds.x;
    }
}
