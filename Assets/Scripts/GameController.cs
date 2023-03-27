using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
   
    public Text moneyOutput = null;
    public Text comboOutput = null;
    private int money = 0;
    private int wordMultiplier = 200;
    private int comboMultiplier = 1;
    
    private int level = 0;
      // Singleton instance.
    public static GameController instance = null;
	
    // Initialize the singleton instance.
    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad (gameObject);
    }
    public int getComboMultiplier() {
        return comboMultiplier;
    }

    public void setComboMultiplier(int comboMultiplier) {
        this.comboMultiplier = comboMultiplier;
        updateCombo();
    }

    public void updateCombo() {
        comboOutput.text = "X" + comboMultiplier;
    }

    public int getLevel() {
        return level;
    }

    public int getMoney() {
        return money;
    }

    public void addMoney(int newMoney) {
        money += newMoney;
        updateMoney();
    }

    public void addMoney(string word) {
        money += word.Length * this.wordMultiplier * comboMultiplier;
        updateMoney();
    }
    
    public void removeMoney(int newMoney) {
        money -= newMoney;
        updateMoney();
    }

    private void updateMoney() {
        if(money < 1000)
            moneyOutput.text = "$$ " + money;
        else
            moneyOutput.text = "$$ " + money/1000 + "." + (money%1000)/100 + "k";   

    }


    // Start is called before the first frame update
    void Start(){
        
        updateMoney();
        updateCombo();
    }

    // Update is called once per frame
    void Update() {

    }
}
