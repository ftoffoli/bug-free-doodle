using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    //Variables
    public float initialTime = 30f;
    public float currentTime;
    public float totalTime;
    public bool isTimeOver = false;
    public bool isPaused = false;

    private PlayerPreferences playerPrefsScript;
    private ObjectsController objectsControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        //Sets current time as the initial time
        currentTime = initialTime;
        totalTime = initialTime;

        playerPrefsScript = this.GetComponent<PlayerPreferences>();
        objectsControllerScript = this.GetComponent<ObjectsController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if there is available time
        if(currentTime < 1)
        {
            isTimeOver = true;
            playerPrefsScript.SaveScore(totalTime - 1);
        }
        //If there is time available, keep decreasing it
        else if(!isTimeOver && objectsControllerScript.memorized)
        {
            currentTime -= Time.deltaTime;
        }
    }

    public void addTime(float timeToAdd)
    {
        currentTime += timeToAdd;
        totalTime += timeToAdd;
    }
}
