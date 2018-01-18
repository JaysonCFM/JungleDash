using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour {

    private Text text;
    private int health;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        ColorHealth();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Getting health from the playerprefs, and displays it
        health = PlayerPrefsManager.GetHealth();
        text.text = "Health: " + health.ToString();
		//update color of health text
        ColorHealth();
    }

    private void ColorHealth()
    {
        //Color gradient for health text depending on health level
        if (health >= 67)
        {
            text.color = new Color(76.0f / 255.0f, 175.0f / 255.0f, 80.0f / 255.0f);
        }
        else if (health < 67 && health >= 34)
        {
            text.color = new Color(255.0f / 255.0f, 235.0f / 255.0f, 59.0f / 255.0f);
        }
        else
        {
            text.color = new Color(201.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f);
        }
    }
}
