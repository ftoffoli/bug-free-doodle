using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private Text previousScore;
    [SerializeField]
    private Text bestScore;

    private PlayerPreferences playerPreferencesScript;


    // Start is called before the first frame update
    void Start()
    {
        playerPreferencesScript = this.GetComponent<PlayerPreferences>();

        //Load values from the PlayerPrefs to the text holders
        previousScore.text = FormatText(playerPreferencesScript.GetPreviousScore());
        bestScore.text = FormatText(playerPreferencesScript.GetBestScore());
    }

    private string FormatText(float value)
    {
        //Formats the time to display as 00:00
        float minutes = Mathf.FloorToInt(value / 60);
        float seconds = Mathf.FloorToInt(value % 60);

        //Displays the time
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
