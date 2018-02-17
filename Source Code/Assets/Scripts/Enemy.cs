using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attached to every enemy, this creates a framework of what every enemy will have.
public class Enemy : MonoBehaviour {

	//declare integer for amount of damage dealt by enemy attack
    public int DamageToDeal;

    //Enemy's health
    public int Health;

    //Death of enemy
    private void Update()
    {
        //Deletes enemy after its health reaches zero.
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
		//deals damage to player
        HurtPlayer(collision);
    }

    //player takes damage when collides with enemy
    private void HurtPlayer(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(DamageToDeal);
        }
    }

	//enemy takes damage (gets called in other weapons scripts)
    public void TakeDamage(int DamageToTake)
    {
        Health -= DamageToTake;
    }
}
