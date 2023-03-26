using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    
    public AudioSource musicSource;
    public AudioSource effectsSource;
    private string[] musicList = { "Sounds/level_0_audio" };
    
    // Singleton instance.
    public static AudioController instance = null;
	
    // Initialize the singleton instance.
    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad (gameObject);
    }

    // Play a single clip through the sound effects source.
    public void Play(AudioClip clip) {
        effectsSource.clip = clip;
        effectsSource.Play();
    }

    // Play a single clip through the music source.
    public void PlayMusic(AudioClip clip) {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if ((int) TyperController.instance.getTimer() == 60)
            PlayMusic(Resources.Load<AudioClip>(musicList[GameController.instance.getLevel()]));
        else if ( (int) TyperController.instance.getTimer() == 0)
            musicSource.Stop();
    }
}
