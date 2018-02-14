using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBoss : MonoBehaviour {

    public GameObject boss;

    private bool HasPlayerPassed;

    private Player player;

    public bool isToActivateGriffin;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    //Traps player after they pass a barrier and forces them into a fight.
    private void Update()
    {
        if (HasPlayerPassed == true && player.transform.position.x > transform.position.x)
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HasPlayerPassed = true;
        }
    }
}
