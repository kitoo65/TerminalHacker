﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game State
    int level;
    enum Screen {MainMenu, Password, Win}
    Screen currentScreen = Screen.MainMenu;
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
        currentScreen = Screen.MainMenu;

    }
   
    void OnUserInput (string input)  //Using the message method "OnUserInput"
    {
        if (input == "menu")
        {
            ShowMainMenu();
            Terminal.WriteLine("Now you are in the main menu ");
            level = 0;
        }
        else if (currentScreen==Screen.MainMenu)
        {
            RunGame(input);
        }

    }

    private void RunGame(string input)
    {
        if (input == "Iron Man" || input == "iron man")
        {
            Terminal.WriteLine("Hi Mr. Stark, what are we hacking today?");
        }
        else if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else
        {

            Terminal.WriteLine("Invalid input! Please select a valid option");

        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have Chosen level " + level);
    }
}
