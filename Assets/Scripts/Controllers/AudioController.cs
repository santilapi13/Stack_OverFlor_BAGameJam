using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    
    public AudioSource musicSource;
    public AudioClip noIntroMusic;
    
    // Singleton instance.
    public static AudioController instance = null;
	
    // Initialize the singleton instance.
    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if ((int)TyperController.instance.getIntroTimer() == 3) {
            musicSource.PlayOneShot(musicSource.clip);
        } else if (TyperController.instance.getTimer() <= 0)
            musicSource.Stop();
        else if (!musicSource.isPlaying) {
            musicSource.clip = noIntroMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
}
