using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HighScoreController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
