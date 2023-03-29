using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TyperController : MonoBehaviour {
    
    public Text wordOutput = null;
    public Text nextWordOutput = null;
    public Image timerOutput = null;
    private string remainingWord = string.Empty;
    private string[] nextWord = {"hello world", "if (x > 0)", "print(total)", "while (true)", "return 0;", "void function()"};
    private string comingWord = string.Empty;
    private string writedWord = string.Empty;
    private bool errorInTheWord = false;
    private int wordStrak = 0;
    private int letterindex = 0;
    private float timer = 60;
    private Color colorDestino = Color.green;

    // Singleton instance.
    public static TyperController instance = null;
	
    // Initialize the singleton instance.
    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad (gameObject);
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
        timerOutput.fillAmount = 1 - (timer / 60);
    }
    
    private void setNextWord() {
       if(comingWord == string.Empty)
           setComingWord(nextWord[Random.Range(0, nextWord.Length)]);
       setRemainingWords(comingWord);
       setComingWord(nextWord[Random.Range(0, nextWord.Length)]);
    }

    private void setComingWord(string newString) {
        comingWord = newString;
        nextWordOutput.text = comingWord;
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
        wordOutput.color = Color.grey;
    }
    
    public void wordError() {
        wordStrak = 0;
        letterindex = 0;
        wordOutput.text = remainingWord;
        StartCoroutine(errorTick());
        if (!errorInTheWord){
            removeTime(5);
            GameController.instance.setComboMultiplier(1);
            errorInTheWord = true;
        }else
            removeTime(1);
    }

    /**
     * It checks if the letter is correct and if it is, it removes it from the word.
     * @param letter: The letter to check.
     */
    private void enterLetter(string letter) {
        if (remainingWord[letterindex] == letter[0]) {
            removeLetter();
            if (remainingWord.Length == letterindex) {
                GameController.instance.addMoney(this.remainingWord);
                setNextWord();
                errorInTheWord = false;
                wordStrak++;
                letterindex = 0;
                if(wordStrak % 3 == 0)
                    GameController.instance.setComboMultiplier(GameController.instance.getComboMultiplier() + 1);
            }
        } else
            wordError();
    }

    /**
     * It removes the next letter of the word.
     */
    private void removeLetter() {
        wordOutput.text = remainingWord;
        string textoVerde = wordOutput.text.Substring(0, letterindex + 1);
        string textoPoste = wordOutput.text.Substring(letterindex + 1);
        wordOutput.text = "<color=#" + UnityEngine.ColorUtility.ToHtmlStringRGB(colorDestino) + ">" + textoVerde +
                          "</color>" + textoPoste;
        letterindex++;
    }

    // Start is called before the first frame update
    void Start() {
        setNextWord();
        updateTimer();
    }

    void changeLleterColor() {
        
    }

    // Update is called once per frame
    void Update() {
        if (timer > 0) {
            this.removeTime(Time.deltaTime);
            checkInput();
        } else {
            nextWordOutput.text = "";
            wordOutput.color = Color.red;
            wordOutput.text = "Game Over";
        }
    }
    
}
