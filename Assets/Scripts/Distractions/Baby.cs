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
    }

    private Baby() {
        this.times = new int[] { 55, 32, 21, 15, 3 };
        this.levels = new int[] { 0 };
        this.reactionTime = 3;
        this.positions = new Vector3[] { new Vector3(4, -2, -4), new Vector3(3, -1, -4), new Vector3(4, 0, -4) };
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
        animator = GetComponent<Animator>();
        animator.SetBool("IsActive", false);
    }

    void Update() {
        base.Update();
        animator.SetBool("IsActive", isActivated);
    }
    
}
