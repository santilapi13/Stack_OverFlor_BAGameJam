using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogos : MonoBehaviour
{

    public GameObject[] Mensaje;
    private int indiceMensaje =0; 
    
    void Awake() 
    {
        for (int i = 0; i < 3; i++)
        {
        Mensaje[i].SetActive(false);
        }
    }
    
   void Start() 
    {
        //StartCoroutine(startDialogue());
    }

    private void Update() 
    {
        bool down = Input.GetKeyDown(KeyCode.Space);
        if(down)
        {
        show(indiceMensaje);
        Debug.Log(indiceMensaje);
        indiceMensaje++;
        }
    }

    public void show(int i)
    {
        Mensaje[i].SetActive(true);
        Debug.Log(i);
    }

    /*public IEnumerator startDialogue()
    {  
        for (int i = 0; i < 3; i++)
        {
            show(indiceMensaje);
            indiceMensaje++;  
            yield return new WaitForSeconds(5);
        }

    }
*/


}
