using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogos : MonoBehaviour {

    public GameObject[] Mensaje;
    private int indiceMensaje = 0;
    public GameObject loadingImage;
    private bool blockedByWriting = false;
    
    void Awake() {
        for (int i = 0; i < Mensaje.Length; i++)
            Mensaje[i].SetActive(false);
        this.loadingImage.GetComponent<SpriteRenderer>().enabled = false;
    }

    private IEnumerator writeMessages(float time) {
        this.loadingImage.GetComponent<SpriteRenderer>().enabled = true;
        blockedByWriting = true;
        yield return new WaitForSeconds(time);
        FXController.instance.PlayMiscEffect(FXController.MiscEffect.Message);
        this.loadingImage.GetComponent<SpriteRenderer>().enabled = false;
        Mensaje[indiceMensaje].SetActive(true);
        indiceMensaje++;
        blockedByWriting = false;
    }

    void Start() {
    }

    private void Update() {
        if (!blockedByWriting) {
            if (indiceMensaje < Mensaje.Length && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))) {
                StartCoroutine(writeMessages(1.5f));
            }
            else if (indiceMensaje == Mensaje.Length && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))) {
                CinematicsControllers.instance.nextBackground();
            }
        }
    }
}
