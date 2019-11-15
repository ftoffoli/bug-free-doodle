using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    private TimerController timerControllerScript;
    private Text message;

    // Start is called before the first frame update
    void Start()
    {
        timerControllerScript = GameObject.Find("GameController").GetComponent<TimerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerControllerScript.isTimeOver)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
