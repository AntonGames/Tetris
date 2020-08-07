using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool disableCollision = false;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
  
    public (int, int) GetMapPosition()
    {
        int x = Mathf.RoundToInt(transform.position.x + 5.5f);
        int y = Mathf.RoundToInt(transform.position.y + 9.5f);
        return (x, y);
    }

    public void TriggerAnimation()
    {
        animator.SetTrigger("BlockDisappear");
    }

    public void DestroyBlock()
    {
        Destroy(gameObject);
    }
}
