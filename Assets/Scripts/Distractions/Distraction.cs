using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Distraction : MonoBehaviour {
    
    protected int[] times;
    protected int[] levels = null;
    protected bool isActivated = false;
    protected int reactionTime;
    protected Vector3[] positions;  

    protected IEnumerator Wait(float seconds) {
        yield return new WaitForSeconds(seconds);
        if (isActivated) {
            GetComponent<SpriteRenderer>().enabled = false;
            TyperController.instance.wordError();
            isActivated = false;
        }
    }
    
    protected bool mustActivate() {
        int i = 0;
        bool activate = false;
        
        while (!isActivated && i < times.Length && !activate) {
            activate = ((int) Math.Round(DistractionController.instance.timer) == times[i]);
            i++;
        }
        
        return activate;
    }

    protected void spawnAtRandomPosition() {
        int rndm = Random.Range(0, positions.Length);
        GetComponent<Transform>().position = positions[rndm];
    }
    
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    protected void Update() {
        if (mustActivate() && TyperController.instance.getTimer() > 0) {
            isActivated = true;
            spawnAtRandomPosition();
            GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(Wait(reactionTime));
        }
    }
}
