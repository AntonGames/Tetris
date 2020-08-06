using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public bool move = true;
    public bool borderHitLeft = false;
    public bool borderHitRight = false;

    protected GameObject[] block = new GameObject[4];
    float difficulty;
    float timeToMove;
    //private int rotation = 0;

    GameController gc; 

    protected int[,] map = new int[4, 4];

    private void Awake()
    {
        gc = FindObjectOfType<GameController>();
        for (int i = 0; i < 4; ++i)
        {
            block[i] = transform.GetChild(i).gameObject;
        }
        SetBlockMap();
        SetBlockPosition();
        difficulty = PlayerPrefsController.GetDifficulty();
        timeToMove = 2.25f - difficulty;
    }

    IEnumerator Start()
    {
        while (move)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            // FindObjectOfType<GameController>().BuildMap();
            // Move();
            yield return new WaitForSeconds(timeToMove);
        }
    }

    virtual public void Move() { }
    private void SetBlockPosition()
    {
        int i = 0;
        for (int row = 0; row < 4; ++row)
        {
            for (int col = 0; col < 4; ++col)
            {
                if (map[row, col] > 0)
                {
                    block[i].transform.position = new Vector2(transform.position.x + col, transform.position.y + row);
                    ++i;
                }
            }
        }
    }

    protected virtual void SetBlockMap() { }

    private void Rotate()
    {
        borderHitLeft = false;
        borderHitRight = false;
        int[,] newMap = new int[4, 4];
        for (int row = 0; row < 4; ++row)
        {
            for (int col = 0; col < 4; ++col)
            {
                newMap[row, col] = map[col, 3 - row]; 
            }
        }
        if (gc.CheckRotation(this, newMap))
        {
            map = newMap;
            SetBlockPosition();
        }
    }
    //public void BackRotation()
    //{
    //    borderHitLeft = false;
    //    borderHitRight = false;
    //    Debug.Log("BackRotation");
    //    rotation -= 90;
    //    transform.rotation = Quaternion.Euler(Vector3.forward * rotation);
    //}

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Full Object" && move)
        {
            BackRotation();
        }
    }*/

    private void Update()
    {
        if (move)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && !borderHitLeft)
            {
                transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                borderHitRight = false;

            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && !borderHitRight)
            {
                transform.position = new Vector2(transform.position.x + 1, transform.position.y);
                borderHitLeft = false;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Rotate();
                // borderHitLeft = false;
                // borderHitRight = false;
                // rotation += 90;
                // if (rotation == 360)
                // { rotation = 0; }
                // transform.rotation = Quaternion.Euler(Vector3.forward * rotation);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                timeToMove = 0.05f;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                timeToMove = 2.25f - difficulty;
            }
        }
    }
}
