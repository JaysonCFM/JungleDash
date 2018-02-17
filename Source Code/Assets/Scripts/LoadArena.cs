using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadArena : MonoBehaviour {

	//declare level manager, platform collison boolean, arena scene boolean, 
	//vector for location to return post-fight, 
	//player, input for spacebar, and prev. level name string
    public LevelManager levelManager;
    private bool IsOverCloud;
    public bool Arena;
	public static Vector3 LocationToReturn;
    public Player player;    
    private float selectInput;
	public static string PreviousScene;

	//this just automates the process of finding the level manager so you dont have to manually drag it in
	void Start()
    {
		//assign level manager and player objects
        levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
		//checks for spacebar input
        selectInput = Input.GetAxisRaw("Submit");

		//when you press spacebar inside of the trigger for the door then it will assign return location and then throw you into the arena
		if (selectInput >= 1)
		{
            PlayerPrefsManager.SetCheckpoint("false");
            if (IsOverCloud && ExitArena.GriffinIsDead == false) {
				//save location outside arena to respawn player at after fight
				LocationToReturn = player.transform.position;
				levelManager.LoadLevel ("Level 3 boss scene");
				//declare and assign previous scene to return to when exiting arena
				Scene Level3 = SceneManager.GetActiveScene ();
				PreviousScene = Level3.name;
			}
		}
    }

	//only when you stand on one of the clouds will pressing space will put you in the arena scene
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsOverCloud = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        IsOverCloud = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsOverCloud = false;
    }
}
