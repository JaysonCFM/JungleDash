using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour {

    //RGB values for the lamp and the player
    private float red, green, blue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
		//assign player collider
        GameObject player = collision.gameObject;
		//If the player collides with the lamp, then the player looks like they're being lit up.
        if (player.GetComponent<Player>())
        {
            red = player.GetComponent<SpriteRenderer>().color.r;
            green = player.GetComponent<SpriteRenderer>().color.g;
            blue = player.GetComponent<SpriteRenderer>().color.b;
            LightUpPlayer(player);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
		//assign player collider
        GameObject player = collision.gameObject;
		//keeps player lit
        if (player.GetComponent<Player>())
        {
            LightUpPlayer(player);
        }
    }

    //Sets player back to original RGB values.
    private void OnTriggerExit2D(Collider2D collision)
    {
		//assign player collider
        GameObject player = collision.gameObject;
		//reset player lighting
        player.GetComponent<SpriteRenderer>().color = new Color(red, green, blue);
    }

    //gives player Full brightness values
    void LightUpPlayer(GameObject LightUp)
    {
        LightUp.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
    }
}
