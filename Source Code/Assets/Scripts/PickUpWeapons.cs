using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapons : MonoBehaviour {

	//declare weapon name string an boolean for archeologist stick weapon vendor game object (doesn't get destoryed like usual)
    public string WeaponName;
    public bool IsArcheologist;

    //Automatic pickup of a weapon on the ground.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            PlayerPrefsManager.SetWeapon(WeaponName);
            //Prevents another pickup of the weapon because it becomes disabled unless it's a human.
            if (!IsArcheologist)
            {
				if (WeaponName == "Gun") {
					gameObject.SetActive(false);
				}
            }
        }
    }
}
