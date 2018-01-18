using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWeapon : MonoBehaviour {

    public GameObject Stick, Stick2, Gun;
	
	void LateUpdate () {
        //Talks to the array in the weapons, and displays the weapon.
		if (Weapon.Weapons[0])
        {
            Stick.SetActive(true);
            Stick2.SetActive(false);
            //Gun.SetActive(false);
        }
        else if (Weapon.Weapons[1])
        {
            Stick.SetActive(false);
            Stick2.SetActive(true);
            //Gun.SetActive(false);
        }
        //else if (Weapon.Weapons[2])
        //{
        //    Stick.SetActive(false);
        //    Stick2.SetActive(false);
        //    //Gun.SetActive(true);
        //}
    }
}
