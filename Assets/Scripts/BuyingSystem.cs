using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingSystem : MonoBehaviour {

    private bool IsOverItem;

    public int Cost, itemCounter;

   
    
    private void Update()
    {
        
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
    }

    private void BuyItem()
    {
        //when you press Spacebar it buys the item but it withdraws from your health
        if (Input.GetKeyDown(KeyCode.Space) && itemCounter == 0)
        {
            PlayerPrefsManager.DealDamage(Cost);
            itemCounter++;

        }
    }
}