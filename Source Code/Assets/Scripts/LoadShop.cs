using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadShop : MonoBehaviour {

	//declare level manager
    private LevelManager levelManager;
	//declare boolean for player being in front of the shop entrance door
    private bool IsOverDoor;
	//declare booleans for which shop they're in (level 1 or 2)
    public bool Shop1, Shop2;
	//declare vector for location to return to after exiting shop
    public static Vector3 LocationToRespawn;
	//declare player
    private Player player;
	//declare string for name of previous level prior to shop
    public static string PreviousLevel;
	//declare input source
    private float selectInput;


    // Use this for initialization
    void Start()
    {
        //this just automates the process of finding the level manager so you dont have to manually drag it in
        levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
		//checks for spacebar input
        selectInput = Input.GetAxisRaw("Submit");
		//loads shop if spacebar is pressed while in front of entrance
        if (IsOverDoor)
        {
            EnterShop();
        }
    }

	//when you hit the trigger on the door, then it sets IsOverDoor true
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsOverDoor = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
		IsOverDoor = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
        //prevents from loading when you walk away from door 
    {
        IsOverDoor = false;
    }

    private void EnterShop()
    {
        //when you press spacebar inside of the trigger for the door then it will throw you into the level
        if (selectInput >= 1)
        {
            PlayerPrefsManager.SetCheckpoint("false");
            LocationToRespawn = player.transform.position;
            if (Shop1)
            {
                levelManager.LoadLevel("Shop 1");
            }
            if (Shop2)
            {
                levelManager.LoadLevel("Shop 2");
            }
		//declare and assign previous scene to return to when exiting shop
        Scene ShopName = SceneManager.GetActiveScene();
        PreviousLevel = ShopName.name;
        }
    }
}
