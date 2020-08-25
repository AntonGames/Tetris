using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Toggle>().isOn = PlayerPrefsController.GetMusicBool();
    }
    // Update is called once per frame
    void Update()
    {
        // Saves music value
        if (!GetComponent<Toggle>().isOn)
        {
            PlayerPrefsController.SetMusicBool(false);
        }
        else if (GetComponent<Toggle>().isOn)
        {
            PlayerPrefsController.SetMusicBool(true);
        }
    }
        
}
