using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attached to every enemy, this creates a framework of what every enemy will have.
public class Enemy : MonoBehaviour {

	//declare integer for amount of damage dealt by enemy attack
    public int DamageToDeal;

	//declare boolean to lock code specific for griffin boss enemy 
    public bool Griffin;
	//declare 3-tier health system exclusive to griffin boss
    public int Health, MediumHealth, HardHealth;

    private void Start()
    {
        //Griffin's health changes based on difficulty, this sets it properly.
        if (Griffin)
        {
            if (PlayerPrefsManager.GetDifficulty() == 1f)
            {
                Health = MediumHealth;
            }
            if (PlayerPrefsManager.GetDifficulty() >= 2f)
            {
                Health = HardHealth;
            }
        }
    }

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
