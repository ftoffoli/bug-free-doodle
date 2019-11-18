﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    //Variables
    public float initialTime = 30f;
    public float currentTime;
    public bool isTimeOver = false;
    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        //Sets current time as the initial time
        currentTime = initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if there is available time
        if(currentTime < 1)
        {
            isTimeOver = true;
        }
        //If there is time available, keep decreasing it
        else if(!isTimeOver)
        {
            currentTime -= Time.deltaTime;
        }
    }
}
