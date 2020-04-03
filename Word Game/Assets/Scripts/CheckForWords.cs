using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CheckForWords : MonoBehaviour
{
    //public Toggle toggle;
    //public InputField input;

    [SerializeField]
    private string[] wordsArray;

    public Text lettersStack;
    public GameObject lettersObject;
    private SpawnLetters spawnLetterScript;
    private TimerController timerControllerScript;
    private ObjectsController objectsControllerScript;

    private char[] word;
    private char[] stackedLetters;
    private string matchedLetters;
    private int wordLength;


    string temp;

    // Start is called before the first frame update
    void Start()
    {
        wordsArray = this.GetComponent<LoadData>().LoadFile();
        timerControllerScript = this.GetComponent<TimerController>();
        objectsControllerScript = this.GetComponent<ObjectsController>();
    
        spawnLetterScript = lettersObject.GetComponent<SpawnLetters>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!lettersStack.text.Equals(temp))
        {
            if (CheckForWord())
            {
                removeLettersFromStack();
                
                spawnLetterScript.updateStack();

                timerControllerScript.addTime(calculateTime());
            }
            else
            {
                //toggle.isOn = false;
            }
        }

        temp = lettersStack.text;
    }

    private bool CheckForWord()
    {
        foreach (string str in wordsArray) 
        {
            matchedLetters = "";
            stackedLetters = lettersStack.text.ToCharArray();  
            word = str.ToCharArray();

            Debug.Log(str);

            if(!str.Equals("+"))
            {
                for (int counter = 0; counter < word.Length; counter++)
                {
                    for (int inCounter = 0; inCounter < stackedLetters.Length; inCounter++)
                    {
                        if (word[counter].Equals(stackedLetters[inCounter]) && !stackedLetters.Equals(' '))
                        {
                            matchedLetters += stackedLetters[inCounter];
                            stackedLetters[inCounter] = ' ';
                            break;
                        }
                    }
                }
            }

            if(matchedLetters.Equals(str.Trim()))
            {
                wordLength = matchedLetters.Length;
                objectsControllerScript.displayObject(matchedLetters);
                wordsArray[Array.IndexOf(wordsArray, str)] = "+";
                return true;
            }
        }

        return false;
    }

    private void removeLettersFromStack()
    {
        //Convert char[] to string
        string removedLetters = new string(stackedLetters);

        //Remove spaces from string
        removedLetters = removedLetters.Replace(" ", "");

        //Replace stack with removed letters
        lettersStack.text = removedLetters;
    }


    private float calculateTime()
    {
        float timeToReturn = 0;

        if(spawnLetterScript.rateSpawn > .2)
        {
            spawnLetterScript.rateSpawn *= .7f;
        }

        return timeToReturn = wordLength * 2;
    }
}
