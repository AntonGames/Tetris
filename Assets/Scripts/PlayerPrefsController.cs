using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsController : MonoBehaviour
{
    const string DIFFICULTY_KEY = "difficulty";
    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 2f;

    const string FIRST_PLAYER = "first player";
    const string SECOND_PLAYER = "second player";
    const string THIRD_PLAYER = "third player";

    const string FIRST_SCORE = "first score";
    const string SECOND_SCORE = "second score";
    const string THIRD_SCORE = "third score";

    const string CURRENT_SCORE = "current score";

    public static void SetCurrentScoreToZero()
    {
        PlayerPrefs.SetInt(CURRENT_SCORE, 0);
    }

    public static void SetCurrentScore(int scoreValue)
    {
        int currentScore = GetCurrentScore();
        PlayerPrefs.SetInt(CURRENT_SCORE, currentScore + scoreValue);
    }

    public static int GetCurrentScore()
    {
        return PlayerPrefs.GetInt(CURRENT_SCORE);
    }

    public static int SetScore(int score)
    {
        if (GetScore(1) < score)
        {
            PlayerPrefs.SetInt(THIRD_SCORE, GetScore(2));
            PlayerPrefs.SetInt(SECOND_SCORE, GetScore(1));
            PlayerPrefs.SetInt(FIRST_SCORE, score);
            return 1;
        }
        else if (GetScore(2) < score)
        {
            PlayerPrefs.SetInt(THIRD_SCORE, GetScore(2));
            PlayerPrefs.SetInt(SECOND_SCORE, score);
            return 2;
        }
        else if (GetScore(3) < score)
        {
            PlayerPrefs.SetInt(THIRD_SCORE, score);
            return 3;
        }
        else
        {
            return 4;
        }
    }

    public static int GetScore(int playerNumber)
    {
        if (playerNumber == 1)
        {
            return PlayerPrefs.GetInt(FIRST_SCORE);
        }
        else if (playerNumber == 2)
        {
            return PlayerPrefs.GetInt(SECOND_SCORE);
        }
        else if (playerNumber == 3)
        {
            return PlayerPrefs.GetInt(THIRD_SCORE);
        }
        else
        {
            return 0;
        }
    }

    public static void SetPlayer(int playerNumber, string name)
    {
        if (playerNumber == 1)
        {
            PlayerPrefs.SetString(THIRD_PLAYER, GetPlayer(2));
            PlayerPrefs.SetString(SECOND_PLAYER, GetPlayer(1));
            PlayerPrefs.SetString(FIRST_PLAYER, name);
        }
        else if (playerNumber == 2)
        {
            PlayerPrefs.SetString(THIRD_PLAYER, GetPlayer(2));
            PlayerPrefs.SetString(SECOND_PLAYER, name);
        }
        else if (playerNumber == 3)
        {
            PlayerPrefs.SetString(THIRD_PLAYER, name);
        }
    }

    public static string GetPlayer(int playerNumber)
    {
        if (playerNumber == 1)
        {
            return PlayerPrefs.GetString(FIRST_PLAYER);
        }
        else if (playerNumber == 2)
        {
            return PlayerPrefs.GetString(SECOND_PLAYER);
        }
        else if (playerNumber == 3)
        {
            return PlayerPrefs.GetString(THIRD_PLAYER);
        }
        else
        {
            return " ";
        }
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty setting is not in range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}
