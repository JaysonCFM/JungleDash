using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2BossStart : MonoBehaviour
{
    public GameObject BarrierOne, BarrierTwo;

    public static bool[] LeversActivate = new bool[4];

    private Animator animator;
    private Enemy enemy;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (gameObject.GetComponent<Enemy>().Health <= 0)
        {
            FreePlayer();
        }

        if (LeversActivate[0] == true && LeversActivate[1] == true && LeversActivate[2] == true && LeversActivate[3] == true)
        {
            animator.SetTrigger("Dead");
        }
    }

    //When the player enters the temple
    public void TrapPlayer()
    {
        BarrierOne.GetComponent<BoxCollider2D>().isTrigger = false;
        BarrierTwo.GetComponent<BoxCollider2D>().isTrigger = false;
        BarrierOne.GetComponent<SpriteRenderer>().enabled = true;
        BarrierTwo.GetComponent<SpriteRenderer>().enabled = true;

    }

    //When triggered, the boxes will disable and the player can leave.
    public void FreePlayer()
    {
        BarrierOne.SetActive(false);
        BarrierTwo.SetActive(false);
    }

    private void Death()
    {
        enemy.Health = 0;
    }
}