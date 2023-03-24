using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class TypeGameController : MonoBehaviour  {
    
    // TODO: Ajustar para Unity
    
    private  string[] words = { "perro", "gato", "árbol", "computadora", "teléfono", "pelota", "pantalla", "agua", "sol", "libro" };
    // Variables para llevar la cuenta del puntaje y el tiempo
    private int puntaje;
    private DateTime inicio = DateTime.Now;

    // Start is called before the first frame update
    void Start() {
        this.puntaje = 0;
    }

    // Update is called once per frame
    void Update() {
        Random random = new Random();
        string actualWord = words[random.Next(words.Length)];
        
        // Mostrar la palabra y pedir al jugador que la escriba
        Console.WriteLine("Escribe la siguiente palabra: " + actualWord);
        string entrada = Console.ReadLine();

        // Verificar si la entrada es correcta y actualizar el puntaje
        if (entrada == actualWord) {
            puntaje++;
            Console.WriteLine("¡Correcto! Tu puntaje es " + puntaje);
        } else
            Console.WriteLine("Incorrecto. Tu puntaje es " + puntaje);

        // Verificar si ha pasado el tiempo límite del juego
        TimeSpan duracion = DateTime.Now - inicio;
        if (duracion.TotalSeconds >= 60) {
            Console.WriteLine("¡Tiempo terminado! Tu puntaje final es " + puntaje);
        }
        
        // Esperar a que el jugador presione Enter para salir
        Console.WriteLine("Presiona Enter para salir.");
        Console.ReadLine();
    }
}
