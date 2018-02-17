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

    //string that chooses spot in array for the item.
    public string ItemName;
	//declare item description text
    public string ItemDescription;
	//declare text display object
    public Text text;
	//declare booleans for whether product is an item or a weapon
    public bool IsItem, IsWeapon;
	//declare select input numeral
    private float selectInput;
	//declare bamboo blow gun object
    public GameObject Gun;
   
    private void Update()
    {
        //allows the item to be bought if they are over the item
        if (IsOverItem)
        {
			//call buy item method
            BuyItem();
        }
		//declare submission input source
        selectInput = Input.GetAxisRaw("Submit");
    }

	//collision w buying location method
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            //when you hit the trigger on the buyer, then it sets IsOverItem true
            IsOverItem = true;
        }
    }

    //lets you only buy if you are on the pedestal
    private void OnTriggerStay2D(Collider2D collision)
    {
		//collision reinforcement
        if (collision.gameObject.GetComponent<Player>())
        {
            IsOverItem = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    //allows you to buy from when only on the platform, otherwise buying prompt disappears
    {
        IsOverItem = false;
        text.text = "";
    }

    private void BuyItem()
    {
        text.text = ItemDescription;
        //when you press Spacebar it buys the item
        if (selectInput >= 1 && itemCounter == 0)
        {
			//subtract item cost from health, accounting for difficulty level
			if (PlayerPrefsManager.GetDifficulty() == 0f) {
				PlayerPrefsManager.DealDamage(Cost);
			}
			if (PlayerPrefsManager.GetDifficulty() == 1f) {
				PlayerPrefsManager.DealDamage(Cost / 2);
			}
			if (PlayerPrefsManager.GetDifficulty() == 2f) {
				PlayerPrefsManager.DealDamage(Cost / 4);
			}
			//if-statements to put item in correct inventory slot
            if (IsItem)
            {
                PlayerPrefsManager.SetInventory(ItemName);
            }
            else if (IsWeapon)
            {
                PlayerPrefsManager.SetWeapon(ItemName);
            }
            else if (ItemName == "Rapid Fire")
            {
				//add rapid fire upgrade to gun
                PlayerPrefsManager.SetRapidFire("true");
            }
			//increment item count
            itemCounter++;
        }
    }
}