using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    private AudioSource audioSource;

	void Awake()
    {
        Makesingleton();
        audioSource = GetComponent<AudioSource>();
	}

    //We are making sure that this class never gets destroyed
    void Makesingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
	
    //Here we will be deciding if the music should be playing or not
    public void PlayMusic(bool play)
    {
        if(play) //Play = true
        {
            //If music is not playing
            if(!audioSource.isPlaying)
            {
                //Play music
                audioSource.Play();
            }
        }
        else //play = false
        {
            //If music is playing
            if (audioSource.isPlaying)
            {
                //Stop music
                audioSource.Stop();
            }
        }
    }
}
