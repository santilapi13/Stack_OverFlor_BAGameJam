using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : Distraction
{
    // Singleton instance.
    public static Sleep instance = null;
    public Animator animation1;
    public Animator animation2;
    private bool playng = false;

	
    // Initialize the singleton instance.
    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    protected IEnumerator Wait(float seconds) {
        yield return new WaitForSeconds(seconds);
    }

    private Sleep() {
        this.levels = new int[] { 0 };
        this.positions = new Vector3[] {new Vector3(0, 0, 0)};
        this.reactionTime = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void animationEnd(){
        animation1.SetBool("Sueño", false);
        animation2.SetBool("Sueño", false);
        playng = false;
        isActivated = false;
    }

    public bool getisActivated(){
        return isActivated;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustActivate() && TyperController.instance.getTimer() > 0  && !playng) {
            isActivated = true;
            animation1.SetBool("Sueño", true);
            animation2.SetBool("Sueño", true);
            StartCoroutine(Wait(1.5f));
            playng = true;
        } else if (TyperController.instance.getTimer() == 0) {
            isActivated = false;
        }
    }
}
