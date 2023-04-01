using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{

        // Singleton instance.
    public static CoffeeMachine instance = null;
    private bool coffee = false;
    private bool maikingCoffee = false;
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
        if ((!coffee) && (!maikingCoffee))
            StartCoroutine(makeCoffee());
        else if(Sleep.instance.getisActivated() && coffee){
            FXController.instance.PlayDistractionEffect(FXController.DistractionEffect.DrinkCoffee);
            Sleep.instance.animationEnd();
            TyperController.instance.addTime(7);
            cup.sprite = sprites[0];
            coffee = false;
        }
    }
    
    private IEnumerator makeCoffee(){
        FXController.instance.PlayDistractionEffect(FXController.DistractionEffect.MachineSound);
        FXController.instance.PlayDistractionEffect(FXController.DistractionEffect.PourCoffee);
        maikingCoffee = true;
        coffeeDrop.enabled = true;
        coffeeDrop2.enabled = true;
        yield return new WaitForSeconds(3f);
        maikingCoffee = false;
        coffeeDrop.enabled = false;
        coffeeDrop2.enabled = false;
        cup.sprite = sprites[1];
        coffee = true;
    }


    // Start is called before the first frame update
    void Start() {
        coffeeDrop.enabled = false;
        coffeeDrop2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TyperController.instance.getTimer() == 0){
            coffeeDrop.enabled = false;
            coffeeDrop2.enabled = false;
            cup.sprite = sprites[0];
            coffee = false;
        }

    }
}
