using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    //When the player falls off the bottom, they hit a trigger that will force their health to 0 and kill the player.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPrefsManager.SetHealth(0);
        PlayerPrefsManager.SetLocation(0, 0, 0);
        PlayerPrefsManager.SetCheckpoint("false");
        PlayerPrefsManager.UnlockLevel(1);
        //PlayerPrefsManager.SetWeapon("No Weapon");
        //PlayerPrefsManager.SetInventory("No Item");
    }
}
