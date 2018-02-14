using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour {
	//barriers between which the enemy will loop
    public GameObject BarrierOne, BarrierTwo;
	//boolean for enemy being alive
    public bool isMonkey;

    private void Update()
    {
        if (gameObject.GetComponent<Enemy>().Health <=0)
        {
            FreePlayer();
        }
    }

    //When the activation animation happens, the player will be trapped into a box and forced to fight the enemy.
    public void TrapPlayer()
    {
        if (isMonkey)
        {
            BarrierTwo.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        else
        {
            BarrierOne.GetComponent<BoxCollider2D>().isTrigger = false;
            BarrierTwo.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    //When triggered, the boxes will disable and the player can leave.
    public void FreePlayer()
    {
        if (isMonkey)
        {
            BarrierOne.SetActive(false);
            BarrierTwo.SetActive(false);
        }
    }
}
