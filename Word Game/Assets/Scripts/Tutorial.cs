using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    private int boxPosition = 0;
    public GameObject[] boxes;

    public GameObject pia;
    public GameObject letters;
    public GameObject lettersStack;
    public GameObject timer;
    public GameObject pauseButton;
    public GameObject objectsList;
    public GameObject B;
    public GameObject previous;

    private void Start()
    {
        pia.SetActive(false);
        letters.SetActive(false);
        lettersStack.SetActive(false);
        timer.SetActive(false);
        pauseButton.SetActive(false);
        objectsList.SetActive(false);
        B.SetActive(false);

        for (int counter = 1; counter < boxes.Length; counter++)
        {
            boxes[counter].SetActive(false);
        }
    }

    public void OpenNext(int direction)
    {
        int prevBoxPos = boxPosition;
        
        //Check direction
        if(direction == 0)
        {
            boxPosition++;
        }
        else
        {
            boxPosition--;
        }

        //Display or hide Previous button
        if(boxPosition == 0)
        {
            previous.SetActive(false);
        }
        else
        {
            previous.SetActive(true);
        }
        

        if(boxPosition == 0)
        {
            pia.SetActive(false);
            boxes[prevBoxPos].SetActive(false);

            boxes[boxPosition].SetActive(true);
        }
        else if(boxPosition == 1)
        {
            pia.SetActive(true);
            timer.SetActive(false);
            boxes[prevBoxPos].SetActive(false);
            
            boxes[boxPosition].SetActive(true);
        }
        else if(boxPosition == 2)
        {
            pia.SetActive(false);
            objectsList.SetActive(false);
            boxes[prevBoxPos].SetActive(false);

            boxes[boxPosition].SetActive(true);
            timer.SetActive(true);
        }
        else if (boxPosition == 3)
        {
            boxes[prevBoxPos].SetActive(false);
            letters.SetActive(false);

            boxes[boxPosition].SetActive(true);
            objectsList.SetActive(true);
        }
        else if (boxPosition == 4)
        {
            boxes[prevBoxPos].SetActive(false);
            lettersStack.SetActive(false);

            boxes[boxPosition].SetActive(true);
            letters.SetActive(true);
        }
        else if (boxPosition == 5)
        {
            letters.SetActive(false);
            boxes[prevBoxPos].SetActive(false);
            B.SetActive(false);
            pia.SetActive(false);

            boxes[boxPosition].SetActive(true);
            lettersStack.SetActive(true);
        }
        else if(boxPosition == 6)
        {
            lettersStack.SetActive(false);
            boxes[prevBoxPos].SetActive(false);
            pauseButton.SetActive(false);

            boxes[boxPosition].SetActive(true);
            B.SetActive(true);
            pia.SetActive(true);
        }
        else if (boxPosition == 7)
        {
            boxes[prevBoxPos].SetActive(false);

            boxes[boxPosition].SetActive(true);
            pauseButton.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
