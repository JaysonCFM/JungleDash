using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    //Uses an array to determine which item is available, based off of the boolean currently set.
    public static bool[] Items = new bool[12];

    private Player player;

    private float timer;

    private bool BloodCrossEnabled;

    public GameObject bomb;

    private float inventoryInput;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        inventoryInput = Input.GetAxisRaw("Inventory");

        ItemsInInventory();
        BloodCrossTimer();
        //Sets items and disables them after use
        if (inventoryInput >= 1)
        {

            if (Items[0])
            {
                Torch();
                Items[0] = false;
                PlayerPrefsManager.SetInventory("No Item");
            }
            else if (Items[1])
            {
                BloodCross();
                Items[1] = false;
                PlayerPrefsManager.SetInventory("No Item");
            }
            else if (Items[2])
            {
                Bomb(bomb);
                Items[2] = false;
                PlayerPrefsManager.SetInventory("No Item");
            }
            else if (Items[3])
            {
                Items[3] = false;
                PlayerPrefsManager.SetInventory("No Item");
            }
        }
    }

    void ItemsInInventory()
    {
        if (PlayerPrefsManager.GetInventory() == "Torch")
        {
            Items[0] = true;
            Items[1] = false;
            Items[2] = false;
            Items[3] = false;
            Items[4] = false;
            Items[5] = false;
            Items[6] = false;
            Items[7] = false;
            Items[8] = false;
            Items[9] = false;
            Items[10] = false;
            Items[11] = false;
        }
        else if (PlayerPrefsManager.GetInventory() == "Blood Cross")
        {
            Items[0] = false;
            Items[1] = true;
            Items[2] = false;
            Items[3] = false;
            Items[4] = false;
            Items[5] = false;
            Items[6] = false;
            Items[7] = false;
            Items[8] = false;
            Items[9] = false;
            Items[10] = false;
            Items[11] = false;
        }
        else if (PlayerPrefsManager.GetInventory() == "Bomb")
        {
            Items[0] = false;
            Items[1] = false;
            Items[2] = true;
            Items[3] = false;
            Items[4] = false;
            Items[5] = false;
            Items[6] = false;
            Items[7] = false;
            Items[8] = false;
            Items[9] = false;
            Items[10] = false;
            Items[11] = false;
        }
    }

    void Torch()
    {
        if (player.GetComponent<SpriteRenderer>().color.r < 255)
        {
            player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        }
    }

    //Gives 5 seconds if being invincible
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

    void BloodCrossTimer()
    {
        if (BloodCrossEnabled)
        {
            timer += Time.deltaTime;

            if (timer >= 5.0f)
            {
                PlayerPrefsManager.IsIndestructible = false;
                BloodCrossEnabled = false;
            }
        }
    }
}