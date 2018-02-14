using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {

    public int HealthToGive;

    private bool Activated;
	
	// Update is called once per frame
	void Update () {
        //Adds health to player, but does not exceed 100. Destroys the health pack afterwards.
		if (Activated)
        {
            if ((PlayerPrefsManager.GetHealth() + HealthToGive) <= 100)
            {
                PlayerPrefsManager.AddHealth(HealthToGive);
            }
            else if ((PlayerPrefsManager.GetHealth() + HealthToGive) > 100)
            {
                PlayerPrefsManager.SetHealth(100);
            }
            Destroy(gameObject);
            Activated = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Activated = true;
        }
    }
}
