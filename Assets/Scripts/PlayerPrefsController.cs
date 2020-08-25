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
    const string FOURTH_PLAYER = "fourth player";
    const string FIFTH_PLAYER = "fifth player";

    const string FIRST_SCORE = "first score";
    const string SECOND_SCORE = "second score";
    const string THIRD_SCORE = "third score";
    const string FOURTH_SCORE = "fourth score";
    const string FIFTH_SCORE = "fifth score";

    const string FIRST_LEVEL = "first level";
    const string SECOND_LEVEL = "second level";
    const string THIRD_LEVEL = "third level";
    const string FOURTH_LEVEL = "fourth level";
    const string FIFTH_LEVEL = "fifth level";

    const string CURRENT_SCORE = "current score";
    const string CURRENT_LEVEL = "current level";

    const string MUSIC_BOOL = "music bool";
    const string SOUNDS_BOOL = "sounds bool";
    const string PREDICTIONS_BOOL = "predictions bool";

    

    public static void SetPredictionsBool(bool prediction)
    {
        PlayerPrefs.SetInt(PREDICTIONS_BOOL, prediction ? 0 : 1);
    }

    public static bool GetPredicitionsBool()
    {
        int value = PlayerPrefs.GetInt(PREDICTIONS_BOOL);
        if (value == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void SetMusicBool(bool music)
    {
        PlayerPrefs.SetInt(MUSIC_BOOL, music ? 0 : 1);
        FindObjectOfType<MusicPlayer>().Mute(!music);
    }

    public static bool GetMusicBool()
    {
        int value = PlayerPrefs.GetInt(MUSIC_BOOL);
        if (value == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void SetSoundsBool(bool sounds)
    {
        PlayerPrefs.SetInt(SOUNDS_BOOL, sounds ? 0 : 1);
    }

    public static bool GetSoundsBool()
    {
        int value = PlayerPrefs.GetInt(SOUNDS_BOOL);
        if (value == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void SetLevel(int playerNumber, string level)
    {
        if (playerNumber == 1)
        {
            PlayerPrefs.SetString(FIFTH_LEVEL, GetLevel(4));
            PlayerPrefs.SetString(FOURTH_LEVEL, GetLevel(3));
            PlayerPrefs.SetString(THIRD_LEVEL, GetLevel(2));
            PlayerPrefs.SetString(SECOND_LEVEL, GetLevel(1));
            PlayerPrefs.SetString(FIRST_LEVEL, level);
        }
        else if (playerNumber == 2)
        {
            PlayerPrefs.SetString(FIFTH_LEVEL, GetLevel(4));
            PlayerPrefs.SetString(FOURTH_LEVEL, GetLevel(3));
            PlayerPrefs.SetString(THIRD_LEVEL, GetLevel(2));
            PlayerPrefs.SetString(SECOND_LEVEL, level);
        }
        else if (playerNumber == 3)
        {
            PlayerPrefs.SetString(FIFTH_LEVEL, GetLevel(4));
            PlayerPrefs.SetString(FOURTH_LEVEL, GetLevel(3));
            PlayerPrefs.SetString(THIRD_LEVEL, level);
        }
        else if (playerNumber == 4)
        {
            PlayerPrefs.SetString(FIFTH_LEVEL, GetLevel(4));
            PlayerPrefs.SetString(FOURTH_LEVEL, level);
        }
        else if (playerNumber == 5)
        {
            PlayerPrefs.SetString(FIFTH_LEVEL, level);
        }
    }

    public static string GetLevel(int playerNumber)
    {
        if (playerNumber == 1)
        {
            return PlayerPrefs.GetString(FIRST_LEVEL);
        }
        else if (playerNumber == 2)
        {
            return PlayerPrefs.GetString(SECOND_LEVEL);
        }
        else if (playerNumber == 3)
        {
            return PlayerPrefs.GetString(THIRD_LEVEL);
        }
        else if (playerNumber == 4)
        {
            return PlayerPrefs.GetString(FOURTH_LEVEL);
        }
        else if (playerNumber == 5)
        {
            return PlayerPrefs.GetString(FIFTH_LEVEL);
        }
        else
        {
            return " ";
        }
    }

    public static void SetCurrentLevelToOne()
    {
        PlayerPrefs.SetInt(CURRENT_LEVEL, 1);
    }

    public static void SetCurrentLevel(int levelValue)
    {
        PlayerPrefs.SetInt(CURRENT_LEVEL, levelValue);
    }

    public static int GetCurrentLevel()
    {
        return PlayerPrefs.GetInt(CURRENT_LEVEL);
    }

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
            PlayerPrefs.SetInt(FIFTH_SCORE, GetScore(4));
            PlayerPrefs.SetInt(FOURTH_SCORE, GetScore(3));
            PlayerPrefs.SetInt(THIRD_SCORE, GetScore(2));
            PlayerPrefs.SetInt(SECOND_SCORE, GetScore(1));
            PlayerPrefs.SetInt(FIRST_SCORE, score);
            return 1;
        }
        else if (GetScore(2) < score)
        {
            PlayerPrefs.SetInt(FIFTH_SCORE, GetScore(4));
            PlayerPrefs.SetInt(FOURTH_SCORE, GetScore(3));
            PlayerPrefs.SetInt(THIRD_SCORE, GetScore(2));
            PlayerPrefs.SetInt(SECOND_SCORE, score);
            return 2;
        }
        else if (GetScore(3) < score)
        {
            PlayerPrefs.SetInt(FIFTH_SCORE, GetScore(4));
            PlayerPrefs.SetInt(FOURTH_SCORE, GetScore(3));
            PlayerPrefs.SetInt(THIRD_SCORE, score);
            return 3;
        }
        else if (GetScore(4) < score)
        {
            PlayerPrefs.SetInt(FIFTH_SCORE, GetScore(4));
            PlayerPrefs.SetInt(FOURTH_SCORE, score);
            return 4;
        }
        else if (GetScore(5) < score)
        {
            PlayerPrefs.SetInt(FIFTH_SCORE, score);
            return 5;
        }
        else
        {
            return 6;
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
        else if (playerNumber == 4)
        {
            return PlayerPrefs.GetInt(FOURTH_SCORE);
        }
        else if (playerNumber == 5)
        {
            return PlayerPrefs.GetInt(FIFTH_SCORE);
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
            PlayerPrefs.SetString(FIFTH_PLAYER, GetPlayer(4));
            PlayerPrefs.SetString(FOURTH_PLAYER, GetPlayer(3));
            PlayerPrefs.SetString(THIRD_PLAYER, GetPlayer(2));
            PlayerPrefs.SetString(SECOND_PLAYER, GetPlayer(1));
            PlayerPrefs.SetString(FIRST_PLAYER, name);
        }
        else if (playerNumber == 2)
        {
            PlayerPrefs.SetString(FIFTH_PLAYER, GetPlayer(4));
            PlayerPrefs.SetString(FOURTH_PLAYER, GetPlayer(3));
            PlayerPrefs.SetString(THIRD_PLAYER, GetPlayer(2));
            PlayerPrefs.SetString(SECOND_PLAYER, name);
        }
        else if (playerNumber == 3)
        {
            PlayerPrefs.SetString(FIFTH_PLAYER, GetPlayer(4));
            PlayerPrefs.SetString(FOURTH_PLAYER, GetPlayer(3));
            PlayerPrefs.SetString(THIRD_PLAYER, name);
        }
        else if (playerNumber == 4)
        {
            PlayerPrefs.SetString(FIFTH_PLAYER, GetPlayer(4));
            PlayerPrefs.SetString(FOURTH_PLAYER, name);
        }
        else if (playerNumber == 5)
        {
            PlayerPrefs.SetString(FIFTH_PLAYER, name);
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
        else if (playerNumber == 4)
        {
            return PlayerPrefs.GetString(FOURTH_PLAYER);
        }
        else if (playerNumber == 5)
        {
            return PlayerPrefs.GetString(FIFTH_PLAYER);
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
