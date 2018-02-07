using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCheck : MonoBehaviour {

    private LevelManager levelManager;
    public string LevelToLoad;
    private Text text;
    public string LevelName;
    public int LevelNumber;

    public static int CheckpointLevelNumber;

    private bool IsOverLevel;

    private float selectInput;

    public float DefaultX, DefaultY, DefaultZ;

    // Use this for initialization
    void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        text = FindObjectOfType<Text>();
        text.text = "";

//		DefaultX = PlayerPrefs.GetFloat (PLAYER_X); 
//		DefaultY = PlayerPrefs.GetFloat (PLAYER_Y);
//		DefaultZ = PlayerPrefs.GetFloat(PLAYER_Z);

        if (PlayerPrefsManager.GetUnlockedLevel() == 26)
        {
            levelManager.LoadLevel("Win Screen");
        }

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
        selectInput = Input.GetAxisRaw("Submit");

        if (IsOverLevel)
        {
            LevelAppear();
        }
    }

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
