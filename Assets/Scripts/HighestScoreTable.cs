using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighestScoreTable : MonoBehaviour
{
    GameObject[] player = new GameObject[3];
    Text[] playerText = new Text[3];
    GameObject[] score = new GameObject[3];
    Text[] scoreText = new Text[3];

    private void ResetPlayerNameAndScore(int index)
    {
        playerText[index].text = PlayerPrefsController.GetPlayer(index + 1);

        scoreText[index].text = PlayerPrefsController.GetScore(index + 1) == 0 ?
                                "-" :
                                PlayerPrefsController.GetScore(index + 1).ToString();
    }

    void Start()
    {
        for (int index = 0; index < 3; ++index)
        {
            player[index] = transform.GetChild(index).gameObject;
            playerText[index] = player[index].GetComponent<Text>();
            score[index] = transform.GetChild(index + 3).gameObject;

            scoreText[index] = score[index].GetComponent<Text>();

            ResetPlayerNameAndScore(index);
        }

    }

    public void SetPlayerNameAndScore()
    {
        for (int index = 0; index < 3; ++index)
        {
            ResetPlayerNameAndScore(index);
        }
    }
}

