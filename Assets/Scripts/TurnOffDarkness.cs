using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffDarkness : MonoBehaviour {

    public GameObject Darkness;

    private bool TransitionToLight;

    //Fade effect
    private void Update()
    {
        if (TransitionToLight)
        {
            Darkness.GetComponent<SpriteRenderer>().color -= new Color(0f, 0f, 0f, 0.03f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TransitionToLight = true;
    }
}
