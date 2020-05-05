using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningsController : MonoBehaviour
{
    public GameObject confirmPrompt;

    // Start is called before the first frame update
    void Start()
    {
        confirmPrompt.SetActive(false);
    }

    public void CancelExit()
    {
        confirmPrompt.SetActive(false);
    }

    public void DisplayConfirmPrompt()
    {
        confirmPrompt.SetActive(true);
    }
}
