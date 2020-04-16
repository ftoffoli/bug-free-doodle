using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text quartoScore;
    public Text banheiroScore;
    public Text cozinhaScore;
    public Text salaScore;

    private PlayerPreferences playerPreferencesScript;


    // Start is called before the first frame update
    void Start()
    {
        playerPreferencesScript = this.GetComponent<PlayerPreferences>();

        //Load values from the PlayerPrefs to the text holders
        quartoScore.text = FormatText(playerPreferencesScript.GetScore("Quarto"));
        banheiroScore.text = FormatText(playerPreferencesScript.GetScore("Banheiro"));
        cozinhaScore.text = FormatText(playerPreferencesScript.GetScore("Cozinha"));
        salaScore.text = FormatText(playerPreferencesScript.GetScore("Sala"));
    }

    public string FormatText(float value)
    {
        //Formats the time to display as 00:00
        float minutes = Mathf.FloorToInt(value / 60);
        float seconds = Mathf.FloorToInt(value % 60);

        //Displays the time
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
