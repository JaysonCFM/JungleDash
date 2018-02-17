using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
	//declare player and boolean for them being in the tutorial
    private Player player;
    public bool IsTutorial;

    private void Start()
    {
		//assign player
        player = FindObjectOfType<Player>();
    }

    //When the player falls off the bottom, they hit a trigger that will force their health to 0 and kill the player.
    private void OnTriggerEnter2D(Collider2D collision)
    {
		//if they're not in the tut, hitting a lose collider kills them
        if (!IsTutorial)
        {
            PlayerPrefsManager.SetHealth(0);
            player.transform.position = PlayerPrefsManager.PlayerLocation();
        }
		//in the tut, it simply respawns them at the jump tut start
        else
        {
            player.transform.position = new Vector3(-934.77f, -7.98f, 0);
        }
    }
}
