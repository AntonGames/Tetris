using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
    public void LoadMainScene()
    {
        PlayerPrefsController.SetDifficulty(FindObjectOfType<OptionsController>().difficultySlider.value);
        SceneManager.LoadScene("Main Scene");
    }

    public void LoadStartingScreen()
    {
        SceneManager.LoadScene("Starting Screen");
    }

    public void LoadGameOverScreen()
    {
        SceneManager.LoadScene("Game Over Screen");
    }

}
