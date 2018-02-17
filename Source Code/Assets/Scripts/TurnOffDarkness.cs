using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffDarkness : MonoBehaviour {

	//declare darkness gameobject
    public GameObject Darkness;
	//boolean for the transition out of darkness
    private bool TransitionToLight;

    //Fade effect
    private void Update()
    {
		//when transition to light is true, the darkness goes away
        if (TransitionToLight)
        {
            Darkness.GetComponent<SpriteRenderer>().color -= new Color(0f, 0f, 0f, 0.03f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
		//start boolean transition out of darnkess upon collision with the darkness object
        TransitionToLight = true;
    }
}
