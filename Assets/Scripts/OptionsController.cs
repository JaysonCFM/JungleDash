using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;

    public LevelManager levelManager;

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
	}
	
	// Update is called once per frame
	void Update () {
        musicManager.ChangeVolume(volumeSlider.value);
	}

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        levelManager.LoadLevel("TitleScreen");
    }

    public void DeleteProgress()
    {
        //Deletes everything about the game, and all progress.
        PlayerPrefsManager.UnlockLevel(0);
        PlayerPrefsManager.SetWeapon("No Weapon");
        PlayerPrefsManager.SetHealth(100);
        print("Game reset.");
    }
}
