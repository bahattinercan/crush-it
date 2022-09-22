using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public Vector3 speed;
    public float xSpeed = 8f, zSpeed = 15f, baseZSpeed = 15f;
    public float accelerated = 15f, deccelerated = 10f;
    protected float rotationSpeed = 15f;
    protected float maxAngle = 10f;
    public float lowSoundPitch, normalSoundPitch, highSoundPitch;
    public AudioClip engineOnSound, engineOffSound;
    private bool isSlow;
    private AudioSource soundManager;

    private void Awake()
    {
        soundManager = GetComponent<AudioSource>();
        speed = new Vector3(0f, 0f, zSpeed);
        /*
        soundManager.Stop();
        soundManager.clip = engineOnSound;
        soundManager.volume = .3f;
        soundManager.Play();
        */
    }

    protected virtual void Update()
    { 
        if (Time.timeScale == 0)
        {
            soundManager.Stop();
        }
    }

    public void MoveLeft()
    {
        speed = new Vector3(-xSpeed/2f, 0f, speed.z);
    }

    public void MoveRight()
    {
        speed = new Vector3(xSpeed / 2f, 0f, speed.z);
    }

    public void MoveStraight()
    {
        speed = new Vector3(0f, 0f, speed.z);
    }

    protected void MoveNormal()
    {
        if (isSlow)
        {
            isSlow = false;
        }
        /*
            soundManager.Stop();
            soundManager.clip = engineOnSound;
            soundManager.volume = .3f;
            soundManager.Play()
        }else if (!isSlow)
        {
            soundManager.volume = .3f;
        }
        */
        
        speed = new Vector3(speed.x, 0f, zSpeed);
    }

    protected void MoveSlow()
    {
        if (!isSlow)
        {
            isSlow = true;
            /*
            soundManager.Stop();
            soundManager.clip = engineOffSound;
            soundManager.volume = .4f;
            soundManager.Play();
            */
        }
        speed = new Vector3(speed.x, 0f, deccelerated);
    }

    protected void MoveFast()
    {
        /*
        if (!isSlow)
        {
            soundManager.volume = .25f;
        }
        */
        speed = new Vector3(speed.x, 0f, accelerated);
    }

}
