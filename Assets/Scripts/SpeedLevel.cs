using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public string GetLevelText()
    {
        UpdateLevelText();
        return GetComponent<Text>().text;
    }

    private void UpdateLevelText()
    {
        int levelNumber = PlayerPrefsController.GetCurrentLevel();
        GetComponent<Text>().text = "Level " + levelNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLevelText();
    }
}
