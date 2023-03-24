using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour {
    
    public Text wordOutput = null;
    private string remainingWord = string.Empty;
    private string[] nextWord = {"hello world", "if else", "example code", "generic code", "crustaceo", "test"};
    private string currentWord = string.Empty;
    
    // Start is called before the first frame update
    void Start() {
        setNextWord();
    }

       // Update is called once per frame
    void Update() {
        checkInput();
    }

    private void setNextWord() {
       setRemainWord(nextWord[Random.Range(0, nextWord.Length)]);
       setCurrenWord(remainingWord);
    }
    
    
    private void setCurrenWord(string newString) {
        currentWord = newString;
    }

    /**
     * It sets the remaining word to the new string.
     * @param newString: The new string to set.
     */
    private void setRemainWord(string newString) {
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

    /**
     * It checks if the letter is correct and if it is, it removes it from the word.
     * @param letter: The letter to check.
     */
    private void enterLetter(string letter) {
        if(isCorrectLetter(letter)) {
            removeLetter();
            if (isWordComplete()) {
                ((GameController) GameController.Instance()).addMoney(this.currentWord);
                setNextWord();
            }
        } else
            setRemainWord(currentWord);
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
        setRemainWord(newString);
    }

    /**
     * It checks if the word was fully typed.
     * @return True if the word was fully typed, false otherwise.
     */
    private bool isWordComplete() {
        return remainingWord.Length == 0;
    }



}
