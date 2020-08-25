using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int levelScore = 0;
    public int levelNumber = 1;
    int bonus = 0;
    Block[,] matrix;
    bool shiftIsActive = true;
    [SerializeField] int scoreValue = 132;

    private int MAX_X = 12;
    private int MAX_Y = 24;

    AudioSource myAudioSource;
    [SerializeField] AudioClip fullLineAudio;
    [SerializeField] [Range(0, 1)] float fullLineAudioVolume = 0.3f;
    [SerializeField] GameObject pause;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] GameObject predictionsCanvas;

    public void BuildMap()
    {
        BuildMatrix();
        CheckLines();
    }

    private void Awake()
    {
        predictionsCanvas.SetActive(PlayerPrefsController.GetPredicitionsBool());
        pauseCanvas.SetActive(false);
        myAudioSource = GetComponent<AudioSource>();
        PlayerPrefsController.SetCurrentScoreToZero();
        PlayerPrefsController.SetCurrentLevelToOne();
    }

    private void BuildMatrix()
    {
        matrix = new Block[MAX_X, MAX_Y];
        Block[] blocks = FindObjectsOfType<Block>();
        for (int i = 0; i < blocks.Length; ++i)
        {
            Object o = blocks[i].transform.parent.gameObject.GetComponent<Object>();
            if(!o.move)
            {
                int x, y;
                (x, y) = blocks[i].GetMapPosition();
                if (x >= 0 && x < MAX_X && y >= 0 && y < MAX_Y)
                {
                    matrix[x, y] = blocks[i];
                    matrix[x, y].disableCollision = true;
                }
            }
        }
    }

    public enum MovementType
    {
        MOVE_DOWN = 0,
        MOVE_LEFT = 1, 
        MOVE_RIGHT = 2, 
        MOVE_ROTATION = 3
    };

    private bool CheckMatixBorders(int x, int y)
    {
        if( x < 0 || x >= MAX_X || y < 0 || y >= MAX_Y || matrix[x, y])
        {
            return false;
        }
        return true;
    }
    public bool CheckMovement(Object obj, MovementType mt, int[,] newMap = null)
    {
        int[,] map = mt == MovementType.MOVE_ROTATION ? newMap : obj.map;
               
        // these are x and y coordinate modifiers for each movement type
        //                               X    Y
        int[,] modXY = new int[4, 2] { { 0 , -1 },      // MOVE_DOWN = 0,
                                       {-1 ,  0 },      // MOVE_LEFT = 1, 
                                       { 1 ,  0 } ,     // MOVE_RIGHT = 2, 
                                       { 0 ,  0 } , };  // MOVE_ROTATION = 3

        for (int row = 0; row < 4; ++row)
        {
            for (int col = 0; col < 4; ++col)
            {
                if (map[row, col] > 0)
                {
                    int x = Mathf.RoundToInt(obj.transform.position.x + col + 5.5f) + modXY[(int)mt, 0];
                    int y = Mathf.RoundToInt(obj.transform.position.y + row + 9.5f) + modXY[(int)mt, 1];

                    if(!CheckMatixBorders(x, y))
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
   
    private IEnumerator ShiftAllBlocksDown(bool[] RowToShift)
    {
        if (!shiftIsActive)
        {
            yield break;
        }
        yield return new WaitForSeconds(1f);

        for (int rowToShift = 0; rowToShift < MAX_Y; ++rowToShift)
        {
            if (RowToShift[rowToShift])
            {
                for(int row = rowToShift + 1; row < MAX_Y; ++row)
                {
                    for (int col = 0; col < MAX_X; ++col)
                    {
                        if (matrix[col, row])
                        {
                            matrix[col, row].transform.position =
                                new Vector2(matrix[col, row].transform.position.x, matrix[col, row].transform.position.y - 1);
                        }
                    }
                }
                
            }
        }      
        BuildMatrix();
        shiftIsActive = false;
    }

    private void CheckLines()
    {
        bool[] RowToShift = new bool[MAX_Y];
        bool fullLine = false;
        for (int row = 0; row < MAX_Y; ++row)
        {
            int count = 0;
            for (int col = 0; col < MAX_X; ++col)
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
                for (int col = 0; col < MAX_X; ++col)
                {
                    matrix[col, row].TriggerAnimation();
                }
                PlayerPrefsController.SetCurrentScore(scoreValue);
                levelScore += scoreValue;
                bonus += 1;
                fullLine = true;
            }
        }

        if (fullLine)
        {
            shiftIsActive = true;
            StartCoroutine(ShiftAllBlocksDown(RowToShift));
            if (bonus >= 2)
            {
                PlayerPrefsController.SetCurrentScore(scoreValue * bonus);
                levelScore += scoreValue * bonus;
            }
            if (levelScore >= 500)
            {
                levelScore = 0;
                levelNumber += 1;
                PlayerPrefsController.SetCurrentLevel(levelNumber);
            }
            bonus = 0;
            if (PlayerPrefsController.GetSoundsBool())
            {
                AudioClip fullLineClip = fullLineAudio;
                myAudioSource.PlayOneShot(fullLineClip, fullLineAudioVolume);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                pauseCanvas.SetActive(true);
                pause.GetComponent<Text>().text = "Pause";
                Time.timeScale = 0;
            }
            else if (Time.timeScale == 0)
            {
                pauseCanvas.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
