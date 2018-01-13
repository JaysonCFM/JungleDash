using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

    private LevelManager levelManager;
    public string LevelToLoad;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
    //Starts game
    public void StartGame()
    {
        //If the health is too low, it will reset the health back to 100
        if (PlayerPrefsManager.GetHealth() <= 0)
        {
            PlayerPrefsManager.SetHealth(100);
            PlayerPrefsManager.SetWeapon("No Weapon");
            PlayerPrefsManager.SetInventory("No Item");
            levelManager.LoadLevel(LevelToLoad);
        } else
        {
            levelManager.LoadLevel(LevelToLoad);
        }

        if (PlayerPrefsManager.GetUnlockedLevel() == 0)
        {
            PlayerPrefsManager.SetHealth(100);
            levelManager.LoadLevel("TutorialScreen");
        }
    }
}
