using UnityEngine;
using System.Collections;

public class CloudCollector : MonoBehaviour
{
    //Here we are going to decide what gets done when two objects with a collider colide together.
    void OnTriggerEnter2D(Collider2D target)
    {
        //Here i am setting any objects with the the two tags down below to false, so i am turning the objects off
        if(target.tag == "Cloud" || target.tag == "Deadly")
        {
            target.gameObject.SetActive(false);
        }
    }
}
