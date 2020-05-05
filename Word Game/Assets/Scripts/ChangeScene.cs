using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private PlayerPreferences playerPreferencesScript;

    private void Start()
    {
        playerPreferencesScript = this.GetComponent<PlayerPreferences>();
    }

    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
