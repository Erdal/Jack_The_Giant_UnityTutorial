﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
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

    }
}