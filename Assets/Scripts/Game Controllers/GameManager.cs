using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] //Dont want people to mess with it on the unity screen
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied; //Honestly if you cant guess you dont need to know

    [HideInInspector] //Dont want people to mess with it on the unity screen
    public int score, coinScore, lifeScore; //We can store these here so they always exists, since we never destroy the object this is attached too

	void Awake()
    {
        MakeSingleton();
	}

    void OnLevelWasLoaded()
    {
        if(SceneManager.GetActiveScene().name == "Gameplay")
        {
            //If we are restarting the game after player has died
            if(gameRestartedAfterPlayerDied)
            {
                //Setting up all the previouse information before user died, such as coins and score also what the current lives should be
                GameStats(score, coinScore, lifeScore);
            }
            else if(gameStartedFromMainMenu) //User has started new game
            {
                //This is what we want every new game to start with
                GameStats(0, 0, 2);
            }
        }
    }

    void GameStats(int _score, int _coinScore, int _lifeScore)
    {
        GamePlayController.instance.SetScore(_score);
        GamePlayController.instance.SetCoinScore(_coinScore);
        GamePlayController.instance.SetLifeScore(_lifeScore);

        PlayerScore.scoreCount = _score;
        PlayerScore.coinCount = _coinScore;
        PlayerScore.lifeCount = _lifeScore;
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

    public void CheckGameStatus(int _score, int _coinScore, int _lifeScore)
    {
        //If player has no more lives to contiue
        if(_lifeScore < 0)
        {
            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = false;

            //Show the user how well they did
            GamePlayController.instance.GameOverShowPanel(_score, _coinScore);
        }
        else //If player still has lives left
        {
            score = _score;
            coinScore = _coinScore;
            lifeScore = _lifeScore;

            //We need to make sure that the players score stays since they still had another life
            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = true;

            //Here we are restarting the game
            GamePlayController.instance.PlayerDiedRestartTheGame();
        }
    }
}
