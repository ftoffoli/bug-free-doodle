using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsPanel : MonoBehaviour
{
    public GameObject panel;
    private bool isOn = false;

    public void OpenClosePanel()
    {
        if(isOn)
        {
            panel.SetActive(false);
            isOn = false;
        }
        else
        {
            panel.SetActive(true);
            isOn = true;
        }
    }
}
