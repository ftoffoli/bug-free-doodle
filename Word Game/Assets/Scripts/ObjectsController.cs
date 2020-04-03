using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsController : MonoBehaviour
{
    public GameObject[] objectsArray;

    // Start is called before the first frame update
    void Start()
    {
        gameSetUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void gameSetUp()
    {
        foreach(GameObject obj in objectsArray)
        {
            obj.SetActive(false);
        }
    }

    public void displayObject(string objName)
    {
        foreach (GameObject obj in objectsArray)
        {
            if(obj.name.Equals(objName.Trim()))
            {
               obj.SetActive(true);
            }
        }
    }
}
