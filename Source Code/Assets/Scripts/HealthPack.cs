using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {
	//declare health points to give integer
    public int HealthToGive;
	//declare collision / activation boolean
    private bool Activated;
	
	// Update is called once per frame
	void Update () {
        //Adds health to player if they're not already full, but does not exceed 100. 
		if (Activated)
        {
			if (PlayerPrefsManager.GetHealth () < 100) {
				if ((PlayerPrefsManager.GetHealth() + HealthToGive) <= 100)
				{
					PlayerPrefsManager.AddHealth(HealthToGive);
				}
				else if ((PlayerPrefsManager.GetHealth() + HealthToGive) > 100)
				{
					PlayerPrefsManager.SetHealth(100);
				}
				// resets acitvation boolean and destroys the health pack object afterwards.
				Activated = false;
				Destroy(gameObject);
			}
            
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		//activates the game object upon collision
        if (collision.gameObject.GetComponent<Player>())
        {
            Activated = true;
        }
    }
}
