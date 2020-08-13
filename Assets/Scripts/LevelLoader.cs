using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex;
    public int myScore;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameController>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadMainScene()
    {
        PlayerPrefsController.SetDifficulty(FindObjectOfType<OptionsController>().difficultySlider.value);
        SceneManager.LoadScene("Main Scene");
    }

    public void LoadMainSceneFromGameOver()
    {
        PlayerPrefsController.SetDifficulty(FindObjectOfType<OptionsController>().difficultySlider.value);
        int playerNumber = PlayerPrefsController.SetScore(myScore);
        string playerName = FindObjectOfType<InputFieldText>().GetComponent<Text>().text;
        PlayerPrefsController.SetPlayer(playerNumber, playerName);
        SceneManager.LoadScene("Main Scene");
    }

    public void LoadStartingScreen()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene("Starting Screen");
    }

    public void LoadGameOverScreen()
    {
        //Time.timeScale = 1;
        myScore = FindObjectOfType<GameController>().score;
        SceneManager.LoadScene("Game Over Screen");
    }

}
