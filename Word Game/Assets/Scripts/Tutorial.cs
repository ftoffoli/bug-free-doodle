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

    private void Start()
    {
        pia.SetActive(false);
        letters.SetActive(false);
        lettersStack.SetActive(false);
        timer.SetActive(false);
        pauseButton.SetActive(false);
        objectsList.SetActive(false);

        for(int counter = 1; counter < boxes.Length; counter++)
        {
            boxes[counter].SetActive(false);
        }
    }

    public void OpenNext()
    {
        int prevBoxPos = boxPosition;
        boxPosition++;

        if(boxPosition == 1)
        {
            pia.SetActive(true);
            boxes[prevBoxPos].SetActive(false);
            
            boxes[boxPosition].SetActive(true);
        }
        else if(boxPosition == 2)
        {
            pia.SetActive(false);
            boxes[prevBoxPos].SetActive(false);

            boxes[boxPosition].SetActive(true);
            timer.SetActive(true);
        }
        else if (boxPosition == 3)
        {
            boxes[prevBoxPos].SetActive(false);

            boxes[boxPosition].SetActive(true);
            objectsList.SetActive(true);
        }
        else if (boxPosition == 4)
        {
            boxes[prevBoxPos].SetActive(false);

            boxes[boxPosition].SetActive(true);
            letters.SetActive(true);
        }
        else if (boxPosition == 5)
        {
            letters.SetActive(false);
            boxes[prevBoxPos].SetActive(false);

            boxes[boxPosition].SetActive(true);
            lettersStack.SetActive(true);
        }
        else if (boxPosition == 6)
        {
            boxes[prevBoxPos].SetActive(false);

            boxes[boxPosition].SetActive(true);
            pauseButton.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("MainMenu Scene");
        }
    }
}
