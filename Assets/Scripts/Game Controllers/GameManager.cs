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

    void Start()
    {
        InitializeVariables();
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

    void InitializeVariables()
    {
        //The automatic difficulty are game starts at will be medium, everything else we will set to 0 for now as a clean slate
        if(!PlayerPrefs.HasKey("Game Initialized"))
        {
            GamePreferences.SetEasyDifficultyState(0);
            GamePreferences.SetEasyDifficultyCoinScore(0);
            GamePreferences.SetEasyDifficultyHighScore(0);

            GamePreferences.SetMediumDifficultyState(1);
            GamePreferences.SetMediumDifficultyCoinScore(0);
            GamePreferences.SetMediumDifficultyHighScore(0);

            GamePreferences.SetHardDifficultyState(0);
            GamePreferences.SetHardDifficultyCoinScore(0);
            GamePreferences.SetHardDifficultyHighScore(0);

            GamePreferences.SetIsMusicState(0);

            PlayerPrefs.SetInt("Game Initialized", 1); //To make sure we dont always call this if statment
        }
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
            //Setting the new high score, if there is a new high score to set
            if(GamePreferences.GetEasyDifficultyState() == 1)
            {
                int highScore = GamePreferences.GetEasyDifficultyHighScore();
                int coinHighScore = GamePreferences.GetEasyDifficultyCoinScore();

                if(highScore < _score)
                {
                    GamePreferences.SetEasyDifficultyHighScore(_score);
                }

                if(coinHighScore < _coinScore)
                {
                    GamePreferences.SetEasyDifficultyCoinScore(_coinScore);
                }
            }
            else if (GamePreferences.GetMediumDifficultyState() == 1)
            {
                int highScore = GamePreferences.GetMediumDifficultyHighScore();
                int coinHighScore = GamePreferences.GetMediumDifficultyCoinScore();

                if (highScore < _score)
                {
                    GamePreferences.SetMediumDifficultyHighScore(_score);
                }

                if (coinHighScore < _coinScore)
                {
                    GamePreferences.SetMediumDifficultyCoinScore(_coinScore);
                }
            }
            else if (GamePreferences.GetHardDifficultyState() == 1)
            {
                int highScore = GamePreferences.GetHardDifficultyHighScore();
                int coinHighScore = GamePreferences.GetHardDifficultyCoinScore();

                if (highScore < _score)
                {
                    GamePreferences.SetHardDifficultyHighScore(_score);
                }

                if (coinHighScore < _coinScore)
                {
                    GamePreferences.SetHardDifficultyCoinScore(_coinScore);
                }
            }

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
