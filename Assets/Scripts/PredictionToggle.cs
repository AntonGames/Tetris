using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PredictionToggle : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Toggle>().isOn = PlayerPrefsController.GetPredicitionsBool();
    }
    // Update is called once per frame
    void Update()
    {
        // Saves music value
        if (!GetComponent<Toggle>().isOn)
        {
            PlayerPrefsController.SetPredictionsBool(false);
        }
        else if (GetComponent<Toggle>().isOn)
        {
            PlayerPrefsController.SetPredictionsBool(true);
        }
    }
}
