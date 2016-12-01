using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    private GameObject easySign, mediumSign, hardSign;

	// Use this for initialization
	void Start()
    {
        SetTheDifficulty();
	}

    void SetInitialDifficulty(string difficulty)
    {
        //Here we are setting the correct sign the user choose to true and then the other two they dont too false.
        switch(difficulty)
        { 
            case "easy":
                setSigns(true, false, false);
                break;

            case "medium":
                setSigns(false, true, false);
                break;

            case "hard":
                setSigns(false, false, true);
                break;
        }
    }

    void SetTheDifficulty()
    { //Depending on the diffiulty chosen we are setting the states by sending the correct function to the SetInitialDifficulty() method
        if(GamePreferences.GetEasyDifficultyState() == 1)
        {
            SetInitialDifficulty("easy");
        }
        else if (GamePreferences.GetMediumDifficultyState() == 1)
        {
            SetInitialDifficulty("medium");
        }
        else if (GamePreferences.GetHardDifficultyState() == 1)
        {
            SetInitialDifficulty("hard");
        }
    }

    void setSigns(bool easy, bool medium, bool hard)
    {//Setting status of signs
        easySign.SetActive(easy);
        mediumSign.SetActive(medium);
        hardSign.SetActive(hard);
    }

    public void EasyDifficulty()
    {
        SetDefficultyTrueFalse(1,0,0);
        setSigns(true, false, false);
    }

    public void MediumDifficulty()
    {
        SetDefficultyTrueFalse(0, 1, 0);
        setSigns(false, true, false);
    }

    public void HardDifficulty()
    {
        SetDefficultyTrueFalse(0, 0, 1);
        setSigns(false, false, true);
    }

    void SetDefficultyTrueFalse(int easy, int medium, int hard)
    {// 1 = true, 0 = false
        GamePreferences.SetEasyDifficultyState(easy);
        GamePreferences.SetMediumDifficultyState(medium);
        GamePreferences.SetHardDifficultyState(hard);
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
