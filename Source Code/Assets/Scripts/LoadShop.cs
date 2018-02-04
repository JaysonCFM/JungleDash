using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadShop : MonoBehaviour {


    private LevelManager levelManager;
    private bool IsOverDoor;
    public bool Shop1, Shop2, Shop3;
    public static Vector3 LocationToRespawn;
    private Player player;

    public static string PreviousLevel;

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
        selectInput = Input.GetAxisRaw("Submit");

        if (IsOverDoor)
        {
            EnterShop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when you hit the trigger on the door, then it sets IsOverDoor true
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
            LocationToRespawn = player.transform.position;
            if (Shop1)
            {
                levelManager.LoadLevel("Shop 1");
            }
            if (Shop2)
            {
                levelManager.LoadLevel("Shop 2");
            }
            if (Shop3)
            {
                levelManager.LoadLevel("Shop 3");
            }

        Scene ShopName = SceneManager.GetActiveScene();

        PreviousLevel = ShopName.name;

        }
    }
}
