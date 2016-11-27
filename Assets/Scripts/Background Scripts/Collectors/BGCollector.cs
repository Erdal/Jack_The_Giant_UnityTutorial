using UnityEngine;
using System.Collections;

public class BGCollector : MonoBehaviour {
    //Here we are going to turn off any backgrounds that our BGCollector collides with
	void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Background")
        {
            target.gameObject.SetActive(false);
        }
    }
}
