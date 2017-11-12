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

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        text = FindObjectOfType<Text>();
        text.text = "";

        if (PlayerPrefsManager.GetUnlockedLevel() == 0)
        {
            PlayerPrefsManager.SetHealth(100);
            //REMOVE THIS AND MAKE TUTORIAL LATER.
            levelManager.LoadLevel("Jayson's Testing Scene");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelAppear();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        LevelAppear();
    }

    //When the player goes away from the level, the text resets.
    private void OnTriggerExit2D(Collider2D collision)
    {
        text.text = "";
    }

    private void LevelAppear()
    {
        //When the player is on top of the level, then it will show the level name and when the level is selected, the game will load it.
        text.text = LevelName;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            levelManager.LoadLevel(LevelToLoad);
            text.text = "Loading";
        }
    }
}
