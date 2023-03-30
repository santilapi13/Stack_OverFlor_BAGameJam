using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionController : MonoBehaviour {
    
    public float timer = 60;
    private ArrayList distractions = new ArrayList();
    
    // Singleton instance.
        public static DistractionController instance = null;
    	
        // Initialize the singleton instance.
        private void Awake() {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
        }
    
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (!TyperController.instance.isPause())
            timer -= Time.deltaTime;
    }
}
