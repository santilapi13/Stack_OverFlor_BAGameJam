using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionController : MonoBehaviour {
    
    public static MonoBehaviour _instance = null;
    public float timer = 60;
    private ArrayList distractions = new ArrayList();
    
    public static MonoBehaviour Instance() {
        if (_instance == null) {
            _instance = GameObject.FindObjectOfType<DistractionController>();
        }
        return _instance;
    }
    
    // Start is called before the first frame update
    void Start() {
        /*
        distractions.Clear();
        switch (((GameController) GameController.Instance()).getChapter()) {
            case 0: {   // Tutorial
                distractions.Add(((Baby) Baby.Instance()));
            }
        } */
    }

    // Update is called once per frame
    void Update() {
        timer -= Time.deltaTime;
    }
}
