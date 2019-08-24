using UnityEngine;

public class Hacker : MonoBehaviour
{

    //Game Configuration Data:
    const string menuHint = "You may type menu at any time";
    string[] level1Passwords = {"books", "aisle", "shelf", "silence", "borrow" };
    string[] level2Passwords = { "jail", "burglar", "lawyer", "jurisprudence", "handcuffs", "holster" };
    string[] level3Passwords = { "astronauts", "telescope","planet" };

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
    void AskForPassword()
    {

        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password:" + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
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
            case 3:
                int index3 = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index3];
                break;
            default:
                Debug.LogError("Invalid Input");
                break;

        }
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
        bool isValidLevelNumber = (input =="1"||input=="2"|| input=="3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "Iron Man" || input == "iron man")
        {
            Terminal.WriteLine("Hi Mr. Stark, what are we hacking today?");
        }
        
        else
        {

            Terminal.WriteLine("Invalid input! Please select a valid option");
            Terminal.WriteLine(menuHint);

        }
    }

    void CheckPassword(string input)
    {
        if (input==password)
        {
            DisplayWinScreen();
        }
        else
        {
           AskForPassword();
            
        }
        
    }
    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }
    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a Book...");
                Terminal.WriteLine(@"
    _________
   /        //
  /        //
 /________//
(________(/
");
                ;
                break;
            case 2:
                Terminal.WriteLine("You have released the prisoners!! Here´s the key:");
                Terminal.WriteLine(@"
  __
 /0 \_______
 \__/-='-='-/
");
                break;
            case 3:
                Terminal.WriteLine(@"
  _ __   __ _ ___  __ _ 
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___/\__,_|
");

                 Terminal.WriteLine("Welcome to the NASA system");
                break;
            default:
                Debug.LogError("Invalid level");
                break;
        }
    }

}
