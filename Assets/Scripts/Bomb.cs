using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    private float bombTimer;
    private GameObject enemy;
    private Animator animator;

    private bool IsExploded;

    private void Start()
    {
        bombTimer = 0;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        bombTimer += Time.deltaTime;
        Explosion();
    }

    void Explosion()
    {
        if (bombTimer >= 3.0f)
        {
            IsExploded = true;
            animator.SetTrigger("Explosion");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy = collision.gameObject;
        if (enemy.GetComponent<Enemy>() && IsExploded)
        {
            enemy.GetComponent<Enemy>().DamageToDeal = 5;
            IsExploded = false;
        }
        else if (enemy.GetComponent<Player>() && IsExploded)
        {
            PlayerPrefsManager.DealDamage(1);
            IsExploded = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        enemy = collision.gameObject;
        if (enemy.GetComponent<Enemy>() && IsExploded)
        {
            enemy.GetComponent<Enemy>().DamageToDeal = 5;
            IsExploded = false;
        }
        else if (enemy.GetComponent<Player>() && IsExploded)
        {
            PlayerPrefsManager.DealDamage(1);
            IsExploded = false;
        }
    }

    private void Destroy()
    {
        IsExploded = false;
        bombTimer = 0;
        Destroy(gameObject);
    }
}
