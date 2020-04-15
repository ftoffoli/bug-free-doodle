using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    //Variables
    public float initialTime = 30f;
    public float currentTime;
    public float totalTime;
    public float memorizeTime = 10f;
    public bool isTimeOver = false;
    public bool isPaused = false;

    public Text objectsList;

    private PlayerPreferences playerPrefsScript;
    private ObjectsController objectsControllerScript;
    private AudioController audioControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        //Sets current time as the initial time
        currentTime = memorizeTime;
        totalTime = 0;

        playerPrefsScript = this.GetComponent<PlayerPreferences>();
        objectsControllerScript = this.GetComponent<ObjectsController>();
        audioControllerScript = this.GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if there is available time
        if(currentTime < 1 && objectsControllerScript.memorized)
        {
            isTimeOver = true;
            audioControllerScript.PlayLosing();
        }
        //If there is time available, keep decreasing it
        else if(!isTimeOver && objectsControllerScript.memorized)
        {
            currentTime -= Time.deltaTime;
            totalTime += Time.deltaTime;
        }
        else if(!objectsControllerScript.memorized)
        {
            currentTime -= Time.deltaTime;
        }

        if (objectsList.text.Trim().Length == 0)
        {
            playerPrefsScript.SaveScore(totalTime);
        }
    }

    public void addTime(float timeToAdd)
    {
        currentTime += timeToAdd;
    }
}
