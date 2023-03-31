using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{

        // Singleton instance.
    public static CoffeeMachine instance = null;
    private bool coffee = false;
    public Sprite[] sprites;
    public SpriteRenderer cup;
    public SpriteRenderer coffeeDrop;
      public SpriteRenderer coffeeDrop2;
	
    // Initialize the singleton instance.
    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void OnMouseDown(){
        if (Sleep.instance.getisActivated() && (!coffee))
            StartCoroutine(makeCoffee());
        else if(coffee){
            Sleep.instance.animationEnd();
            cup.sprite = sprites[0];
            coffee = false;
        }
    
    }
    
    private IEnumerator makeCoffee(){
        coffeeDrop.enabled = true;
        coffeeDrop2.enabled = true;
        yield return new WaitForSeconds(3f);
        coffeeDrop.enabled = false;
        coffeeDrop2.enabled = false;
        cup.sprite = sprites[1];
        coffee = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        coffeeDrop.enabled = false;
        coffeeDrop2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
