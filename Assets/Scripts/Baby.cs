using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Baby : Distraction {
    
    public static MonoBehaviour _instance = null;
    
    private Baby() {
        this.times = new float[] { 5 };
        this.levels = new int[] { 0 };
    }

    public static MonoBehaviour Instance() {
        if (_instance == null) {
            _instance = GameObject.FindObjectOfType<Baby>();
        }
        return _instance;
    }
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if ((int) Math.Round(((DistractionController)DistractionController.Instance()).timer) == 55) {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
