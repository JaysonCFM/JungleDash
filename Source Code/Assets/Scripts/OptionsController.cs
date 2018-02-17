using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {
	//declare ui sliders for sound vol and game difficulty
    public Slider volumeSlider, difficultySlider;
	//declare level and music managers
	public LevelManager levelManager;
    private MusicManager musicManager;
	//declare text display for difficulty selection
	public Text difficultySelected;


	// Use this for initialization
	void Start () {
		//assignments (see declarations above)
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
			//green text
			difficultySelected.color = new Color(76.0f / 255.0f, 175.0f / 255.0f, 80.0f / 255.0f);
		}
		else if (difficultySlider.value == 1) {
			difficultySelected.text = "Medium";
			//yellow text
			difficultySelected.color = new Color(255.0f / 255.0f, 235.0f / 255.0f, 59.0f / 255.0f);
		}
		else if (difficultySlider.value == 2){
			difficultySelected.text = "Hard";
			//red text
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
