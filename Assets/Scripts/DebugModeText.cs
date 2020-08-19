using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugModeText : MonoBehaviour
{
    private bool debugMode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        debugMode = FindObjectOfType<DebugMode>().debugMode;
        GetComponent<Text>().text = debugMode ? "Debug Mode" : "";
    }
}
