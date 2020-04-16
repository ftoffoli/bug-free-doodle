using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreferences : MonoBehaviour
{
    //Method to check if Key already exists in PlayerPrefs
    public bool CheckIfExists(string value)
    {
        /*if(PlayerPrefs.HasKey(value))
        {
            return true;
        }
        else
        {
            return false;
        }*/

        return PlayerPrefs.HasKey(value) ? true : false;
    }

    //Method to load the Best Score
    public float GetScore(string level)
    {
        float score = 0f;

        if(CheckIfExists(level))
        {
            score = PlayerPrefs.GetFloat(level);
        }
        
        else
        {
            score = 0;
        }

        return score;
    }

    public void SaveScore(float value, string level)
    {
        PlayerPrefs.SetFloat(level, value);
    }
}
