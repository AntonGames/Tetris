using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 0.5f;
    // Start is called before the first frame update

    private void Start()
    {
        Debug.Log(difficultySlider);
    }

    private void Update()
    {
        // Debug.Log(difficultySlider);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
    }
}
