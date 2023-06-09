using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXController : MonoBehaviour {

    public AudioSource effectSource;
    public AudioClip[] catEffect;
    public AudioClip[] babyEffect;
    public AudioClip[] coffeeEffect;
    public AudioClip typingErrorEffect;
    public AudioClip typingSuccessEffect;
    public AudioClip transitionEffect;
    public AudioClip messageEffect;
    
    public enum DistractionEffect {
        CatHappy,
        CatSad,
        CatTimeOut,
        BabyHappy,
        BabySad,
        Yawn,
        PourCoffee,
        DrinkCoffee,
        MachineSound,
    }

    public enum TypingEffect {
        Error,
        Success,
    }
    
    public enum MiscEffect {
        Transition,
        Message,
    }
    
    // Singleton instance.
    public static FXController instance = null;
	
    // Initialize the singleton instance.
    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }
    
    // Play a distraction effect.
    public void PlayDistractionEffect(DistractionEffect effect) {
        switch (effect) {
            case DistractionEffect.CatSad: effectSource.PlayOneShot(catEffect[0]);
                break;
            case DistractionEffect.CatHappy: effectSource.PlayOneShot(catEffect[1]);
                break;
            case DistractionEffect.CatTimeOut: effectSource.PlayOneShot(catEffect[2]);
                break;
            case DistractionEffect.BabyHappy: effectSource.PlayOneShot(babyEffect[1]);
                break;
            case DistractionEffect.BabySad: effectSource.PlayOneShot(babyEffect[0]);
                break;
            case DistractionEffect.Yawn: effectSource.PlayOneShot(coffeeEffect[0]);
                break;
            case DistractionEffect.MachineSound: effectSource.PlayOneShot(coffeeEffect[1]);
                break;
            case DistractionEffect.PourCoffee: effectSource.PlayOneShot(coffeeEffect[2]);
                break;
            case DistractionEffect.DrinkCoffee: effectSource.PlayOneShot(coffeeEffect[3]);
                break;
        }
    }
    
    // Play a typing effect.
    public void PlayTypingEffect(TypingEffect effect) {
        switch (effect) {
            case TypingEffect.Error: effectSource.PlayOneShot(typingErrorEffect);
                break;
            case TypingEffect.Success: effectSource.PlayOneShot(typingSuccessEffect, 0.2f);
                break;
        }
    }

    public void PlayMiscEffect(MiscEffect effect) {
        switch (effect) {
            case MiscEffect.Transition: effectSource.PlayOneShot(transitionEffect);
                break;
            case MiscEffect.Message: effectSource.PlayOneShot(messageEffect);
                break;
        }
    }

    // Start is called before the first frame update
    void Start() {
        this.effectSource.volume = 1f;
    }

    // Update is called once per frame
    void Update() {
    }
}
