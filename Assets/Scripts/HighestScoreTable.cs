using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighestScoreTable : MonoBehaviour
{
    GameObject[] player = new GameObject[5];
    Text[] playerText = new Text[5];
    GameObject[] score = new GameObject[5];
    Text[] scoreText = new Text[5];
    GameObject[] level = new GameObject[5];
    Text[] levelText = new Text[5];

    private void ResetPlayerNameAndScore(int index)
    {
        playerText[index].text = PlayerPrefsController.GetPlayer(index + 1);

        scoreText[index].text = PlayerPrefsController.GetScore(index + 1) == 0 ?
                                "-" :
                                PlayerPrefsController.GetScore(index + 1).ToString();
        levelText[index].text = PlayerPrefsController.GetScore(index + 1) == 0 ?
                                "-" :
                                PlayerPrefsController.GetLevel(index + 1);
    }

    void Start()
    {
        for (int index = 0; index < 5; ++index)
        {
            player[index] = transform.GetChild(index).gameObject;
            playerText[index] = player[index].GetComponent<Text>();
            score[index] = transform.GetChild(index + 5).gameObject;
            scoreText[index] = score[index].GetComponent<Text>();
            level[index] = transform.GetChild(index + 10).gameObject;
            levelText[index] = level[index].GetComponent<Text>();

            ResetPlayerNameAndScore(index);
        }

    }

    public void SetPlayerNameAndScore()
    {
        for (int index = 0; index < 5; ++index)
        {
            ResetPlayerNameAndScore(index);
        }
    }
}

