﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugModeText : MonoBehaviour
{
    private bool debugMode;
    // Start is called before the first frame update
    void Start()
    {
        debugMode = FindObjectOfType<DebugMode>().debugMode;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = debugMode ? "Debug Mode" : "";
    }
}
