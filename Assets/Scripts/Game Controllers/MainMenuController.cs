using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Button musicButton;

    [SerializeField]
    private Sprite[] musicIcons;

	// Use this for initialization
	void Start()
    {
        CheckToPlayTheMusic();
	}

    //Here we are checking to see if our music should be on, and then playing it if it should be
    void CheckToPlayTheMusic()
    {
        if(GamePreferences.GetIsMusicState() == 1) //If music should be on
        {
            MusicController.instance.PlayMusic(true); //Turn music on
            musicButton.image.sprite = musicIcons[1]; //Show music on icon
        }
        else //Else if shouldnt
        {
            MusicController.instance.PlayMusic(false); //Turn music off
            musicButton.image.sprite = musicIcons[0]; //Show music off icon
        }
    }

    public void StartGame()
    {
        //We are making sure our GameManger knows the player is starting a new game
        GameManager.instance.gameStartedFromMainMenu = true;
        //We are going to the game scene
        SceneFader.instance.LoadLevel("Gameplay");
    }

    public void HighScoreMenu()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    //Only works for device not computer, will test this soon though
    public void QuitGame()
    {
        Application.Quit();
    }

    public void MusicButton()
    {
        if(GamePreferences.GetIsMusicState() == 0)
        {
            GamePreferences.SetIsMusicState(1);
            MusicController.instance.PlayMusic(true); //Turn music on
            musicButton.image.sprite = musicIcons[1]; //Show music on icon
        }
        else if(GamePreferences.GetIsMusicState() == 1)
        {
            GamePreferences.SetIsMusicState(0);
            MusicController.instance.PlayMusic(false); //Turn music on
            musicButton.image.sprite = musicIcons[0]; //Show music on icon
        }
    }
}
