using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {
	//declare level manager, load button, and name of level to load
    private LevelManager levelManager;
    public GameObject LoadButton;
    public string LevelToLoad;

    //Bool for using a button
    public bool IsLastSaveButton;

	// Use this for initialization
	void Start () {
		//assign level manager 
        levelManager = FindObjectOfType<LevelManager>();
		//disables the load save button if the game has not been played before
        if (PlayerPrefsManager.GetUnlockedLevel() == 0)
        {
            LoadButton.GetComponent<Button>().interactable = false;
        }
		//otherwise it is enabled
        else if (PlayerPrefsManager.GetUnlockedLevel() >= 1)
        {
            LoadButton.GetComponent<Button>().interactable = true;
        }
	}
	
    //Starts game
    public void StartGame()
    {
        if (IsLastSaveButton)
        {
            LevelToLoad = PlayerPrefsManager.GetLevelName();
			PlayerPrefsManager.SetCheckpoint ("true");

        }
        //If the health is below zero, it will reset the health back to 100
        if (PlayerPrefsManager.GetLives() <= 0)
        {
            PlayerPrefsManager.SetLives(3);
            PlayerPrefsManager.SetHealth(100);
            levelManager.LoadLevel(LevelToLoad);
        } else
        {
            levelManager.LoadLevel(LevelToLoad);
        }

		//jf player has not made any progress (new game), tutorial loads
        if (PlayerPrefsManager.GetUnlockedLevel() == 0)
        {
            
            PlayerPrefsManager.SetLives(3);
            PlayerPrefsManager.SetHealth(100);
            levelManager.LoadLevel("TutorialScreen");
        }
    }

    public void DeleteProgress()
    {
        //Deletes everything about the game, and all progress.
        PlayerPrefsManager.UnlockLevel(0);
        PlayerPrefsManager.SetLocation(-977.1f, -7.94f, 0f);
        PlayerPrefsManager.SetWeapon("No Weapon");
        PlayerPrefsManager.SetInventory("No Items");
        PlayerPrefsManager.SetLives(3);
        PlayerPrefsManager.SetHealth(100);
        PlayerPrefsManager.SetRapidFire("false");
        PlayerPrefsManager.SetCheckpoint("true");
        LoadButton.GetComponent<Button>().interactable = false;
        print("Game reset.");
        levelManager.LoadLevel(LevelToLoad);
    }
}
