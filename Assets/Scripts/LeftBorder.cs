﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBorder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Object>().borderHitLeft = true;
    }
}
