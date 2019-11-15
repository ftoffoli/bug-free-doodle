using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variable to control the speed of the player
    [SerializeField]
    private float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        //Checks if the mouse was clicked
        if(Input.GetMouseButton(0))
        {
            //Checks if the mouse is within the camera view
            if(Camera.main.pixelRect.Contains(Input.mousePosition))
            {
                //Creates a vector to store the mouse position relative to the camera view
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //Keep Z axis centered
                mousePos.z = 0f;

                //Moves the player towards the mouse
                this.transform.position = Vector2.MoveTowards(this.transform.position,
                                                                mousePos, speed);
            }
        }
    }
}
