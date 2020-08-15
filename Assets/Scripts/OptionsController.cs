using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] public Slider difficultySlider;

    private void Start()
    {
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
        Debug.Log(difficultySlider);
    }

    private void Update()
    {
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
    }
}
