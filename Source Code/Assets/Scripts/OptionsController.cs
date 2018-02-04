using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider, difficultySlider;

    public LevelManager levelManager;

    private MusicManager musicManager;

	public Text difficultySelected;


	// Use this for initialization
	void Start () {
        musicManager = FindObjectOfType<MusicManager>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
		difficultySelected = FindObjectOfType<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		//update the volume selection
		musicManager.ChangeVolume(volumeSlider.value);
		//update the text of the selected difficulty (difficulty name and color)
		if (difficultySlider.value == 0) {
			difficultySelected.text = "Easy";
			difficultySelected.color = new Color(76.0f / 255.0f, 175.0f / 255.0f, 80.0f / 255.0f);
		}
		else if (difficultySlider.value == 1) {
			difficultySelected.text = "Medium";
			difficultySelected.color = new Color(255.0f / 255.0f, 235.0f / 255.0f, 59.0f / 255.0f);
		}
		else if (difficultySlider.value == 2){
			difficultySelected.text = "Hard";
			difficultySelected.color = new Color(201.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f);
		}
	}

	//function to save volume and difficulty selections upon exiting the options menu with the back button
    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        levelManager.LoadLevel("TitleScreen");
    }

}
