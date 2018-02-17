using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgain : MonoBehaviour
{

    //Method if the player dies
    public void PlayGameAgain()
    {
        PlayerPrefsManager.SetLives(3);
        PlayerPrefsManager.SetHealth(100);
    }
}