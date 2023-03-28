using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Baby : Distraction {

    // Singleton instance.
    public static Baby instance = null;
	
    // Initialize the singleton instance.
    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad (gameObject);
    }

    private Baby() {
        this.times = new int[] { 45, 32, 21, 15, 3 };
        this.levels = new int[] { 0 };
        this.reactionTime = 3;
        this.positions = new Vector3[] { new Vector3(4, -2, -2), new Vector3(3, -1, -2), new Vector3(4, 0, -2) };
    }

    private void OnMouseDown() {
        if (isActivated) {
            GetComponent<SpriteRenderer>().enabled = false;
            isActivated = false;
        }   
    }
    
    // Start is called before the first frame update
    void Start() {
        GetComponent<SpriteRenderer>().enabled = false;
    }

}
