using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBorder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Object>().borderHitRight = true;
    }
}
