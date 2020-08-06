using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Block[,] matrix;
    bool shiftIsActive = true;
    
    //public static float MAP_SIZE_X = 5.5f;
    //public static float MAP_SIZE_Y = 9.5f;
    public void BuildMap()
    {
        BuildMatrix();
        CheckLines();
    }

    private void BuildMatrix()
    {
        matrix = new Block[12, 20];
        Block[] blocks = FindObjectsOfType<Block>();
        for (int i = 0; i < blocks.Length; ++i)
        {
            int x, y;
            (x, y) = blocks[i].GetMapPosition();
            if (x >= 0 && x < 12 && y >= 0 && y < 20)
            {
                matrix[x, y] = blocks[i];
                matrix[x, y].disableCollision = true;
            }
        }
    }

    public bool CheckRotation(Object obj, int[,] newMap)
    {
        for (int row = 0; row < 4; ++row)
        {
            for (int col = 0; col < 4; ++col)
            {
                if (newMap[row, col] > 0)
                {
                    int x = Mathf.RoundToInt(obj.transform.position.x + col + 5.5f);
                    int y = Mathf.RoundToInt(obj.transform.position.y + row + 9.5f);
                    if (x >= 0 && x < 12 && y >= 0 && y < 20)
                    {
                        if (matrix[x, y])
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    private IEnumerator ShiftAllBlocksDown(int startRow)
    {
        if (!shiftIsActive)
        {
            yield break;
        }
        yield return new WaitForSeconds(1f);
        if (startRow >= 20)
        {
            yield break;
        }
        for (int row = startRow + 1; row < 20; ++row)
        {
            for (int col = 0; col < 12; ++col)
            {
                if (matrix[col, row])
                {
                    matrix[col, row].transform.position = 
                        new Vector2(matrix[col, row].transform.position.x, matrix[col, row].transform.position.y - 1);
                }
            }
        }
        shiftIsActive = false;
    }

    private void CheckLines()
    {
        bool linesDeleted = false;
        bool[] RowToShift = new bool[20];
        for (int row = 0; row < 20; ++row)
        {
            int count = 0;
            for (int col = 0; col < 12; ++col)
            {
                Block b = matrix[col, row];
                if (b)
                {
                    ++count;
                }
            }
            if (count == 12)
            {
                RowToShift[row] = true;
                Debug.Log("Row " + row + " is full!");
                for (int col = 0; col < 12; ++col)
                {
                    matrix[col, row].TriggerAnimation();
                }
                //shiftIsActive = true;
                //ShiftAllBlocksDown(row);
                linesDeleted = true;
            }
        }
        if (linesDeleted)
        {
            BuildMatrix();
        }

        for (int row = 0; row < 20; ++row)
        {
            if (RowToShift[row])
            {
                shiftIsActive = true;
                StartCoroutine(ShiftAllBlocksDown(row));
            }
        }
    }
}
