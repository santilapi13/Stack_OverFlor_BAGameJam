using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMaker : MonoBehaviour {
    
    private bool isEmpty = true;
    
    // Singleton instance.
    public static CoffeeMaker instance = null;
	
    // Initialize the singleton instance.
    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    
    private void OnMouseDown() {
        if (isEmpty) {
            
            isEmpty = false;
        }   
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
