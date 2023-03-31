using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CinematicsControllers : MonoBehaviour {

    public Sprite[] backgrounds;
    private int currentBackground = 0;
    public int currentScene;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    private void nextBackground() {
        FXController.instance.PlayMiscEffect(FXController.MiscEffect.Transition);
        if (currentBackground < backgrounds.Length - 1) {
            currentBackground++;
            GetComponent<SpriteRenderer>().sprite = backgrounds[currentBackground];
        } else {
            SceneManager.LoadScene(currentScene + 1);
        }
    }
    
    public void OnMouseDown() {
        nextBackground();
    }
    
    // Update is called once per frame
    void Update() {
        if (Input.anyKeyDown) {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                nextBackground();
        }
    }
}
