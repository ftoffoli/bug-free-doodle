using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject leaderboardController;
    public GameObject confirmedPanel;
    public GameObject allPanels;
    public GameObject confirmPrompt;
    public GameObject tutorialPromptPanel;

    public InputField nameField;
    public InputField emailField;

    public Button verifyInfoButton;

    public Text playerInfo;
    public Text finalMessage;

    private PlayerPreferences playerPreferencesScript;
    private LeaderboardController leaderboardControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        playerPreferencesScript = gameManager.GetComponent<PlayerPreferences>();
        leaderboardControllerScript = leaderboardController.GetComponent<LeaderboardController>();

        if(!playerPreferencesScript.CheckIfExists("playerEmail"))
        {
            allPanels.SetActive(true);
            confirmPrompt.SetActive(false);
            confirmedPanel.SetActive(false);
            verifyInfoButton.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if name field is empty
        if(nameField.text.Length > 2)
        {
            //Checks if email entry has basic info
            if (emailField.text.Contains("@") && emailField.text.Length > 5)
            {
                verifyInfoButton.interactable = true;
            }
            //Disables button if entries are not valid
            else
            {
                verifyInfoButton.interactable = false;
            }
        }
        //Disables button if entries are not valid
        else
        {
            verifyInfoButton.interactable = false;
        }

        if(leaderboardControllerScript.hasSaved)
        {
            finalMessage.text = leaderboardControllerScript.finalMessage;
            confirmedPanel.SetActive(true);
        }
    }

    public void CallConfirmPrompt()
    {
        playerInfo.text = "Name:" + "\n" + "\t" + nameField.text + "\n" + "Email:"+ "\n" + "\t" +emailField.text;
        confirmPrompt.SetActive(true);
    }

    public void CloseConfirmPrompt()
    {
        confirmPrompt.SetActive(false);
    }

    public void SavePlayerToDB()
    {
        playerPreferencesScript.SavePlayerInfo(nameField.text, emailField.text);

        leaderboardControllerScript.startAddPlayer(nameField.text, emailField.text);
    }

    public void ClosePanels()
    {
        if(finalMessage.text.Equals(("Email ja cadastrado. Utilize outro email").Trim()))
        {
            leaderboardControllerScript.hasSaved = false;
            confirmPrompt.SetActive(false);
            confirmedPanel.SetActive(false);
        }
        else
        {
            allPanels.SetActive(false);
        }

        DisplayTutorialPrompt();
    }

    public void DisplayTutorialPrompt()
    {
        tutorialPromptPanel.SetActive(true);
    }
    public void CloseTutorialPrompt()
    {
        tutorialPromptPanel.SetActive(false);
    }
}
