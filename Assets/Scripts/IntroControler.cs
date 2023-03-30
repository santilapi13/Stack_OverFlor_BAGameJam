using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroControler : MonoBehaviour
{
    public Text wordOutput = null;
    public IntroControler instance = null;
    private string remainingWord = "Jugar";
    private int letterindex = 0;
    private Color colorDestino = Color.green;
    // Start is called before the first frame update
    
    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void checkInput() {
        if(Input.anyKeyDown) {
            string keyPressed = Input.inputString;
            if (keyPressed.Length == 1)
               enterLetter(keyPressed);
        }
    }    

    private void enterLetter(string letter) {
        if ( char.ToLower(remainingWord[letterindex]) == char.ToLower(letter[0])) {
            removeLetter();
            if (remainingWord.Length == letterindex) {
               SceneManager.LoadScene("SampleTextScene");
            }
        } 
    }

    private void removeLetter() {
        wordOutput.text = remainingWord;
        string textoVerde = wordOutput.text.Substring(0, letterindex + 1);
        string textoPoste = wordOutput.text.Substring(letterindex + 1);
        wordOutput.text = "<color=#" + UnityEngine.ColorUtility.ToHtmlStringRGB(colorDestino) + ">" + textoVerde + "</color>" + textoPoste;
        letterindex++;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       checkInput(); 
    }
}
