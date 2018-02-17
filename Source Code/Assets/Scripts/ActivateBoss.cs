using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBoss : MonoBehaviour {

	//declare boss object
    public GameObject boss;
	//declare boolean for player passing fight sequence activation 
    private bool HasPlayerPassed;
	//declare player
    private Player player;
	//declare boolean to contain griffin-specific code
    public bool isToActivateGriffin;
    //Restore save bool
    public bool RestoreSaveBattle;

    private void Start()
    {
		//assign player
        player = FindObjectOfType<Player>();
    }

    //Traps player after they pass a barrier and forces them into a fight.
    private void Update()
    {
		//condition for after passing collider
        if (HasPlayerPassed == true && player.transform.position.x > transform.position.x || HasPlayerPassed && RestoreSaveBattle)
        {
			//start boss fight animation if boss object exists
			if (boss) {
				boss.GetComponent<Animator>().SetTrigger("PlayerNearby");
				if (isToActivateGriffin)
				{
					gameObject.GetComponent<BoxCollider2D>().enabled = false;
				}
			}
        }
    }

    //If a player has passed through the collider, declare to the above statement that the player has activated the trigger.
    private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.gameObject.CompareTag("Player"))
        {
            HasPlayerPassed = true;
        }
    }

    //Used for restoring the last save in a boss battle.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (RestoreSaveBattle)
        {
            HasPlayerPassed = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (RestoreSaveBattle)
        {
            HasPlayerPassed = true;
        }
    }
}
