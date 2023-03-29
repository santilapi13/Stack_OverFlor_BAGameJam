using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurredScreen : Distraction {
    
    
    
    // Singleton instance.
    public static BlurredScreen instance = null;
	
    // Initialize the singleton instance.
    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad (gameObject);
    }

    private BlurredScreen() {
        this.times = new int[] { 15, 40};
        this.levels = new int[] { 4, 5, 6 };
    }

    private void blurScreen() {
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (mustActivate() && TyperController.instance.getTimer() > 0) {
            isActivated = true;
            blurScreen();
        } else if (TyperController.instance.getTimer() == 0) {
            isActivated = false;
        }
    }
}
