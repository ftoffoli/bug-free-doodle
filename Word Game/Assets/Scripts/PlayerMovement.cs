using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    //Variable to control the speed of the player
    [SerializeField]
    private float speed = 1f;

    private TimerController timerControllerScript;

    private void Start()
    {
        //Gets hold of the timer script
        timerControllerScript = GameObject.Find("GameManager").GetComponent<TimerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the mouse was clicked
        if(Input.GetMouseButton(0) && !timerControllerScript.isTimeOver && !timerControllerScript.isPaused 
            && !EventSystem.current.IsPointerOverGameObject())
        {
            //Checks if the mouse is within the camera view
            if(Camera.main.pixelRect.Contains(Input.mousePosition))
            {
                //Creates a vector to store the mouse position relative to the camera view
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //Keep Z axis centered
                mousePos.z = 64f;

                //Moves the player towards the mouse
                this.transform.position = Vector2.MoveTowards(this.transform.position,
                                                                mousePos, speed);
            }
        }
    }
}
