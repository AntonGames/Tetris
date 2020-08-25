using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void LoadStartingScreen()
    {
        SceneManager.LoadScene("Starting Screen");
    }

    public void LoadStartingScreenFromOptionsScreen()
    {
        PlayerPrefsController.SetMusicBool(FindObjectOfType<MusicToggle>().GetComponent<Toggle>().isOn);
        PlayerPrefsController.SetSoundsBool(FindObjectOfType<SoundEffectsToggle>().GetComponent<Toggle>().isOn);
        PlayerPrefsController.SetDifficulty(FindObjectOfType<OptionsController>().difficultySlider.value);
        SceneManager.LoadScene("Starting Screen");
    }

    public void LoadGameOverScreen()
    {
        SceneManager.LoadScene("Game Over Screen");
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
