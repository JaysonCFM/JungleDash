using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioClip sceneMusic = levelMusicChangeArray[scene.buildIndex];
        if (!sceneMusic) return;
        audioSource.clip = sceneMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
