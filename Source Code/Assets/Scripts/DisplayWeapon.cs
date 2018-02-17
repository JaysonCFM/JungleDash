using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWeapon : MonoBehaviour {

	//declare weapons objects
    public GameObject Stick, Stick2, Gun;
	
	void LateUpdate () {
        //Talks to the array in the weapons, and displays the weapon.
		if (Weapon.Weapons[0])
        {
			//stick
            Stick.SetActive(true);
            Stick2.SetActive(false);
            Gun.SetActive(false);
        }
        else if (Weapon.Weapons[1])
        {
			//upgraded stick
            Stick.SetActive(false);
            Stick2.SetActive(true);
            Gun.SetActive(false);
        }
        else if (Weapon.Weapons[2])
        {
			//bamboo rifle
            Stick.SetActive(false);
            Stick2.SetActive(false);
            Gun.SetActive(true);
        }
        else if (Weapon.Weapons[3])
        {
			//empty
            Stick.SetActive(false);
            Stick2.SetActive(false);
            Gun.SetActive(false);
        }
    }
}
