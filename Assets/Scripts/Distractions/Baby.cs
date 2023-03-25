using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Baby : Distraction {
    
    public static MonoBehaviour _instance = null;
    private bool isRed = false;
    public int distractionTime;
    
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

    private void OnMouseDown() {
        if(isRed){
            GetComponent<SpriteRenderer>().color = Color.green;
            isRed = false;
        }   
    }

    private IEnumerator Wait(float seconds) {
        yield return new WaitForSeconds(seconds);
        if(isRed){
            GetComponent<SpriteRenderer>().color = Color.green;
            ((TyperController)TyperController.Instance()).wordError();
            isRed = false;
        }
    }


    // Update is called once per frame
    void Update() {
        if ((int) Math.Round(((DistractionController)DistractionController.Instance()).timer)%distractionTime == 0) {
            GetComponent<SpriteRenderer>().color = Color.red;
            isRed = true; 
            StartCoroutine(Wait(3));
        }


    }
}
