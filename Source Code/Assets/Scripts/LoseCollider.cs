using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private Player player;

    public bool IsTutorial;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    //When the player falls off the bottom, they hit a trigger that will force their health to 0 and kill the player.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsTutorial)
        {
            PlayerPrefsManager.SetHealth(0);
            player.transform.position = PlayerPrefsManager.PlayerLocation();
        }
        else
        {
            player.transform.position = new Vector3(-934.77f, -7.98f, 0);
        }
    }
}
