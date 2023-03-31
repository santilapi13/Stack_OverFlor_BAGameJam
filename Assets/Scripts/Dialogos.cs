using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogos : MonoBehaviour {

    public GameObject[] Mensaje;
    private int indiceMensaje = 0;
    public Sprite[] loadingSprites;
    public GameObject loadingImage;
    
    void Awake() {
        for (int i = 0; i < Mensaje.Length; i++)
            Mensaje[i].SetActive(false);
        loadingImage.SetActive(false);
    }

    void Start() {
    }

    private void Update() {
        if (indiceMensaje < Mensaje.Length && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))) {
            Mensaje[indiceMensaje].SetActive(true);
            indiceMensaje++;
        } else if (indiceMensaje == Mensaje.Length && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))) {
            CinematicsControllers.instance.nextBackground();
        }
    }
}
