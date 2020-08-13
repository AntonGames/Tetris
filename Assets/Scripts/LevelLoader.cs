using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex;

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

    public void LoadStartingScreen()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene("Starting Screen");
    }

    public void LoadGameOverScreen()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene("Game Over Screen");
    }

}
