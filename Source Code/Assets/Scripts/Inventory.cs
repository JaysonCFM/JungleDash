using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    //Uses an array to determine which item is available, based off of the boolean currently set.
    public static bool[] Items = new bool[4];

	//declare player
    private Player player;

    //Timer for items such as the blood cross.
    private float timer, bombReuseTimer;

    private bool BloodCrossEnabled, BombEnabled;

    //Designer drags in which prefab to use for the bomb.
    public GameObject bomb;

    //Used by the Input Manager for when the player right clicks.
    private float inventoryInput;

    private void Start()
    {
		//assign player
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
		//assign inventory input source
        inventoryInput = Input.GetAxisRaw("Inventory");
		//declare items in inventory
        ItemsInInventory();
		//declare bloodcross timer
        BloodCrossTimer();
        //Sets items and resets them after use
        if (inventoryInput >= 1)
        {
            //Determines which item to use based off the currently active item in the array.
            if (Items[0])
            {
                Torch();
                Items[0] = false;
				//resets it (unlimited use)
				PlayerPrefsManager.SetInventory("Torch");
            }
            else if (Items[1])
            {
                BloodCross();
				Items[1] = false;
				//gets rid of it (one time use)
                PlayerPrefsManager.SetInventory("No Item");
            }
			//
            else if (Items[2] && !BombEnabled)
            {
                Bomb(bomb);
                Items[2] = false;
                BombEnabled = true;
				//resets it (unlimited use)
                PlayerPrefsManager.SetInventory("Bomb");
            }
			else if (Items[3])
            {
				//nothing happens bc no item is in inventory
                Items[3] = false;
                PlayerPrefsManager.SetInventory("No Item");
            }
        }

        //Prevents a trail of bombs from occuring by requiring a wait in between use.
        if (BombEnabled)
        {
            bombReuseTimer+= Time.deltaTime;

            if (bombReuseTimer >= 1)
            {
                bombReuseTimer = 0;
                BombEnabled = false;
            }
        }
    }

    //Activates item in inventory array based off the string in PlayerPrefs.
    void ItemsInInventory()
    {
        if (PlayerPrefsManager.GetInventory() == "Torch")
        {
            Items[0] = true;
            Items[1] = false;
            Items[2] = false;
            Items[3] = false;
        }
        else if (PlayerPrefsManager.GetInventory() == "Blood Cross")
        {
            Items[0] = false;
            Items[1] = true;
            Items[2] = false;
            Items[3] = false;

        }
        else if (PlayerPrefsManager.GetInventory() == "Bomb")
        {
            Items[0] = false;
            Items[1] = false;
            Items[2] = true;
            Items[3] = false;

        }
    }

    //Lights the player up in dark levels like the cave.
    void Torch()
    {
        if (player.GetComponent<SpriteRenderer>().color.r < 255)
        {
            player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        }
    }

    //Gives 30 seconds of being invincible
    void BloodCross()
    {
        PlayerPrefsManager.IsIndestructible = true;
        BloodCrossEnabled = true;
    }

    //Explosive
    void Bomb(GameObject explosive)
    {
        GameObject bomb = Instantiate(explosive) as GameObject;
        bomb.transform.position = transform.position;
    }

    //Timer for blood cross
    void BloodCrossTimer()
    {
        if (BloodCrossEnabled)
        {
            timer += Time.deltaTime;

            if (timer >= 30.0f)
            {
                PlayerPrefsManager.IsIndestructible = false;
                BloodCrossEnabled = false;
            }
        }
    }
}