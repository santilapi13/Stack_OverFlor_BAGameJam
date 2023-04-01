using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Distraction
{   
      // Singleton instance.
    public static Cat instance = null;
    private int numberOfClicks = 0;
    public Sprite[] sprites;
	
    // Initialize the singleton instance.
    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

       protected IEnumerator Wait(float seconds) {
        yield return new WaitForSeconds(seconds);
        if (isActivated) {
            GetComponent<SpriteRenderer>().enabled = false;
            GameController.instance.removeMoney(5);
            isActivated = false;
        }
    }
    
     private Cat() {
        this.times = new int[] {55};
        this.levels = new int[] { 0 };
        this.reactionTime = 5;
        this.positions = new Vector3[] { new Vector3(-4, 1, -2), new Vector3(-3, 0, -2), new Vector3(-4, -1, -2)};
        this.soundEffect = FXController.DistractionEffect.CatSad;
     }

    private void OnMouseDown() {
        if (isActivated) {
            if (numberOfClicks == 2) {
                FXController.instance.PlayTypingEffect(FXController.TypingEffect.Success);
                FXController.instance.PlayDistractionEffect(FXController.DistractionEffect.CatHappy);
                GetComponent<SpriteRenderer>().enabled = false;
                isActivated = false;
                numberOfClicks = 0;
            } else {
                FXController.instance.PlayDistractionEffect(FXController.DistractionEffect.CatSad);
                numberOfClicks++;
                spawnAtRandomPosition();
            }
            GetComponent<SpriteRenderer>().sprite = sprites[numberOfClicks];
        }   
    }

    void Start() {
        GetComponent<SpriteRenderer>().enabled = false;
    }

}
