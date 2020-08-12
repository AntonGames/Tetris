using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayOnGameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = FindObjectOfType<LevelLoader>().myScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
