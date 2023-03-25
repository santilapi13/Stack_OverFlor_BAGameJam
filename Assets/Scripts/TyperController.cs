using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TyperController : MonoBehaviour {
    
    public static MonoBehaviour _instance = null;
    public Text wordOutput = null;
    public Text nextWordOutput = null;
    public Text timerOutput = null;
    private string remainingWord = string.Empty;
    private string[] nextWord = {"hello world", "if else", "example code", "generic code", "crustaceo", "test"};
    private string currentWord = string.Empty;
    private string comingWord = string.Empty;
    private bool errorInTheWord = false;
    private int wordStrak = 0;
    private float timer = 60;

    public static MonoBehaviour Instance() {
        if (_instance == null) {
            _instance = GameObject.FindObjectOfType<TyperController>();
        }
        return _instance;
    }
    
    public float getTimer() {
        return timer;
    }
    
    public void removeTime(float time) {
        if (timer - time > 0)
            timer -= time;
        else
            timer = 0;
        updateTimer();
    }
    
    private void updateTimer() {
        timerOutput.text = "Tiempo: " + Mathf.Round(timer);
    }
    
    private void setNextWord() {
       if(comingWord == string.Empty)
           setComingWord(nextWord[Random.Range(0, nextWord.Length)]);
       setRemainingWords(comingWord);
       setComingWord(nextWord[Random.Range(0, nextWord.Length)]);
       setCurrentWord(remainingWord);
    }

    private void setComingWord(string newString) {
        comingWord = newString;
        nextWordOutput.text = comingWord;
    }
    

    
    
    private void setCurrentWord(string newString) {
        currentWord = newString;
    }

    /**
     * It sets the remaining word to the new string.
     * @param newString: The new string to set.
     */
    private void setRemainingWords(string newString) {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }

    /**
     * It checks if the user has pressed a key and if it is, it checks if only one key is pressed (in the same frame).
     * If only one is pressed, it calls the enterLetter method to check if the letter is correct.
     */
    private void checkInput() {
        if(Input.anyKeyDown) {
            string keyPressed = Input.inputString;
            if (keyPressed.Length == 1)
               enterLetter(keyPressed);
        }
    }

    private IEnumerator errorTick() {
        wordOutput.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        wordOutput.color = Color.white;
    }
    
    public void wordError() {
        wordStrak = 0;
        StartCoroutine(errorTick());
        setRemainingWords(currentWord);
        if (!errorInTheWord){
            removeTime(5);
            ((GameController)GameController.Instance()).setComboMultiplier(1);
            errorInTheWord = true;
        }else
            removeTime(1);
    }

    /**
     * It checks if the letter is correct and if it is, it removes it from the word.
     * @param letter: The letter to check.
     */
    private void enterLetter(string letter) {
        if (isCorrectLetter(letter)) {
            removeLetter();
            if (isWordComplete()) {
                ((GameController)GameController.Instance()).addMoney(this.currentWord);
                setNextWord();
                errorInTheWord = false;
                wordStrak++;
                if(wordStrak % 3 == 0)
                    ((GameController)GameController.Instance()).setComboMultiplier(((GameController)GameController.Instance()).getComboMultiplier() + 1);
            }
        } else
            wordError();
    }
    
    /**
     * It checks if the letter is the next letter of the word.
     * @param letter: The letter to check.
     * @return True if the letter is the next letter of the word, false otherwise.
     */
    private bool isCorrectLetter(string letter) {
        return remainingWord.IndexOf(letter) == 0;
    }

    /**
     * It removes the next letter of the word.
     */
    private void removeLetter() {
        string newString = remainingWord.Remove(0, 1);
        setRemainingWords(newString);
    }

    /**
     * It checks if the word was fully typed.
     * @return True if the word was fully typed, false otherwise.
     */
    private bool isWordComplete() {
        return remainingWord.Length == 0;
    }
    
    
    // Start is called before the first frame update
    void Start() {
        setNextWord();
        updateTimer();
    }

    // Update is called once per frame
    void Update() {
        if (timer > 0) {
            this.removeTime(Time.deltaTime);
            checkInput();
        } else {
            wordOutput.color = Color.red;
            wordOutput.text = "Game Over";
        }
    }
    
}
