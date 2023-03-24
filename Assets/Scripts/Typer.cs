using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    public Text wordOutput = null;
    private string remainingWord = string.Empty;
    private string[] nextWord = {"hello world", "if else", "example code", "generic code", "crustaceo", "test"};
    private string currentWord = string.Empty;
    // Start is called before the first frame update
    void Start()
    {
        setNextWord();
    }

       // Update is called once per frame
    void Update()
    {
        checkImput();
    }

    private void setNextWord()
    {
       setRemainWord(nextWord[Random.Range(0, nextWord.Length)]);
       setCurrenWord(remainingWord);
    }
    

    private void setCurrenWord(string newString)
    {
        currentWord = newString;
    }

    private void setRemainWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }

    private void checkImput()
    {
        if(Input.anyKeyDown)
        {
            string keyPressed = Input.inputString;
            if(keyPressed.Length == 1)
            {
               enterLetter(keyPressed); 
               if(isWordComplete())
               {
                   setNextWord();
               }
            }
        }
    }

    private void enterLetter(string letter)
    {
        if(isCorrectLetter(letter))
        {
            removeLetter();
            if(isWordComplete())
            {
                setNextWord();
                
            }
        }else{
            setRemainWord(currentWord);
        }
    }
    
    private bool isCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void removeLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        setRemainWord(newString);
    }

    private bool isWordComplete()
    {
        return remainingWord.Length == 0;
    }



}
