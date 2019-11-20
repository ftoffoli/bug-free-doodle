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
    public float GetBestScore()
    {
        float score = 0f;

        if(CheckIfExists("bestScore"))
        {
            score = PlayerPrefs.GetFloat("bestScore");
        }
        
        else
        {
            score = 0;
        }

        return score;
    }

    //Method to load the Previous Score
    public float GetPreviousScore()
    {
        float score = 0f;

        if (CheckIfExists("previousScore"))
        {
            score = PlayerPrefs.GetFloat("previousScore");
        }

        else
        {
            score = 0;
        }

        return score;
    }

    public void SaveScore(float value)
    {
        //Checks if there are any values previously saved (if the player has played before)
        if(CheckIfExists("previousScore"))
        {
            //Variable to hold the best score for comparison
            float bestScore = GetBestScore();

            //Checks if the current value to be saved is bigger than the previous Best Score
            if(value > bestScore)
            {
                PlayerPrefs.SetFloat("bestScore", value);
                PlayerPrefs.SetFloat("previousScore", value);
            }
            else
            {
                PlayerPrefs.SetFloat("previousScore", value);
            }
        }

        else
        {
            PlayerPrefs.SetFloat("bestScore", value);
            PlayerPrefs.SetFloat("previousScore", value);
        }
    }
}
