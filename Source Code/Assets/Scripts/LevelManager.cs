using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	//float for index of next level to auto load after current
    public float autoLoadNextLevelAfter;

    //Allows for automatic scene timing like the splashscreen or a cutscene.
    private void Start()
    {
        if (autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("Load disabled, use a positive number in seconds");
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

    //Called on by other scripts to load another scene.
    public void LoadLevel(string name)
    {
        //If the game was paused, then the game will resume time and music after loading.
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            AudioListener.volume = 1;
        }
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }

    //Used to exit the game
    public void QuitRequest()
    {
        Application.Quit();
    }

    //Loading a level that comes next in sequential build order.
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
