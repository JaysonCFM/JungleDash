using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	//declare bomb timer float number variable
    private float bombTimer;
	//declare enemy game object
    private GameObject enemy;
	//declare bomb animator
    private Animator animator;
	//declare boolean for bomb having exploded
    private bool IsExploded;

    private void Start()
    {
		//assign timer to start @ 0
        bombTimer = 0;
		//assign animator component
        animator = GetComponent<Animator>();
    }

    //Increases bomb timer every second
    private void Update()
    {
		//increment timer with change in time
        bombTimer += Time.deltaTime;
		//call explosion method
        Explosion();
    }

    //Explodes bomb after 3 seconds
    void Explosion()
    {
        if (bombTimer >= 3.0f)
		{
            IsExploded = true;
			//run explosion animation
            animator.SetTrigger("Explosion");
        }
    }

    //enemy bomb collison method
    private void OnTriggerEnter2D(Collider2D collision)
    {
		//declare enemy damage collider
        enemy = collision.gameObject;
		//Below 2 statements are for dealing damage
        if (enemy.GetComponent<Enemy>() && IsExploded)
        {
            enemy.GetComponent<Enemy>().TakeDamage(5);
            IsExploded = false;
        }
        else if (enemy.GetComponent<Player>() && IsExploded)
        {
            PlayerPrefsManager.DealDamage(1);
            IsExploded = false;
        }
    }

    //Destroys the game object and resets timer / explosion boolean after the animation.
    private void Destroy()
    {
        IsExploded = false;
        bombTimer = 0;
        Destroy(gameObject);
    }
}
