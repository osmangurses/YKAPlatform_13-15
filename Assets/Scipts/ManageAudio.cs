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
