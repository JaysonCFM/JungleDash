using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCheck : MonoBehaviour {
	//declare level manager
    private LevelManager levelManager;
	//declare name of level being loaded
    public string LevelToLoad;
	//declare text display
    private Text text;
	//declare string for level name
    public string LevelName;
	//declare integer for level index number
    public int LevelNumber;
	//declare integer for checkpoint level
    public static int CheckpointLevelNumber;
	//declare boolean for player hovering on a level in the map
    private bool IsOverLevel;
	//declare input source
    private float selectInput;
	//declare default spawn coordinates
    public float DefaultX, DefaultY, DefaultZ;

    // Use this for initialization
    void Start () {
		//assign level manager and text display
        levelManager = FindObjectOfType<LevelManager>();
        text = FindObjectOfType<Text>();
		//initialize text display's string to display as nothing
        text.text = "";
		//condition for the cutscene game over screen to load when player unlocks final level index
        if (PlayerPrefsManager.GetUnlockedLevel() == 4)
        {
            levelManager.LoadLevel("Cutscene");
        }
		//condition for the level check object to activate when a new level is unlocked
        if (PlayerPrefsManager.GetUnlockedLevel() >= LevelNumber)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }

        
    }

    private void Update()
    {
		//assign input source
        selectInput = Input.GetAxisRaw("Submit");
		//have level name appear when player is over a level on the map
        if (IsOverLevel)
        {
            LevelAppear();
        }
    }

	//upon collision with level selection object the isOverLevel boolean becomes true
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsOverLevel = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        IsOverLevel = true;
    }

    //When the player goes away from the level, the text resets.
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsOverLevel = false;
        text.text = "";
    }

    private void LevelAppear()
    {
        //When the player is on top of the level, then it will show the level name and when the level is selected, the game will load it.
        text.text = LevelName;
        if (selectInput >= 1)
        {
            if (LevelNumber == PlayerPrefsManager.GetUnlockedLevel())
            {
                if (PlayerPrefsManager.PlayerLocation().x == 0 && PlayerPrefsManager.PlayerLocation().y == 0 && PlayerPrefsManager.PlayerLocation().z == 0)
                {
                    PlayerPrefsManager.SetLocation(DefaultX, DefaultY, DefaultZ);
                    PlayerPrefsManager.SetCheckpoint("true");
                }
                else
                {
                    PlayerPrefsManager.SetCheckpoint("true");
                }
            }
            else if (LevelNumber < PlayerPrefsManager.GetUnlockedLevel() || LevelNumber > PlayerPrefsManager.GetUnlockedLevel())
            {
                PlayerPrefsManager.SetLocation(DefaultX, DefaultY, DefaultZ);
                PlayerPrefsManager.SetCheckpoint("true");
            }

            CheckpointLevelNumber = LevelNumber;
            levelManager.LoadLevel(LevelToLoad);
            text.text = "Loading";
        }
    }
}
