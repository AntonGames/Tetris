using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighestScoreTable : MonoBehaviour
{

    GameObject firstPlayer;
    GameObject secondPlayer;
    GameObject thirdPlayer;

    Text firstPlayerText;
    Text secondPlayerText;
    Text thirdPlayerText;

    GameObject firstScore;
    GameObject secondScore;
    GameObject thirdScore;

    Text firstScoreText;
    Text secondScoreText;
    Text thirdScoreText;

    void Start()
    {
        firstPlayer = transform.GetChild(0).gameObject;
        secondPlayer = transform.GetChild(1).gameObject;
        thirdPlayer = transform.GetChild(2).gameObject;

        firstPlayerText = firstPlayer.GetComponent<Text>();
        secondPlayerText = secondPlayer.GetComponent<Text>();
        thirdPlayerText = thirdPlayer.GetComponent<Text>();

        firstPlayerText.text = PlayerPrefsController.GetPlayer(1);
        secondPlayerText.text = PlayerPrefsController.GetPlayer(2);
        thirdPlayerText.text = PlayerPrefsController.GetPlayer(3);

        firstScore = transform.GetChild(3).gameObject;
        secondScore = transform.GetChild(4).gameObject;
        thirdScore = transform.GetChild(5).gameObject;

        firstScoreText = firstScore.GetComponent<Text>();
        secondScoreText = secondScore.GetComponent<Text>();
        thirdScoreText = thirdScore.GetComponent<Text>();

        if (PlayerPrefsController.GetScore(1) == 0)
        {
            firstScoreText.text = "-";
        }
        else
        {
            firstScoreText.text = PlayerPrefsController.GetScore(1).ToString();
        }
        if (PlayerPrefsController.GetScore(2) == 0)
        {
            secondScoreText.text = "-";
        }
        else
        {
            secondScoreText.text = PlayerPrefsController.GetScore(2).ToString();
        }
        if (PlayerPrefsController.GetScore(3) == 0)
        {
            thirdScoreText.text = "-";
        }
        else
        {
            thirdScoreText.text = PlayerPrefsController.GetScore(3).ToString();
        }
    }

    public void SetPlayerNameAndScore()
    {
        firstPlayerText.text = PlayerPrefsController.GetPlayer(1);
        secondPlayerText.text = PlayerPrefsController.GetPlayer(2);
        thirdPlayerText.text = PlayerPrefsController.GetPlayer(3);
        if (PlayerPrefsController.GetScore(1) == 0)
        {
            firstScoreText.text = "-";
        }
        else
        {
            firstScoreText.text = PlayerPrefsController.GetScore(1).ToString();
        }
        if (PlayerPrefsController.GetScore(2) == 0)
        {
            secondScoreText.text = "-";
        }
        else
        {
            secondScoreText.text = PlayerPrefsController.GetScore(2).ToString();
        }
        if (PlayerPrefsController.GetScore(3) == 0)
        {
            thirdScoreText.text = "-";
        }
        else
        {
            thirdScoreText.text = PlayerPrefsController.GetScore(3).ToString();
        }
    }
}
