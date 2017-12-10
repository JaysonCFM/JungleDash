using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    private Player player;
    private Animator animator;
    public static bool[] Weapons = new bool[5];
    public GameObject Stick, Stick2, Weapon3, Gun;
    public int DamageToTake;

    private bool IsArmed;

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
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        SelectedWeapon();

        //TODO: Add more weapons later
        if (Weapons[0])
        {
            Stick.SetActive(true);
            Stick2.SetActive(false);
            //Weapon3.SetActive(false);
            //Gun.SetActive(false);
        }
        else if (Weapons[1])
        {
            Stick.SetActive(false);
            Stick2.SetActive(true);
            //Weapon3.SetActive(false);
            //Gun.SetActive(false);
        }
        //else if (Weapons[2])
        //{
        //    Stick.SetActive(false);
        //    Stick2.SetActive(false);
        //    //Weapon3.SetActive(true);
        //    //Gun.SetActive(false);
        //}
        //else if (Weapons[3])
        //{
        //    Stick.SetActive(false);
        //    Stick2.SetActive(false);
        //    //Weapon3.SetActive(false);
        //    //Gun.SetActive(true);
        //}
        else if (Weapons[4])
        {
            Stick.SetActive(false);
            Stick2.SetActive(false);
            //Weapon3.SetActive(false);
            //Gun.SetActive(false);
        }
    }

    private static void SelectedWeapon()
    {
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
        //TODO: CHANGE TO WEAPON 3
        //else if (PlayerPrefsManager.GetWeapon() == "Weapon 3")
        //{
        //    Weapons[0] = false;
        //    Weapons[1] = false;
        //    Weapons[2] = true;
        //    Weapons[3] = false;
        //}
        //else if (PlayerPrefsManager.GetWeapon() == "Gun")
        //{
        //    Weapons[0] = false;
        //    Weapons[1] = false;
        //    Weapons[2] = false;
        //    Weapons[3] = true;
        //}
        else if (PlayerPrefsManager.GetWeapon() == "No Weapon")
        {
            Weapons[0] = false;
            Weapons[1] = false;
            Weapons[2] = false;
            Weapons[3] = false;
            Weapons[4] = true;
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
