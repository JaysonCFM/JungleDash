using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    private Player player;

    public float speed = 5;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKey(KeyCode.W))
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

        }
        else if (collision.tag == "Player" && Input.GetKey(KeyCode.S))
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
        if (collision.gameObject.GetComponent<Player>())
        {
            //Reverts to normal
            player.IsMapCharacter = false;
            player.GetComponent<Rigidbody2D>().mass = 1;
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
