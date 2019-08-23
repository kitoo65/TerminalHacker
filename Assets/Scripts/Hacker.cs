using UnityEngine;

public class Hacker : MonoBehaviour
{

    //Game Configuration Data:
    string[] level1Passwords = {"books", "aisle", "shelf", "silence", "borrow" };
    string[] level2Passwords = { "jail", "burglar", "lawyer", "jurisprudence", "handcuffs", "holster" };

    //Game State: El level, la screen en donde tamo y la password
    int level;
    enum Screen {MainMenu, Password, Win}
    Screen currentScreen;
    string password;

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
    void StartGame()
    {
        
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index1];
                break;
            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index2];
                break;
            default:
                Debug.LogError("Invalid Input");
                break;

        }
        Terminal.WriteLine("Please enter your password:");
    }
   
    void OnUserInput (string input)  //Using the message method "OnUserInput"
    {
        if (input == "menu")
        {
            ShowMainMenu();
            Terminal.WriteLine("Now you are in the main menu ");
            
        }
        else if (currentScreen==Screen.MainMenu)
        {
            RunGameMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }


    }
    void RunGameMenu(string input)
    {
        bool isValidLevelNumber = (input =="1"||input=="2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "Iron Man" || input == "iron man")
        {
            Terminal.WriteLine("Hi Mr. Stark, what are we hacking today?");
        }
        
        else
        {

            Terminal.WriteLine("Invalid input! Please select a valid option");

        }
    }

    void CheckPassword(string input)
    {
        if (input==password)
        {
            Terminal.WriteLine("WELL DONE!");
        }
        else
        {
            Terminal.WriteLine("Please try again");
            
        }
        
    }

}
