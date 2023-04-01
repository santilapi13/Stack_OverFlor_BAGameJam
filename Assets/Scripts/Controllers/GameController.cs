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
    public int wordMultiplier;
    private int comboMultiplier = 1;
    public int moneyToPassLevel = 3;
    public int level;
    
      // Singleton instance.
    public static GameController instance = null;
	
    // Initialize the singleton instance.
    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    public int getComboMultiplier() {
        return comboMultiplier;
    }

    public void setComboMultiplier(int comboMultiplier) {
        this.comboMultiplier = comboMultiplier;
        updateCombo();
    }

    public void updateCombo() {
        comboOutput.text = "x" + comboMultiplier;
    }

    public int getLevel() {
        return level;
    }

    public void nextLevel() {
        this.level++;
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
        if (money - (newMoney * wordMultiplier) < 0) {
            money = 0;
        } else {
            money -= (newMoney * wordMultiplier);
        }
        updateMoney();
    }

    private void updateMoney() {
        if(money < 1000)
            moneyOutput.text = "$$ " + money + "/" + moneyToPassLevel;
        else
            moneyOutput.text = "$$ " + money/1000 + "." + (money%1000)/100 + "k" + "/" + moneyToPassLevel;   

    }

    public bool canPassLevel() {
        return money >= moneyToPassLevel;
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
