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

    void Level01()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Public Library selected.");
        Terminal.WriteLine("Proceed to write the correct answer");
        
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
            Level01();
        }
        else
        {

            Terminal.WriteLine("Invalid input! Please select a valid option");

        }
    }

}
