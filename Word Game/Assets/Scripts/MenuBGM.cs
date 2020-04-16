using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBGM : MonoBehaviour
{
    private string sceneName;
    public bool isPlayTime = true;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "MainMenu" || sceneName == "Level Selection" || sceneName == "Tutorial")
        {
            if(isPlayTime)
            {
                this.GetComponent<AudioSource>().Play();
                isPlayTime = false;
            }
        }
        else
        {
            this.GetComponent<AudioSource>().Stop();
            isPlayTime = true;
        }
    }
}
