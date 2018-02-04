using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public Transform canvas;

    public bool isPaused;

    private bool IsPressed;

    private float pauseInput;

    // Update is called once per frame
    void Update () {

        pauseInput = Input.GetAxisRaw("Pause");

        if (pauseInput >= 1)
        {
            if (IsPressed == false)
            {
                IsPressed = true;
                Pause();
            }
        }
        else if (pauseInput <= -1)
        {
            if (IsPressed == true)
            {
                IsPressed = false;
                Pause();
            }
        }
    }

    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            isPaused = true;
            AudioListener.volume = 0;
        } else
        {
            canvas.gameObject.SetActive(false);
            isPaused = false;
            AudioListener.volume = 1;
        }

        if (isPaused)
        {
            Time.timeScale = 0;
        }

        if (!isPaused)
        {
            Time.timeScale = 1;
        }
    }
}
