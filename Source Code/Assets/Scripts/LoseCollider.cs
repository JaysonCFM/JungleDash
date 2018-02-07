using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    //When the player falls off the bottom, they hit a trigger that will force their health to 0 and kill the player.
    private void OnTriggerEnter2D(Collider2D collision)
    {
		PlayerPrefsManager.SetHealth(0);
        player.transform.position = PlayerPrefsManager.PlayerLocation();
    }
}
