using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }
    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        //Imprimo en la terminal (accedo a la clase terminal)
        Terminal.WriteLine("What would you like to hack?");
        Terminal.WriteLine("Press 1 for the public library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for the NASA");
        Terminal.WriteLine("Make your choice:");

    }
   
    void OnUserInput (string input)  //Using the message method "OnUserInput"
    {
        if (input == "menu")
        {
            ShowMainMenu();
            Terminal.WriteLine("Now you are in the main menu ");
        }
        else if (input == "Iron Man" || input =="iron man")
        {
            Terminal.WriteLine("Hi Mr. Stark, what are we hacking today?");
        }
        else if (input == "1")
        {
            StartGame(1);
        }
        else
        {

            Terminal.WriteLine("Invalid input! Please select a valid option");

        }
    }

     void StartGame(int level)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You have Chosen level " + level);
    }
}
