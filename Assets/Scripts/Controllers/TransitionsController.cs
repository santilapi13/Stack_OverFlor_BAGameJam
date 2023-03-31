using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionsController : MonoBehaviour
{
    static public TransitionsController instance;
    public Animator animator;
    
    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void changeScene(string sceneName) {
        StartCoroutine(loadScene(sceneName));
    }

    private IEnumerator loadScene(string sceneName) {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }


}
