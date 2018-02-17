using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	//declare pause menu canvas and boolean for game being paused
    public Transform canvas;
    public bool isPaused;

    // Update is called once per frame
    void Update () {
		//when esc key is pressed, pause menu is called
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
	//pause menu method
    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            isPaused = true;
			//stop music / other sound fx when paused
            AudioListener.volume = 0;
        } else
        {
            canvas.gameObject.SetActive(false);
            isPaused = false;
			//resume music / other sound fx when unpaused
            AudioListener.volume = 1;
        }
		//freeze game time when paused
        if (isPaused)
        {
            Time.timeScale = 0;
        }
		//restart game time when unpaused
        if (!isPaused)
        {
            Time.timeScale = 1;
        }
    }
}
