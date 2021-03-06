﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static AudioClip jumpSound;
    public static AudioClip coinSound;
    public static AudioClip ouchSound;
    public static AudioClip stompSound;
    public static AudioClip laserSound;
    public static AudioClip doorOpenSound;
    public static float jumpVolume = .1f;
    public static float laserVolume = .5f;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jumpSound2");
        coinSound = Resources.Load<AudioClip>("Find_Money");
        ouchSound = Resources.Load<AudioClip>("Hero_Hurt");
        stompSound = Resources.Load<AudioClip>("Enemy_Damage");
        laserSound = Resources.Load<AudioClip>("laserBeam");
        doorOpenSound = Resources.Load<AudioClip>("doorOpen");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(jumpSound, jumpVolume);
                break;
            case "coin":
                audioSrc.PlayOneShot(coinSound);
                break;
            case "ouch":
                audioSrc.PlayOneShot(ouchSound);
                break;
            case "stomp":
                audioSrc.PlayOneShot(stompSound);
                break;
            case "laser":
                audioSrc.PlayOneShot(laserSound,laserVolume);
                break;
            case "doorOpen":
                audioSrc.PlayOneShot(doorOpenSound);
                break;
        }
    }
}
