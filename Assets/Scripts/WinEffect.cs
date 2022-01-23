using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEffect : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip winClip;
    bool FunctionCalled = false;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (FunctionCalled==false && Score.scoreValue==5)
        {
            FunctionCalled = true;
            audioSource.PlayOneShot(winClip);
        }
    }
}
