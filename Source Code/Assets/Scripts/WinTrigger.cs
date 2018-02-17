using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour {

	//declare level manager
    private LevelManager levelManager;
	//declare integer for next level index
    public int LevelToUnlock;

	// Use this for initialization
	void Start () {
        //Finding a LevelManager on the scene.
        levelManager = FindObjectOfType<LevelManager>();
	}

    //Checking for a trigger.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Takes what collided with the trigger, and creates a gameobject
        GameObject player = collision.gameObject;

        //Checks to make sure only a player can win.
        if (player.GetComponent<Player>())
        {
            //If the player DID collide, then it unlocks the next level and takes them to the map.
            UnlockLevel(LevelToUnlock);
            PlayerPrefsManager.SetLocation(0, 0, 0);
            PlayerPrefsManager.SetCheckpoint("false");
            levelManager.LoadLevel("Map");
        }
    }

    public void UnlockLevel(int NumToUnlock)
    {
        PlayerPrefsManager.UnlockLevel(NumToUnlock);
    }
}
