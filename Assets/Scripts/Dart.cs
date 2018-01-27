using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour {

    public int DamageToTake = 10;

    //When the dart hits something like a wall or enemy, it will take appropriate action.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(DamageToTake);
            Destroy(gameObject);
        }
        //Prevents the trigger for zooming out from disabling the dart.
        else if (collision.gameObject.GetComponent<CameraZoomOut>())
        {
            //Acts as a blank comment to prevent destruction.
        }
        //Everything else will destroy the dart, except for the player.
        else if (!collision.gameObject.GetComponent<Player>())
        {
            Destroy(gameObject);
        }
    }
}
