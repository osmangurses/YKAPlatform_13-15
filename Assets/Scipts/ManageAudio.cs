using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageAudio : MonoBehaviour
{
    public static ManageAudio instance;
    public AudioSource[] audios;


    private void Start()
    {
        instance = this;
        Debug.Log(PlayerPrefs.GetInt("Sound"));
        if (PlayerPrefs.GetInt("Sound")==1)
        {
            for (int i = 0; i < audios.Length; i++)
            {
                audios[i].volume = 1;
            }

        }
        else
        {
            for (int i = 0; i < audios.Length; i++)
            {
                audios[i].volume = 0;
            }
        }
    }
    public void PlayCollectSound()
    {
        audios[0].Play();
    }
    public void PlayFailSound()
    {
        audios[2].Play();
    }
    public void PlayJumpSound()
    {
        if (audios[5].isPlaying)
        {
            StopRunSound();
        }
        audios[3].Play();
    }
    public void PlayLvCompleteSound()
    {
        audios[4].Play();
    }
    public void PlayRunSound()
    {
        audios[5].Play();
    }
    public void StopRunSound()
    {
        audios[5].Play();
    }
}
