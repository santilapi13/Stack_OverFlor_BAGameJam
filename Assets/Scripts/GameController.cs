using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    
    public static MonoBehaviour _instance = null;
    public Text moneyOutput = null;
    private int money = 0;
    private int wordMultiplier = 2;

    public int getMoney() {
        return money;
    }
    
    public void addMoney(int newMoney) {
        money += newMoney;
        updateMoney();
    }

    public void addMoney(string word) {
        money += word.Length * this.wordMultiplier;
        updateMoney();
    }
    
    public void removeMoney(int newMoney) {
        money -= newMoney;
        updateMoney();
    }

    private void updateMoney() {
        moneyOutput.text = "Dinero: " + money;
    }
    
    public static MonoBehaviour Instance() {
        if (_instance == null) {
            _instance = GameObject.FindObjectOfType<GameController>();
        }
        return _instance;
    }

    // Start is called before the first frame update
    void Start(){
        updateMoney();
    }

    // Update is called once per frame
    void Update() {
        
    }
}
