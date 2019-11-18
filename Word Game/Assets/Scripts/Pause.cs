using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private Button resumeButton;

    [SerializeField]
    private GameObject panel;

    private TimerController timerControllerScript;

    private void Start()
    {
        //Gets hold of the timer script
        timerControllerScript = GameObject.Find("GameManager").GetComponent<TimerController>();
    }

    //Method to Pause/Resume the game
    public void PauseGame()
    {
        //Check if the game is already paused
        //If it is paused, unpause it
        if (timerControllerScript.isPaused)
        {
            panel.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(false);
            timerControllerScript.isPaused = false;
            Time.timeScale = 1f;
        }

        //If it is not paused, pause it
        else
        {
            resumeButton.gameObject.SetActive(true);
            panel.gameObject.SetActive(true);
            timerControllerScript.isPaused = true;
            Time.timeScale = 0f;
        }
    }
}
