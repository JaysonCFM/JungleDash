using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//deals fall damage to player (used on level 2)
		if (PlayerPrefsManager.GetHealth () >= 25) {
			PlayerPrefsManager.SubtractHealth (12);
		} else {
			PlayerPrefsManager.SetHealth (1);
		}
	}
}
