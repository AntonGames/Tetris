using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldText : MonoBehaviour
{
    [SerializeField] Text mainText;
    bool enterWasPressed = false;

    void Update()
    {
        if (!enterWasPressed)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                GetComponent<InputField>().readOnly = true;
                int playerNumber = PlayerPrefsController.SetScore(PlayerPrefsController.GetCurrentScore());
                string playerName = mainText.GetComponent<Text>().text;
                int levelNumber = PlayerPrefsController.GetCurrentLevel();
                string levelText = "Level " + levelNumber.ToString();
                PlayerPrefsController.SetPlayer(playerNumber, playerName);
                PlayerPrefsController.SetLevel(playerNumber, levelText);
                FindObjectOfType<HighestScoreTable>().SetPlayerNameAndScore();
                enterWasPressed = true;
            }
        }
    }
}
