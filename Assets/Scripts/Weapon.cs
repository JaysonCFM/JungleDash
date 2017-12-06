using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    private Player player;
    private SpriteRenderer sr;
    private Animator animator;
    public static bool[] Weapons = new bool[4];
    public GameObject Stick, Weapon2, Weapon3, Gun;
    public int DamageToTake;

    private bool IsArmed;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        int allWeapons = 0;
        for (int i = 0; i < Weapons.Length; i++)
        {
            if (Weapons[i] == false)
            {
                allWeapons++;
            }
        }

        if (allWeapons >= 4)
        {
            SetWeapon(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        //TODO: Add more weapons later
        if (Weapons[0])
        {
            Stick.SetActive(true);
            //Weapon2.SetActive(false);
            //Weapon3.SetActive(false);
            //Gun.SetActive(false);
        }
    }

    private void Attack()
    {
        if (Weapons[0])
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

    public static void SetWeapon(int WeaponToSet)
    {
        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i] = false;
        }

        Weapons[WeaponToSet] = true;
    }

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
