using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    private bool isFirstTime;
    private AudioSource audioSource;

    public AudioSource BGMSource;
    public AudioMixer masterMixer;
    public Button muteButton;
    public Sprite[] muteSprites; 

    public AudioClip letterCollected;
    public AudioClip wordCompleted;
    public AudioClip winningSong;
    public AudioClip losingSong;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        isFirstTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCollectedLetter()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(letterCollected);
    }

    public void PlayWordCompleted()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(wordCompleted);
    }

    public void PlayWinning()
    {
        if(isFirstTime)
        {
            BGMSource.Stop();
            audioSource.clip = winningSong;
            audioSource.Play();

            //audioSource.PlayOneShot(winningSong);
            isFirstTime = false;
        }
    }

    public void PlayLosing()
    {
        if(isFirstTime)
        {
            BGMSource.Stop();
            audioSource.PlayOneShot(losingSong);
            isFirstTime = false;
        }
    }

    public void MuteSound()
    {
        float tempVolume;
        masterMixer.GetFloat("masterVol", out tempVolume);

        if (tempVolume == -80f)
        {
            masterMixer.SetFloat("masterVol", 0f);
            muteButton.image.sprite = muteSprites[1];
        }
        else
        {
            masterMixer.SetFloat("masterVol", -80f);
            muteButton.image.sprite = muteSprites[0];
        }
    }
}
