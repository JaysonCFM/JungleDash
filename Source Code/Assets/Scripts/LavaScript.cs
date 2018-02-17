using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour {
    //The timer for lava falling
    private float secondsCount;
    //Determines if the lava should be on or not
    private bool IsActive = true;
	//declare bos collider for lava
    private BoxCollider2D bc;
	//declare sprite renderer for lava
    private SpriteRenderer sr;
    //Maximum amount of time the lava should be on.
    public float TimeToDisable;

    // Use this for initialization
    void Start () {
		//assign collider and sprite displayer
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        //gets the irl time because unity allows it to have diversify framerate so it runs on different frame rate for different computers
        secondsCount += Time.deltaTime;
        //when it hits set seconds it goes to the Startanimation 
        if (secondsCount >= TimeToDisable)
        {
            StartAnimation();
        }

    }
    
    public void StartAnimation()
    {
        //when it is true it will allow the sprirt to be seen and have a box colliiders
		//but when it is false you will not be able to see it and be able to jump through it
        if (IsActive)
        {
            bc.enabled = false;
            sr.enabled = false;
            IsActive = false;
            secondsCount = 0;

        }
        else
        {
            bc.enabled = true;
            sr.enabled = true;
            IsActive = true;
            secondsCount = 0;
        }

    }
}
