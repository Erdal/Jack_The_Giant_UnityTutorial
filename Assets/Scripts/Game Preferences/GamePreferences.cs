using UnityEngine;
using System.Collections;

public static class GamePreferences
{
    //We are creating all of our preferences and what not that the palyer has
    //Also going to use integers in blace of bool since PlayerPref does not support bool, i do not know why, it damn well should
    //0 = false, 1 = true
    public static string EasyDifficulty = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty = "HardDifficulty";

    public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
    public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";
    public static string HardDifficultyHighScore = "HardDifficultyHighScore";

    public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
    public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

    public static string IsMusic = "IsMusic";

    public static void SetEasyDifficultyState(int state)
    { //Setter for EasyDifficulty
        PlayerPrefs.SetInt(GamePreferences.EasyDifficulty, state);
    }

    public static int GetEasyDifficultyState()
    {//Getter for EasyDifficulty
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficulty);
    }

    public static void SetMediumDifficultyState(int state)
    { //Setter for MediumDifficulty
        PlayerPrefs.SetInt(GamePreferences.MediumDifficulty, state);
    }

    public static int GetMediumDifficultyState()
    {//Getter for MediumDifficulty
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficulty);
    }

    public static void SetHardDifficultyState(int state)
    { //Setter for HardDifficulty
        PlayerPrefs.SetInt(GamePreferences.HardDifficulty, state);
    }

    public static int GetHardDifficultyState()
    {//Getter for HardDifficulty
        return PlayerPrefs.GetInt(GamePreferences.HardDifficulty);
    }

    public static void SetEasyDifficultyHighScoreState(int state)
    { //Setter for EasyDifficultyHighScore
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyHighScore, state);
    }

    public static int GetEasyDifficultyHighScoreState()
    {//Getter for EasyDifficultyHighScore
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyHighScore);
    }

    public static void SetMediumDifficultyHighScoreState(int state)
    { //Setter for MediumDifficultyHighScore
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyHighScore, state);
    }

    public static int GetMediumDifficultyHighScoreState()
    {//Getter for MediumDifficulty
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyHighScore);
    }

    public static void SetHardDifficultyHighScoreState(int state)
    { //Setter for HardDifficultyHighScore
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyHighScore, state);
    }

    public static int GetHardDifficultyHighScoreState()
    {//Getter for HardDifficultyHighScore
        return PlayerPrefs.GetInt(GamePreferences.HardDifficultyHighScore);
    }

    public static void SetEasyDifficultyCoinScoreState(int state)
    { //Setter for EasyDifficultyCoinScore
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyCoinScore, state);
    }

    public static int GetEasyDifficultyCoinScoreState()
    {//Getter for EasyDifficultyCoinScore
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyCoinScore);
    }

    public static void SetMediumDifficultyCoinScoreState(int state)
    { //Setter for MediumDifficultyCoinScore
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyCoinScore, state);
    }

    public static int GetMediumDifficultyCoinScoreState()
    {//Getter for MediumDifficultyCoinScore
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyCoinScore);
    }

    public static void SetHardDifficultyCoinScoreState(int state)
    { //Setter for HardDifficultyCoinScore
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyCoinScore, state);
    }

    public static int GetHardDifficultyCoinScoreState()
    {//Getter for HardDifficultyCoinScore
        return PlayerPrefs.GetInt(GamePreferences.HardDifficultyCoinScore);
    }

    public static void SetIsMusicState(int state)
    { //Setter for IsMusicOn
        PlayerPrefs.SetInt(GamePreferences.IsMusic, state);
    }

    public static int GetIsMusicState()
    {//Getter for IsMusicOn
        return PlayerPrefs.GetInt(GamePreferences.IsMusic);
    }
}
