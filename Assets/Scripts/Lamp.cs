using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour {

    private float red, green, blue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;

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
        GameObject player = collision.gameObject;
        if (player.GetComponent<Player>())
        {
            LightUpPlayer(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;

        player.GetComponent<SpriteRenderer>().color = new Color(red, green, blue);
    }

    void LightUpPlayer(GameObject LightUp)
    {
        LightUp.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
    }
}
