using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    //A varable of the class
    public static GamePlayController instance;

    [SerializeField]
    private Text scoreText, coinText, lifeText; //So we can effect all out text elements on the UI

    [SerializeField]
    private GameObject pausePanel; //So we can effect our pause panel

    // Use this for initialization
    void Awake()
    {
        MakeInstance();
	}
	
	void MakeInstance()
    {
        //Setting up the varable so i can use this class perfectly with just GamePlayController.instance when i am in other classes
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SetScore(int score)
    {
        scoreText.text = "x" + score;
    }

    public void SetCoinScore(int coinScore)
    {
        coinText.text = "x" + coinScore;
    }

    public void SetLifeScore(int lifeScore)
    {
        lifeText.text = "x" + lifeScore;
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f; //This keeps everything going
        pausePanel.SetActive(true); //Shows the pause panel to the user
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; //This keeps everything going
        pausePanel.SetActive(false); //Turns pause panel off
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; //This keeps everything going
        SceneManager.LoadScene("MainMenu"); //Load up the main menu
    }
}
