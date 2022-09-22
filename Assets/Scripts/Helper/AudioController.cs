using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    public AudioClip explosionClip;
    public AudioClip winClip,loseClip;
    public AudioClip shieldHitClip;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    private void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void StopAllAudio()
    {
        audioSource.Stop();
        audioSource2.Stop();
        audioSource3.Stop();
    }

    public void PlayOneShot(AudioClip audioClip,float volume=.5f)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClip);
            audioSource.volume = volume;
        }
        else if(!audioSource2.isPlaying)
        {
            audioSource2.PlayOneShot(audioClip);
            audioSource2.volume = volume;
        }
        else
        {
            audioSource3.PlayOneShot(audioClip);
            audioSource3.volume = volume;
        }
        
    }
}
