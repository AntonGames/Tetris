using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] objectsArray;
    public bool spawn = true;

    // Start is called before the first frame update
    void Update()
    {
        while (spawn)
        {
            var attackerIndex = Random.Range(0, objectsArray.Length);
            Spawn(objectsArray[attackerIndex]);
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
