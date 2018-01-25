using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    private Player player;
    private Animator animator;
    public static bool[] Weapons = new bool[4];
    public GameObject Stick, Stick2, Gun, NoWeapon, Bullet;
    public int DamageToTake, DartSpeed;

    private float timer;

    private bool IsArmed;

    private float weaponInput;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
        SelectedWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        weaponInput = Input.GetAxisRaw("Weapon");

        if (weaponInput >= 1)
        {
            Attack();
        }

        timer += Time.deltaTime;

        SelectedWeapon();

        //Hides from player the other weapons depending on current weapon
        if (Weapons[0])
        {
            Stick.SetActive(true);
            Stick2.SetActive(false);
            Gun.SetActive(false);
            NoWeapon.SetActive(false);
        }
        else if (Weapons[1])
        {
            Stick.SetActive(false);
            Stick2.SetActive(true);
            Gun.SetActive(false);
            NoWeapon.SetActive(false);
        }
        else if (Weapons[2])
        {
            Stick.SetActive(false);
            Stick2.SetActive(false);
            Gun.SetActive(true);
            NoWeapon.SetActive(false);

            if (player.GetComponent<SpriteRenderer>().flipX == true)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 222);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 45);
            }
        }
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
        //Specific attacks for each weapon, this is for the stick.
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
        else if (Weapons[2] && timer >= 0.5f)
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

    //Sets boolean for the animations
    private void Armed()
    {
        IsArmed = true;
    }

    private void UnArmed()
    {
        IsArmed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHurt(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        EnemyHurt(collision);
    }

    //Takes damage to enemy
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
