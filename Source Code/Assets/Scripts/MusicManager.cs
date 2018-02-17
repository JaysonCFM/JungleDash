using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
	//declare audio clip array and sound source
    public AudioClip[] levelMusicChangeArray;
    private AudioSource audioSource;

    private void OnEnable()
    {
		//activate on loading of scenes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
		//deactivate
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
		//assign sound source
        audioSource = GetComponent<AudioSource>();
		//condition for default sound vol if player didn't set it themselves
        if (!PlayerPrefs.HasKey(PlayerPrefsManager.MASTER_VOLUME_KEY))
        {
            PlayerPrefsManager.SetMasterVolume(0.8f);
        } else
        {
            audioSource.volume = PlayerPrefsManager.GetMasterVolume();
        }
    }

    private void Awake()
    {
		//stops sound object from being destoryed on scene loads
        DontDestroyOnLoad(gameObject);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
		//sets correct music track and starts playing
        AudioClip sceneMusic = levelMusicChangeArray[scene.buildIndex];
        if (!sceneMusic) return;
        audioSource.clip = sceneMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void ChangeVolume(float volume)
    {
		//change volume method
        audioSource.volume = volume;
    }
}
