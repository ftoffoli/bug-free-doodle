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

    private char[] word;
    private char[] stackedLetters;
    private string matchedLetters;


    string temp;

    // Start is called before the first frame update
    void Start()
    {
        wordsArray = this.GetComponent<LoadData>().LoadFile();

        spawnLetterScript = lettersObject.GetComponent<SpawnLetters>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!lettersStack.text.Equals(temp))
        {
            if (CheckForWord())
            {
                //Debug.Log("yes");
                
                removeLettersFromStack();
                
                spawnLetterScript.updateStack();
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
        //string matchedLetters

        foreach (string str in wordsArray) 
        {
            matchedLetters = "";
            stackedLetters = lettersStack.text.ToCharArray();  
            word = str.ToCharArray();

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

            if(matchedLetters.Equals(str))
            {
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
}
