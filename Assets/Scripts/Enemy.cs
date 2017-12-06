using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attached to every enemy, this creates a framework of what every enemy will have.
public class Enemy : MonoBehaviour {

    public int DamageToDeal;

    public int Health;

    private void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HurtPlayer(collision);
    }

    private void HurtPlayer(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            PlayerPrefsManager.DealDamage(DamageToDeal);
        }
    }

    public void TakeDamage(int DamageToTake)
    {
        Health -= DamageToTake;
    }
}
