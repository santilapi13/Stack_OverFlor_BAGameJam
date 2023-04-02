using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TyperController : MonoBehaviour {
    
    public Text wordOutput = null;
    public Text nextWordOutput = null;
    public Image timerOutput = null;
    public GameObject message = null;
    public Image introText = null;
    
    private string remainingWord = string.Empty;
    private static string[] nextWord = {"if(true)","else","variable=0","var=2","palabra","mostrar(lista)","error","mostrar(arbol)","declaracion","include","integer","character","real","boolean","while","hacer","for","repeat","until","break","default","funcion","function","static","return","objeto","clase","void","public","protected","nuevo","importar","package","main","seguir;","continuar;","detener;","crustaceo","align","sumar(a,b)","restar(a,c)","01101111","color.verde","color.azul","desapilar","jugar","error404","stack","overflow","validacion","1+1","asignacion"}; 
    private List <string> words = new List<string>(nextWord);
    private string comingWord = string.Empty;
    private bool errorInTheWord = false;
    private int wordStreak = 0;
    private int letterindex = 0;
    private float initialTime;
    public float timer;
    private Color colorDestino = Color.green;
    private bool pause = true;
    public float introTimer = 3;
    public string thisScene;
    static private bool firstTimeLose = true;
    private bool extraLife = false;

    // Singleton instance.
    public static TyperController instance = null;
	
    // Initialize the singleton instance.
    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    
    public float getTimer() {
        return timer;
    }
    
    public bool isPause() {
        return pause;
    }
    
    public float getIntroTimer() {
        return introTimer;
    }

    public float removeTime(float time, float aux) {
        if (aux - time > 0)
            aux -= time;
        else
            aux = 0;
        updateTimer();
        return aux;
    }

    public void addTime(float time) {
        timer += time;
        updateTimer();
    }
    
    private void updateTimer() {
        timerOutput.fillAmount = (timer / initialTime);
    }
    
    private void setNextWord() {
       if(comingWord == string.Empty)
           setComingWord(getWord());
       setRemainingWords(comingWord);
       setComingWord(getWord());
    }

    private string getWord() {
        int rndm = Random.Range(0, words.Count);
        string word = words[rndm];
        words.RemoveAt(rndm);
        if(words.Count == 0)
            words = new List<string>(nextWord);
        return word;
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
        FXController.instance.PlayTypingEffect(FXController.TypingEffect.Error);
        wordStreak = 0;
        letterindex = 0;
        wordOutput.text = remainingWord;
        StartCoroutine(errorTick());
        if (!errorInTheWord){
            timer = removeTime(5, timer);
            GameController.instance.setComboMultiplier(1);
            errorInTheWord = true;
        }else
            timer = removeTime(1, timer);
    }

    /**
     * It checks if the letter is correct and if it is, it removes it from the word.
     * @param letter: The letter to check.
     */
    private void enterLetter(string letter) {
        if (char.ToLower(remainingWord[letterindex]) == char.ToLower(letter[0])) {
            removeLetter();
            if (remainingWord.Length == letterindex) {
                FXController.instance.PlayTypingEffect(FXController.TypingEffect.Success);
                GameController.instance.addMoney(this.remainingWord);
                setNextWord();
                errorInTheWord = false;
                wordStreak++;
                letterindex = 0;
                if (wordStreak % 3 == 0 && GameController.instance.getComboMultiplier() < 5)
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

    private void levelFinished() {
        this.pause = true;
        FXController.instance.effectSource.Stop();
        updateTimer();
        FXController.instance.PlayMiscEffect(FXController.MiscEffect.Message);
        if((GameController.instance.canPassLevel())){
             message.GetComponent<SpriteRenderer>().enabled = true;
            nextWordOutput.color = Color.green;
            nextWordOutput.text = "Nivel finalizado";
            wordOutput.color = Color.green;
            wordOutput.fontSize = 30;
            wordOutput.text = "¡Nuevo mensaje!";
        }else if(firstTimeLose){
            message.GetComponent<SpriteRenderer>().enabled = true;
            nextWordOutput.color = Color.red;
            nextWordOutput.text = "Nivel Fallido";
            wordOutput.color = Color.green;
            wordOutput.fontSize = 30;
            wordOutput.text = "¿Nuevo mensaje?";
        }else{
            nextWordOutput.color = Color.red;
            nextWordOutput.text = "Nivel Fallido";
            wordOutput.color = Color.red;
            wordOutput.fontSize = 30;
            wordOutput.text = "Reintentar?";
        }
       
    }

    private void initialCountdown() {
        introTimer = this.removeTime(Time.deltaTime, introTimer);
        if (introTimer < 4f && introTimer > 3.2f) {
            introText.GetComponent<CanvasGroup>().alpha = 0;
        } else if (introTimer <= 0) {
            pause = false;
            setNextWord();
            updateTimer();
        } else {
            wordOutput.text = Math.Round(introTimer).ToString();
        }
    }

    // Start is called before the first frame update
    void Start() {
        message.GetComponent<SpriteRenderer>().enabled = false;
        this.initialTime = timer;
    }

    // Update is called once per frame
    void Update() {
        if (!pause)
            if (timer > 0) {
                timer = this.removeTime(Time.deltaTime, timer);
                checkInput();
            } else
                this.levelFinished();
        else if (Input.anyKeyDown && timer < 60 && timer > 0)
            pause = false;
        else if (timer >= 60)
            this.initialCountdown();
        else if(timer <= 0 && !(GameController.instance.canPassLevel()) && !firstTimeLose) {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) {
                TransitionsController.instance.changeScene(thisScene);
            }
        }else if( firstTimeLose  && timer <= 0 && !(GameController.instance.canPassLevel())) {
                //aca el cambio de escena al mensaje de nustra familia
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) {
                    firstTimeLose = false;
                    CinematicsControllers.instance.nextBackgroundToLose();
                }
        }else if (timer <= 0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)))
            CinematicsControllers.instance.nextBackground();
    }
    
}