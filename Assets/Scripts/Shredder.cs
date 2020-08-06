using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Block[,] matrix = new Block[12, 20];
                
        Block[] blocks = FindObjectsOfType<Block>();
        for (int i = 0; i < blocks.Length; ++i)
        {
            // Debug.Log("X : " + (blocks[i].transform.position.x + 5.5));
            // Debug.Log("Y : " + (blocks[i].transform.position.y + 9.5));
            int x = Mathf.RoundToInt(blocks[i].transform.position.x + 5.5f);
            int y = Mathf.RoundToInt(blocks[i].transform.position.y + 9.5f);

            matrix[x, y] = blocks[i];
        }

        for(int row = 0; row < 20; ++row)
        {
            int count = 0;
            for(int col = 0; col < 12; ++col)
            {
                Block b = matrix[col, row];
                if (b)
                {
                    ++count;
                  
                }
            }

            if( count == 12)
            {
                // TODO add code to remove line
                //b.transform.position =
                //     new Vector2(b.transform.position.x, b.transform.position.y - 1);
            }
        }

        FindObjectOfType<Object>().move = false;
        FindObjectOfType<Spawner>().spawn = true;
    }*/
}
