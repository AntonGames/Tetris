using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] objectsArray;
    [SerializeField] GameObject[] debugObjectsArray;
    private GameObject[] objArray;
    int indexToSpawn;

    public bool spawn = true;

    public bool debugMode = false;

    private void Start()
    {
        if (PlayerPrefsController.GetPredicitionsBool())
        {
            Prediction();
        }
        else if (!PlayerPrefsController.GetPredicitionsBool())
        {
            SetArray();
            Destroy(transform.GetChild(0).gameObject.transform.GetChild(0).gameObject);
            indexToSpawn = Random.Range(0, objArray.Length);
        }
    }

    private void SetArray()
    {
        debugMode = FindObjectOfType<DebugMode>().debugMode;
        objArray = debugMode ? debugObjectsArray : objectsArray;
    }

    void Update()
    {
        SetArray();

        while (spawn)
        {
            //var attackerIndex = Random.Range(0, objArray.Length);
            //Spawn(objArray[attackerIndex]);
            Spawn(objArray[indexToSpawn]);
            spawn = false;
            if (PlayerPrefsController.GetPredicitionsBool())
            {
                Prediction();
            }
            else if (!PlayerPrefsController.GetPredicitionsBool())
            {
                SetArray();
                indexToSpawn = Random.Range(0, objArray.Length);
            }
        }
    }

    private void Spawn (GameObject myObject)
    {
        FindObjectOfType<GameController>().BuildMap();
        GameObject newGameObject = Instantiate(myObject, transform.position, transform.rotation) as GameObject;
        newGameObject.transform.parent = transform;
    }

    private void Prediction()
    {
        SetArray();
        Destroy(transform.GetChild(0).gameObject.transform.GetChild(0).gameObject);
        var attackerIndex = Random.Range(0, objArray.Length);
        GameObject newGameObject = Instantiate(objArray[attackerIndex], transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.position, transform.rotation) as GameObject;
        newGameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        newGameObject.GetComponent<Object>().move = false;
        indexToSpawn = attackerIndex;
        newGameObject.transform.parent = transform.GetChild(0).gameObject.transform;
        for (int index = 0; index < 3; index++)
        {
            Destroy(newGameObject.transform.GetChild(index).gameObject.GetComponent<Collider2D>());
        }
    }

}
