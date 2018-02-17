using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionalSound : MonoBehaviour {

	//declare audiosource
	private AudioSource SoundSource;

    //Talks to a referenced gameobject
    public GameObject Enemy;

    //Bool if player is in the arena to only play the sound.
    private bool IsPlayerInArea;

	// Use this for initialization
	void Start () {
		//assign audio source
		SoundSource = GetComponent<AudioSource>();
	}

    //If the player is in the area and the referenced enemy exists, then play the sound on loop.
    private void Update()
    {
        if (IsPlayerInArea)
        {
            if (SoundSource.isPlaying == false && Enemy)
            {
                SoundSource.Play();
            }
        }

        //Stops sound effect if the enemy dies or if the player leaves the area
        if (!IsPlayerInArea && SoundSource.isPlaying || !Enemy)
        {
            SoundSource.Stop();
        }
    }

    //Statements below that also determine when to play the sound effect
    private void OnTriggerEnter2D(Collider2D collision)
    {
            IsPlayerInArea = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
           IsPlayerInArea = true;
    }

    //Stops playing the sound effect when the player leaves the area.
    private void OnTriggerExit2D(Collider2D collision)
    {
           IsPlayerInArea = false;

    }
}
