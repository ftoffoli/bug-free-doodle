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
        float previousScore = PlayerPrefs.GetFloat(level);

        if(!CheckIfExists(level))
        {
            PlayerPrefs.SetFloat(level, value);
        }

        else if(previousScore > value)
        {
            PlayerPrefs.SetFloat(level, value);
        }
    }

    public void SavePlayerInfo(string name, string email)
    {
        PlayerPrefs.SetString("playerName", name);
        PlayerPrefs.SetString("playerEmail", email);
    }
    public string getPlayerName()
    {
        return PlayerPrefs.GetString("playerName");
    }
    public string getPlayerEmail()
    {
        return PlayerPrefs.GetString("playerEmail");
    }
}
