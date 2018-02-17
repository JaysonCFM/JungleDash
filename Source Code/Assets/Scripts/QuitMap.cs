using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitMap : MonoBehaviour {
    //Used for saving the map if the player quits there

    public void QuitName()
    {
        Scene MapName = SceneManager.GetActiveScene();
        PlayerPrefsManager.SetLevelName(MapName.name);
    }
}
