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

    public static string IsMusicOn = "IsMusicOn";

    public static void SetEasyDifficulty(int state)
    { //Setter for EasyDifficulty
        PlayerPrefs.SetInt(GamePreferences.EasyDifficulty, state);
    }

    public static int GetEasyDifficulty()
    {//Getter for EasyDifficulty
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficulty);
    }

    public static void SetMediumDifficulty(int state)
    { //Setter for MediumDifficulty
        PlayerPrefs.SetInt(GamePreferences.MediumDifficulty, state);
    }

    public static int GetMediumDifficulty()
    {//Getter for MediumDifficulty
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficulty);
    }

    public static void SetHardDifficulty(int state)
    { //Setter for HardDifficulty
        PlayerPrefs.SetInt(GamePreferences.HardDifficulty, state);
    }

    public static int GetHardDifficulty()
    {//Getter for HardDifficulty
        return PlayerPrefs.GetInt(GamePreferences.HardDifficulty);
    }

    public static void SetEasyDifficultyHighScore(int state)
    { //Setter for EasyDifficultyHighScore
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyHighScore, state);
    }

    public static int GetEasyDifficultyHighScore()
    {//Getter for EasyDifficultyHighScore
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyHighScore);
    }

    public static void SetMediumDifficultyHighScore(int state)
    { //Setter for MediumDifficultyHighScore
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyHighScore, state);
    }

    public static int GetMediumDifficultyHighScore()
    {//Getter for MediumDifficulty
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyHighScore);
    }

    public static void SetHardDifficultyHighScore(int state)
    { //Setter for HardDifficultyHighScore
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyHighScore, state);
    }

    public static int GetHardDifficultyHighScore()
    {//Getter for HardDifficultyHighScore
        return PlayerPrefs.GetInt(GamePreferences.HardDifficultyHighScore);
    }

    public static void SetEasyDifficultyCoinScore(int state)
    { //Setter for EasyDifficultyCoinScore
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyCoinScore, state);
    }

    public static int GetEasyDifficultyCoinScore()
    {//Getter for EasyDifficultyCoinScore
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyCoinScore);
    }

    public static void SetMediumDifficultyCoinScore(int state)
    { //Setter for MediumDifficultyCoinScore
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyCoinScore, state);
    }

    public static int GetMediumDifficultyCoinScore()
    {//Getter for MediumDifficultyCoinScore
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyCoinScore);
    }

    public static void SetHardDifficultyCoinScore(int state)
    { //Setter for HardDifficultyCoinScore
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyCoinScore, state);
    }

    public static int GetHardDifficultyCoinScore()
    {//Getter for HardDifficultyCoinScore
        return PlayerPrefs.GetInt(GamePreferences.HardDifficultyCoinScore);
    }

    public static void SetIsMusicOn(int state)
    { //Setter for IsMusicOn
        PlayerPrefs.SetInt(GamePreferences.IsMusicOn, state);
    }

    public static int GetIsMusicOn()
    {//Getter for IsMusicOn
        return PlayerPrefs.GetInt(GamePreferences.IsMusicOn);
    }
}
