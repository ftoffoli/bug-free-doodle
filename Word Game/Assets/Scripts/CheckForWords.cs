using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CheckForWords : MonoBehaviour
{
    public Toggle toggle;
    public InputField input;

    [SerializeField]
    private string[] wordsArray;

    private char[] word;
    private char[] stackedLetters;
    

    string temp;

    // Start is called before the first frame update
    void Start()
    {
        wordsArray = this.GetComponent<LoadData>().LoadFile();
    }

    // Update is called once per frame
    void Update()
    {
        if (!input.text.Equals(temp))
        {
            if (CheckForWord())
            {
                toggle.isOn = true;
            }
            else
            {
                toggle.isOn = false;
            }
        }

        temp = input.text;
    }

    private bool CheckForWord()
    {
        string matchedLetters = "";
        stackedLetters = input.text.ToCharArray();

        foreach (string str in wordsArray) 
        {
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

            /*char[] sortedLetters = matchedLetters.ToCharArray();
            Array.Sort<char>(word);
            Array.Sort<char>(sortedLetters);*/

            //if (input.text.Contains(str))
            if(matchedLetters.Equals(str))
            {
                return true;
            }
        }

        return false;
    }
}
