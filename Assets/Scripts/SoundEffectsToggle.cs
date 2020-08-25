using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsToggle : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Toggle>().isOn = PlayerPrefsController.GetSoundsBool();
    }
    // Update is called once per frame
    void Update()
    {
        // Saves sound value
        PlayerPrefsController.SetSoundsBool(GetComponent<Toggle>().isOn);
    }
}
