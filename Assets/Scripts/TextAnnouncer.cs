using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnnouncer : MonoBehaviour {
    //is the actually display of text
    public string textString;
    //will access it onthe game canvas
    public Text text;
    //Will only display the text when the Player in on the Platoform
    private bool IsOnPlatform;



    
    //if the player is on the platform then OnPlatform will be acessed which will draw the string 
    void Update () {
        if (IsOnPlatform)
        {
            OnPlatForm();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        IsOnPlatform = true;


    }
    private void TriggerStay2D(Collider2D collision)
    {
        IsOnPlatform = true;
    }
    // IsOnPlatform will only be used when the player is on the platform which will then allow it to draw
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsOnPlatform = false;
        text.text = "";
    }
    //will display the text to the canvas screen
    private void OnPlatForm()
    {
        text.text = textString;
        
    }
}
