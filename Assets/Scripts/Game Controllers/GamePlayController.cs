using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    //A varable of the class
    public static GamePlayController instance;

    [SerializeField]
    private Text scoreText, coinText, lifeText, gameOverScoreText, gameOverCoinText; //So we can effect all out text elements on the UI

    [SerializeField]
    private GameObject pausePanel, gameOverPanel; //So we can effect our pause panel

    [SerializeField]
    private GameObject readyButton;

    // Use this for initialization
    void Awake()
    {
        MakeInstance();
	}

    void Start()
    {
        Time.timeScale = 0f; //Stops everything
    }
	
	void MakeInstance()
    {
        //Setting up the varable so i can use this class perfectly with just GamePlayController.instance when i am in other classes
        if(instance == null)
        {
            instance = this;
        }
    }

    //Here we are setting up our gameover panel
    public void GameOverShowPanel(int finalScore, int finalCoinScore)
    {
        gameOverPanel.SetActive(true); //Turn game over panel on
        gameOverScoreText.text = finalScore.ToString(); //Send final score through to panel
        gameOverCoinText.text = finalCoinScore.ToString(); //Send final coin score through to panel
        StartCoroutine(GameOverLoadMainMenu());
    }

    IEnumerator GameOverLoadMainMenu()
    {
        yield return new WaitForSeconds(3f); //Wait 3 seconds
        SceneFader.instance.LoadLevel("MainMenu"); //fade in, then out into the main menu
    }

    public void PlayerDiedRestartTheGame()
    {
        StartCoroutine(PlayerDiedRestart());
    }

    IEnumerator PlayerDiedRestart()
    {
        yield return new WaitForSeconds(1f); //Wait 1 seconds
        SceneFader.instance.LoadLevel("Gameplay"); //Fade in, then out into gameplay
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
    { //Pause game
        Time.timeScale = 0f; //This keeps everything going
        pausePanel.SetActive(true); //Shows the pause panel to the user
    }

    public void ResumeGame()
    { //Resume Game
        Time.timeScale = 1f; //This keeps everything going
        pausePanel.SetActive(false); //Turns pause panel off
    }

    public void QuitGame()
    { //Quit Game
        Time.timeScale = 1f; //This keeps everything going
        SceneFader.instance.LoadLevel("MainMenu"); //fade in, then out into the main menu
    }

    public void StartTheGame()
    {//Start the game
        Time.timeScale = 1f; //Make everything work again
        readyButton.SetActive(false); //Turn off ready button on UI
    }
}
