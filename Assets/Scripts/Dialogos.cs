using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogos : MonoBehaviour {

    public GameObject[] Mensaje;
    private int indiceMensaje = 0; 
    
    void Awake() {
        for (int i = 0; i < 3; i++)
            Mensaje[i].SetActive(false);
    }

    void Start() {
        //StartCoroutine(startDialogue());
    }

    private void Update() {
        if (indiceMensaje < Mensaje.Length && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))) {
            Mensaje[indiceMensaje].SetActive(true);
            indiceMensaje++;
        } else if (indiceMensaje == Mensaje.Length && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))) {
            CinematicsControllers.instance.nextBackground();
        }
    }
}
