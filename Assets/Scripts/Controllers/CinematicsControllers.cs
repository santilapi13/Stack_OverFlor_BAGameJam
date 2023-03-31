using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CinematicsControllers : MonoBehaviour {

    public Sprite[] backgrounds;
    private int currentBackground = 0;
    public string nextScene;

    static public CinematicsControllers instance;
    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    
    // Start is called before the first frame update
    void Start() {
        
    }

    public void nextBackground() {
        FXController.instance.PlayMiscEffect(FXController.MiscEffect.Transition);
        if (currentBackground < backgrounds.Length - 1) {
            currentBackground++;
            GetComponent<SpriteRenderer>().sprite = backgrounds[currentBackground];
        } else {
            TransitionsController.instance.changeScene(nextScene);
        }
    }
    
    public void OnMouseDown() {
        nextBackground();
    }
    
    // Update is called once per frame
    void Update() {
        if (backgrounds.Length > 0 && Input.anyKeyDown) {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                nextBackground();
        }
    }
}
