using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGriffinSound : MonoBehaviour {

    //Audio Source for playoung sound effects
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //Trigger by animator to play the audio clip
    void PlaySound()
    {
        audioSource.Play();
    }
}
