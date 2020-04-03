using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsController : MonoBehaviour
{
    public GameObject[] objectsArray;
    public float waitTime;
    public bool memorized = false;

    public Button pauseButton;
    public GameObject panel;
     
    // Start is called before the first frame update
    void Start()
    {
        pauseButton.interactable = false;
        panel.SetActive(true);
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

    IEnumerator memorizeTime()
    {
        panel.SetActive(false);

        yield return new WaitForSeconds(waitTime);
        
        gameSetUp();
        memorized = true;
        pauseButton.interactable = true;
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

    public void howToPlay()
    {
        StartCoroutine(memorizeTime());
    }
}
