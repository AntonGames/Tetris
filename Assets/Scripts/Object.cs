using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public bool move = true;
    protected GameObject[] block = new GameObject[4];
    
    float difficulty;
    float timeToMove;
   
    GameController gc;
    Spawner sp;

    public int[,] map = new int[4, 4];

    private void Awake()
    {
        gc = FindObjectOfType<GameController>();
        sp = FindObjectOfType<Spawner>();

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
            if(gc.CheckMovement(this, GameController.MovementType.MOVE_DOWN))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 1);
                yield return new WaitForSeconds(timeToMove);
            } 
            else 
            {
                move = false;
                if (transform.position.y >= 6.5)
                {
                    FindObjectOfType<LevelLoader>().LoadGameOverScreen();
                }
                sp.spawn = true;
            }
            
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
        int[,] newMap = new int[4, 4];
        for (int row = 0; row < 4; ++row)
        {
            for (int col = 0; col < 4; ++col)
            {
                newMap[row, col] = map[col, 3 - row]; 
            }
        }
    
        if (gc.CheckMovement(this, GameController.MovementType.MOVE_ROTATION ,newMap))
        {
            map = newMap;
            SetBlockPosition();
        }
    }
   
    private void Update()
    {
        if (move)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (gc.CheckMovement(this, GameController.MovementType.MOVE_LEFT))
                {
                    transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (gc.CheckMovement(this, GameController.MovementType.MOVE_RIGHT))
                {
                    transform.position = new Vector2(transform.position.x + 1, transform.position.y);
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Rotate();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (gc.CheckMovement(this, GameController.MovementType.MOVE_DOWN))
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - 1);
                }
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
