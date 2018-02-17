using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgain : MonoBehaviour {

    public void PlayGameAgain()
    {
		//resets level progress (except tutorial) and resets health and lives
        PlayerPrefsManager.UnlockLevel(3);
		PlayerPrefsManager.SetHealth(100);
		PlayerPrefsManager.SetLives(3);

    }
}
