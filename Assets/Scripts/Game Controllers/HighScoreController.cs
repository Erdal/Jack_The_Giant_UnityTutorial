using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HighScoreController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText, coinText;


	void Start ()
    {
        SetScoreBasedOnDifficulty();
	}

    //Used to set score text and coin text
    void SetScore(int score, int coinScore)
    {
        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();
    }

    //Set score based on diffvuilty player chooses
    void SetScoreBasedOnDifficulty()
    {
        if(GamePreferences.GetEasyDifficultyState() == 1)
        {//If user choose easy
            SetScore(GamePreferences.GetEasyDifficultyHighScoreState(), GamePreferences.GetEasyDifficultyCoinScoreState());
        }
        else if (GamePreferences.GetMediumDifficultyState() == 1)
        {//If user choose medium
            SetScore(GamePreferences.GetMediumDifficultyHighScoreState(), GamePreferences.GetMediumDifficultyCoinScoreState());
        }
        else if (GamePreferences.GetHardDifficultyState() == 1)
        {//If user choose hard
            SetScore(GamePreferences.GetHardDifficultyHighScoreState(), GamePreferences.GetHardDifficultyCoinScoreState());
        }
    }
	
	public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
