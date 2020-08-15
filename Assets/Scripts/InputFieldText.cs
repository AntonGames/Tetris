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
                PlayerPrefsController.SetPlayer(playerNumber, playerName);
                FindObjectOfType<HighestScoreTable>().SetPlayerNameAndScore();
                enterWasPressed = true;
            }
        }
    }
}
