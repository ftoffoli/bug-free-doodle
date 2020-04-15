using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsController : MonoBehaviour
{
    public GameObject[] objectsArray;
    private float waitTime;
    public bool memorized = false;

    public Button pauseButton;
    public Button skipButton;

    private TimerController timerControllerScript;
     
    // Start is called before the first frame update
    void Start()
    {
        timerControllerScript = this.GetComponent<TimerController>();
        waitTime = timerControllerScript.memorizeTime;
        pauseButton.interactable = false;

        StartCoroutine(memorizeTime());
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
        yield return new WaitForSeconds(waitTime);

        SkipMemorizeTime();
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

    public void SkipMemorizeTime()
    {
        gameSetUp();
        memorized = true;
        pauseButton.interactable = true;
        timerControllerScript.currentTime = timerControllerScript.initialTime;
        skipButton.gameObject.SetActive(false);
    }
}
