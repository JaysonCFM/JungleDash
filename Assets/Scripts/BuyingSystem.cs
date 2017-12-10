using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyingSystem : MonoBehaviour {
    //edge statement that makes it so the player has to be on the item to buy it
    private bool IsOverItem;
    //allows use to change the cost per item so each item can cost differently 
    public int Cost;
    //allows them to only buy one item per visit
    private int itemCounter;

    //Chooses spot in array for the item.
    public int SpotInArray;

    public string ItemDescription;

    public Text text;
   
    
    private void Update()
    {
        //allows the item to be bought if they are over the item
        if (IsOverItem)
        {
            BuyItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when you hit the trigger on the door, then it sets IsOverDoor true
        IsOverItem = true;


    }
    //lets you only buy if you are on the pedstool
    private void OnTriggerStay2D(Collider2D collision)
    {
        IsOverItem = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    //allows you to buy from when only on the platform
    {
        IsOverItem = false;
        text.text = "";
    }

    private void BuyItem()
    {
        text.text = ItemDescription;
        //when you press Spacebar it buys the item but it withdraws from your health
        if (Input.GetKeyDown(KeyCode.Space) && itemCounter == 0)
        {
            PlayerPrefsManager.DealDamage(Cost);
            Inventory.SetItem(SpotInArray);
            itemCounter++;

        }
    }
}