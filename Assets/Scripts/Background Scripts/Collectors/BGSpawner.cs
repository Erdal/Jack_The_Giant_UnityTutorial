using UnityEngine;
using System.Collections;

public class BGSpawner : MonoBehaviour {

    //Array of background images
    private GameObject[] backgrounds;
    private float lastY;

	// Use this for initialization
	void Start ()
    {
        GetBackgroundAndSetLastY();
	}
	
    //All in the title
	void GetBackgroundAndSetLastY()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        lastY = backgrounds[0].transform.position.y;

        for(int i = 1; i < backgrounds.Length; i++)
        {
            if(lastY > backgrounds[i].transform.position.y)
            {
                lastY = backgrounds[i].transform.position.y;
            }
        }
    }

    //Here we want to re-activate our de-activated backgrounds and place them after the last background 
    //so that we may create the impression of an infinite background
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Background")
        {
            if(target.transform.position.y == lastY)
            {
                Vector3 temp = target.transform.position;
                float height = ((BoxCollider2D)target).size.y;

                for(int i = 0; i < backgrounds.Length; i++)
                {
                    if (!backgrounds[i].activeInHierarchy)
                    {
                        temp.y -= height;
                        lastY = temp.y;

                        backgrounds[i].transform.position = temp;
                        backgrounds[i].SetActive(true);
                    }
                }
            }
        }
    }
}
