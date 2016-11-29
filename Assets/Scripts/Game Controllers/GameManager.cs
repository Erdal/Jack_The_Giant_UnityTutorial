using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

	void Awake()
    {
        MakeSingleton();
	}
	
	void MakeSingleton()
    { //Here we are making sure that this class never gets deleted when we leave the original scene it is made in
      //We are also making sure that when we return to this scene we do not create the same class again.
        if(instance != null)
        {
            Destroy(gameObject); //destroy object
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //Dont destroy object
        }
    }
}
