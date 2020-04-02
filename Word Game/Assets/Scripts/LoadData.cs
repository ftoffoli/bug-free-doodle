using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{
    [SerializeField]
    private TextAsset wordsCSV;

    private string[] wordsArray;

    // Start is called before the first frame update
    void Start()
    {
        //Load words from file
        //loadFile();
    }

    //Method to load words from file
    public string[] LoadFile()
    {
        //Creates separator, to split the words from the CSV file
        //char separator = ',';
        char separator = '\n';

        //Splits the CSV file in an array
        wordsArray = wordsCSV.text.Split(separator);

        return wordsArray;
    }
}
