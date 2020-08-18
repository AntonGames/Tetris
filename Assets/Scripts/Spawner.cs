using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] objectsArray;
    [SerializeField] GameObject[] debugObjectsArray;
    private GameObject[] objArray;

    public bool spawn = true;

    public bool debugMode = false;
    /* void Awake()
     {
         debugMode = FindObjectOfType<DebugMode>().debugMode;
         objArray = debugMode ? debugObjectsArray : objectsArray;
     }*/

    // Start is called before the first frame update
    void Update()
    {
        debugMode = FindObjectOfType<DebugMode>().debugMode;
        objArray = debugMode == true ? debugObjectsArray : objectsArray;

        while (spawn)
        {
            var attackerIndex = Random.Range(0, objArray.Length);
            Spawn(objArray[attackerIndex]);
            spawn = false;
        }
    }

    private void Spawn (GameObject myObject)
    {
        FindObjectOfType<GameController>().BuildMap();
        GameObject newGameObject = Instantiate(myObject, transform.position, transform.rotation) as GameObject;
        newGameObject.transform.parent = transform;
    }

}
