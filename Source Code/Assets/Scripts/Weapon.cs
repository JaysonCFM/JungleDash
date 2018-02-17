using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	//declare player
    private Player player;
	//declare weapon animator
    private Animator animator;
	//declare weapon selection boolean array
    public static bool[] Weapons = new bool[4];
	//declare game objects for each weapon
    public GameObject Stick, Stick2, Gun, NoWeapon, Bullet;
    public int DamageToTake, DartSpeed;
	//decalre max timer (reset point) variable
    public float maxTimer = 0.5f;
	//decalre timer variable
    private float timer;
	//decalre isArmed boolean 
    private bool IsArmed;
	//decalre weapon input source variable
    private float weaponInput;

    // Use this for initialization
    void Start()
    {
		//assign player and weapon animator
        player = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
		//call selected weapon method for initialization
        SelectedWeapon();
    }

    // Update is called once per frame
    void Update()
    {
		//assigns weapon input source
        weaponInput = Input.GetAxisRaw("Weapon");
		//attack input
        if (weaponInput >= 1)
        {
            Attack();
        }
		//timer between attacks
        timer += Time.deltaTime;

        SelectedWeapon();

        //Hides from player the other weapons depending on current weapon
        //stick 1
		if (Weapons[0])
        {
            Stick.SetActive(true);
            Stick2.SetActive(false);
            Gun.SetActive(false);
            NoWeapon.SetActive(false);
        }
		//stick 2
        else if (Weapons[1])
        {
            Stick.SetActive(false);
            Stick2.SetActive(true);
            Gun.SetActive(false);
            NoWeapon.SetActive(false);
        }
		//bamboo blow gun
        else if (Weapons[2])
        {
            Stick.SetActive(false);
            Stick2.SetActive(false);
            Gun.SetActive(true);
            NoWeapon.SetActive(false);

			//flips the gun sprite with the player when they turn around
            if (player.GetComponent<SpriteRenderer>().flipX == true)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 222);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 45);
            }
			//increases dartspeed and lowers timer between dart discharge when active
            if (PlayerPrefsManager.ReturnRapidFire() == "true")
            {
                DartSpeed = 15;
                maxTimer = 0.25f;
            }
            else
            {
                DartSpeed = 10;
                maxTimer = 0.5f;
            }
        }
		//no weapon
        else if (Weapons[3])
        {
            Stick.SetActive(false);
            Stick2.SetActive(false);
            Gun.SetActive(false);
            NoWeapon.SetActive(true);
        }
    }

    private static void SelectedWeapon()
    {
        //Talks to the PlayerPrefsManager class, and sets the weapon based off of it.
        if (PlayerPrefsManager.GetWeapon() == "Stick")
        {
            Weapons[0] = true;
            Weapons[1] = false;
            Weapons[2] = false;
            Weapons[3] = false;
        }
        else if (PlayerPrefsManager.GetWeapon() == "Stick 2")
        {
            Weapons[0] = false;
            Weapons[1] = true;
            Weapons[2] = false;
            Weapons[3] = false;
        }
        else if (PlayerPrefsManager.GetWeapon() == "Gun")
        {
            Weapons[0] = false;
            Weapons[1] = false;
            Weapons[2] = true;
            Weapons[3] = false;
        }
        else if (PlayerPrefsManager.GetWeapon() == "No Weapon")
        {
            Weapons[0] = false;
            Weapons[1] = false;
            Weapons[2] = false;
            Weapons[3] = true;
        }
    }

    private void Attack()
    {
        //Specific attacks for each weapon, this is for the sticks.
        if (Weapons[0] || Weapons[1])
        {
            if (player.GetComponent<SpriteRenderer>().flipX)
            {
                animator.SetTrigger("Stick Activate Reverse");
            }
            else
            {
                animator.SetTrigger("Stick Activate Forward");
            }
        }
        //For the dart gun, a timer is made to prevent extreme rapid fire from the user. A dart prefab with attacked collider and physics is created, and is pushed away from the player like a bullet.
        else if (Weapons[2] && timer >= maxTimer)
        {
            if (player.GetComponent<SpriteRenderer>().flipX)
            {
                Vector3 offset = new Vector3(-0.25f, 0, 0);
                GameObject dart = Instantiate(Bullet, transform.position + offset, Quaternion.identity) as GameObject;
                dart.transform.eulerAngles = new Vector3(0,0,180);
                dart.GetComponent<Rigidbody2D>().velocity = new Vector3(-DartSpeed, 0, 0);
                timer = 0f;
            }
            else
            {
                Vector3 offset = new Vector3(0.25f, 0, 0);
                GameObject dart = Instantiate(Bullet, transform.position + offset, Quaternion.identity) as GameObject;
                dart.GetComponent<Rigidbody2D>().velocity = new Vector3(DartSpeed, 0, 0);
                timer = 0f;
            }
        }
    }

    //Sets boolean for the weapon animations
    private void Armed()
    {
        IsArmed = true;
    }
    private void UnArmed()
    {
        IsArmed = false;
    }

	//hurts enemy upon collision with weapon
    private void OnTriggerStay2D(Collider2D collision)
    {
        EnemyHurt(collision);
    }

    //Deals damage to enemy
    private void EnemyHurt(Collider2D collision)
    {
        GameObject Collision = collision.gameObject;
        Enemy enemy = Collision.GetComponent<Enemy>();

        if (enemy && IsArmed)
        {
            enemy.TakeDamage(DamageToTake);
        }
    }
}
