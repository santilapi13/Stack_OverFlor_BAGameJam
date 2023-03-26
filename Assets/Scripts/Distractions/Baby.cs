using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Baby : Distraction {

    public static MonoBehaviour _instance = null;

    private Baby() {
        this.times = new int[] { 55, 32, 21, 15, 3 };
        this.levels = new int[] { 0 };
        this.reactionTime = 3;
    }

    public static MonoBehaviour Instance() {
        if (_instance == null) {
            _instance = GameObject.FindObjectOfType<Baby>();
        }
        return _instance;
    }

    private void OnMouseDown() {
        if (isActivated) {
            GetComponent<SpriteRenderer>().color = Color.green;
            isActivated = false;
        }   
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
