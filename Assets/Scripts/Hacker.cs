using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Hello Frank");
    }
    void ShowMainMenu(string greeting)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        //Imprimo en la terminal (accedo a la clase terminal)
        Terminal.WriteLine("¿Qué te gustaría Hackear?");
        Terminal.WriteLine("Presioná 1 para la Biblioteca (Fácil)");
        Terminal.WriteLine("Presioná 2 para la Policía (Medio)");
        Terminal.WriteLine("Presioná 3 para la NASA (Difícil)");
        Terminal.WriteLine("Ingresá tu selección:");

    }
    void OnUserInput (string input)  //Using the message method "OnuserInput"
    {
        print(input);
    }

}
