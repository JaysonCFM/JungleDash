using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2BossStart : MonoBehaviour
{
    //Barrier gameobjects
    public GameObject BarrierOne, BarrierTwo;

    //Array for levers in the battle
    public static bool[] LeversActivate = new bool[4];

	//declare animator for enemy and enemy
    private Animator animator;
    private Enemy enemy;

    private void Start()
    {
		//assign animator for enemy and enemy
        animator = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (gameObject.GetComponent<Enemy>().Health <= 0)
        {
			//remove barriers from boss arena
            FreePlayer();
        }

        if (LeversActivate[0] == true && LeversActivate[1] == true && LeversActivate[2] == true && LeversActivate[3] == true)
        {
			//explode totem enemy
            animator.SetTrigger("Dead");
        }
    }

    //When the player enters the temple they're trapped in the arena
    public void TrapPlayer()
    {
        BarrierOne.GetComponent<BoxCollider2D>().isTrigger = false;
        BarrierTwo.GetComponent<BoxCollider2D>().isTrigger = false;
        BarrierOne.GetComponent<SpriteRenderer>().enabled = true;
        BarrierTwo.GetComponent<SpriteRenderer>().enabled = true;

    }

    //When triggered, the box will disable and the player can leave.
    public void FreePlayer()
    {
        BarrierTwo.SetActive(false);
    }

    //Once all levers have been pulled, the explosion plays and the player is freed. All levers are reset in case the player comes back again later.
    private void Death()
    {
        for (int i = 0; i < LeversActivate.Length; i++)
        {
            LeversActivate[i] = false;
        }
        enemy.Health = 0;
    }
}