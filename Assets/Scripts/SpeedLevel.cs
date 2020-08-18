using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedLevel : MonoBehaviour
{
    private int levelNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelNumber = FindObjectOfType<GameController>().levelNumber;
        GetComponent<Text>().text = "Level " + levelNumber.ToString();
    }
}
