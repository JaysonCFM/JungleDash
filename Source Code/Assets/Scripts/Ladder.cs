using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

	//declare player
    private Player player;

    //Default speed when climbing up ladder
    public float speed = 5;

    //Used by Input Manager
    private float verticalInput;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Player>();
	}

    private void Update()
    {
        //Receives input from the Input Manager
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Moves player's velocity up or down based on which key is pressed.
        if (collision.tag == "Player" && verticalInput >= 1)
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

        }
        else if (collision.tag == "Player" && verticalInput <= -1)
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
        else
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
		//reverts to normal movement after leaving the ladder object
        if (collision.gameObject.GetComponent<Player>())
        {
            //Reverts to normal
            player.IsMapCharacter = false;
            player.GetComponent<Rigidbody2D>().mass = 1;
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
