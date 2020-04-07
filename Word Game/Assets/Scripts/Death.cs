using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    private TimerController timerControllerScript;

    //Variable to hold the message
    [SerializeField]
    private Text message;

    [SerializeField]
    private GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        //Gets hold of the timer script
        timerControllerScript = GameObject.Find("GameManager").GetComponent<TimerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the time is over
        if(timerControllerScript.isTimeOver)
        {
            //Display the Death panel
            panel.gameObject.SetActive(true);
            //Changes to Death message
            message.text = "O tempo acabou!";
            //Pause the time
            Time.timeScale = 0f;
        }
    }
}
