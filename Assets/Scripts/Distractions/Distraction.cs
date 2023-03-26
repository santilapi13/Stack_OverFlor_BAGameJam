using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Distraction : MonoBehaviour {
    
    protected int[] times;
    protected int[] levels = null;
    protected bool isActivated = false;
    protected int reactionTime;

    protected IEnumerator Wait(float seconds) {
        yield return new WaitForSeconds(seconds);
        if (isActivated) {
            GetComponent<SpriteRenderer>().color = Color.green;
            TyperController.instance.wordError();
            isActivated = false;
        }
    }
    
    protected bool mustActivate() {
        int i = 0;
        bool activate = false;
        
        while (!isActivated && i < times.Length && !activate) {
            activate = ((int) Math.Round(((DistractionController)DistractionController.Instance()).timer) == times[i]);
            i++;
        }
        
        return activate;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update() {
        if (mustActivate() && TyperController.instance.getTimer() > 0) {
            GetComponent<SpriteRenderer>().color = Color.red;
            isActivated = true;
            StartCoroutine(Wait(reactionTime));
        }
    }
}
