using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //Variables
    private TimerController timerControllerScript;

    private float currentTime;
    private int minutes;
    private int seconds;

    private ObjectsController objectsControllerScript;

    [SerializeField]
    private Text timer;

    // Start is called before the first frame update
    void Start()
    {
        //Gets hold of the necessary components
        timerControllerScript = this.GetComponent<TimerController>();
        //timer.text = timerControllerScript.initialTime.ToString();
        objectsControllerScript = this.GetComponent<ObjectsController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the updated current time
        currentTime = timerControllerScript.currentTime;
        if(objectsControllerScript.memorized)
        {
            DisplayTime();
        }
    }

    //Method to display the decreasing time
    private void DisplayTime()
    {
        if(currentTime >= 0)
        {
            //Formats the time to display as 00:00
            minutes = Mathf.FloorToInt(currentTime / 60);
            seconds = Mathf.FloorToInt(currentTime % 60);

            //Displays the time
            timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
        
    }
}
