using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool disableCollision = false;
    Animator animator;
    bool isCoroutineExecuting = true;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border" || disableCollision)
            return;
        float coltrX = Mathf.Round(collision.transform.position.x * 10.0f) * 0.1f;
        float trX = Mathf.Round(transform.position.x * 10.0f) * 0.1f;
        //float coltrY = Mathf.Round(collision.transform.position.y * 10.0f) * 0.1f;
        //float trY = Mathf.Round(transform.position.y * 10.0f) * 0.1f;

        if (coltrX == trX && collision.tag == "Block" || collision.tag == "Shredder")
        {
            Debug.Log("Collision!!!");
            Debug.Log(collision);
            FindObjectOfType<Object>().move = false;
            FindObjectOfType<Spawner>().spawn = true;
        }
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

    //private void Register()
    //{
    //    Block[,] matrix = new Block[12, 20];
    //    Block[] blocks = FindObjectsOfType<Block>();
    //    for (int i = 0; i < blocks.Length; ++i)
    //    {
    //        int x = Mathf.RoundToInt(blocks[i].transform.position.x + 5.5f);
    //        int y = Mathf.RoundToInt(blocks[i].transform.position.y + 9.5f);
    //        matrix[x, y] = blocks[i];
    //    }
    //    for (int row = 0; row < 20; ++row)
    //    {
    //        int count = 0;
    //        for (int col = 0; col < 12; ++col)
    //        {
    //            Block b = matrix[col, row];
    //            if (b)
    //            {
    //                ++count;
    //            }
    //        }
    //        if (count == 12)
    //        {
    //            Debug.Log("Row " + row + " is full!");
    //            Destroy();
    //            // TODO add code to remove line
    //            //b.transform.position =
    //            //     new Vector2(b.transform.position.x, b.transform.position.y - 1);
    //        }
    //    }
    //}
}
