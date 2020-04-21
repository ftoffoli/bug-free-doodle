using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckLevel : MonoBehaviour
{
    public GameObject[] levels;
    private GameObject playButton;
    private int nextLevel = 0;

    private PlayerPreferences playerPreferencesScript;

    // Start is called before the first frame update
    void Start()
    {
        playerPreferencesScript = this.GetComponent<PlayerPreferences>();

        for(int counter = 0; counter < levels.Length; counter++)
        {
            nextLevel++;
            
            if(nextLevel == levels.Length)
            {
                break;
            }

            playButton = levels[nextLevel].transform.Find("Play Button").gameObject;

            if (playerPreferencesScript.CheckIfExists(levels[counter].name))
            {
                playButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                playButton.GetComponent<Button>().interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
