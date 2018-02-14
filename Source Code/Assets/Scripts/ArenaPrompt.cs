using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaPrompt : MonoBehaviour {
    //is the actually display of text
    public string textString;
    //will access it onthe game canvas
    public Text text;
    //Will only display the text when the Player in on the Platform
    private bool IsOnPlatform;
	//barrier object to force player to fight griffin
	public GameObject barrier;

    //if the player is on the platform then OnPlatform will be acessed which will draw the string 
    void Update () {
        if (IsOnPlatform)
        {
            OnPlatForm();
        }

		//check if griffin is dead, at which point the barrier will be disabled allowing the player to pass through
		if (ExitArena.GriffinIsDead == true) {
			barrier.SetActive (false);
		}
    }
	//isOnPlatform will be true when player enters and remains on platform
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
		//only display arena enterance prompt if griffin is alive, otherwise display post-fight remark
		if (ExitArena.GriffinIsDead == false) {
			text.text = textString;
		} else if(ExitArena.GriffinIsDead == true) {text.text = "Whew, what a battle that was!";
		}
    }
}
