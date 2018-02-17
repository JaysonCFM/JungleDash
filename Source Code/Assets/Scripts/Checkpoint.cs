using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour {

	//declare player
    private Player player;

    private void Start()
    {
		//assign player
        player = FindObjectOfType<Player>();
    }

	//save player location upon collision with checkpoint object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() && PlayerPrefsManager.GetUnlockedLevel() == LevelCheck.CheckpointLevelNumber)
        {
            SetLocation();
        }
    }

    //Sets location if the player passes a checkpoint or clicks a save button.
    public void SetLocation()
    {
        Scene LevelName = SceneManager.GetActiveScene();
        PlayerPrefsManager.SetLevelName(LevelName.name);
        PlayerPrefsManager.SetLocation(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        PlayerPrefsManager.SetCheckpoint("true");
    }
}
