using UnityEngine;

public class Hacker : MonoBehaviour
{

    //Game Configuration Data:
    const string menuHint = "Podés ir al menú escribiendo menú en cualquier momento";
    string[] level1Passwords = {"comunismo", "guerra fría", "Rusia", "Stalin"};
    string[] level2Passwords = { "astronauta", "Apolo", "Cabo Cañaveral", "andrómeda", "vía láctea", "Laika"};
    string[] level3Passwords = { "Las Vegas", "autopsia alien","arma laser", "nave espacial"};

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
        Terminal.WriteLine("¿Qué te gustaría Hackear?");
        Terminal.WriteLine("Presioná 1 para la URSS (F)");
        Terminal.WriteLine("Presioná 2 para la NASA (M)");
        Terminal.WriteLine("Presioná 3 para el ÁREA 51 (D)");
        Terminal.WriteLine("F - Fácil, M - Medio, D - Difícil ");
        Terminal.WriteLine("Elegí:");
        currentScreen = Screen.MainMenu;

    }
    void AskForPassword()
    {

        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Ingrese Contraseña:" + password.Anagram());
        
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
                Debug.LogError("Ingreso inválido");
                break;

        }
    }

    void OnUserInput (string input)  //Using the message method "OnUserInput"
    {
        if (input == "menu" || input == "Menu" || input == "Menú")
        {
            ShowMainMenu();
            Terminal.WriteLine("Ahora estás en el Menú principal");
            
        }
        else if (currentScreen==Screen.MainMenu)
        {
            RunGameMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {

            CheckPassword(input);
        }
        else if(currentScreen == Screen.Win)
        {
            switch (level)
            {
                case 1:
                    if (input == "Marte")
                    {
                        input = "2";
                        Terminal.WriteLine("Bienvenido a la NASA, porfavor ingrese la contraseña:");
                        RunGameMenu(input);
                        
                    }
                    break;
                case 2:
                    break;
            }
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
            Terminal.WriteLine("Hola señor Stark, ¿A dónde accedemos hoy?");
        }
        else if (input == "f")
        {
            Terminal.WriteLine("Los respetos han sido dados");
        }
        
        else
        {

            Terminal.WriteLine("Ingresá un número válido!");
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

                Terminal.WriteLine("Para hackear la NASA, respondé la siguiente pregunta");
                Terminal.WriteLine("¿Qué planeta se llama como un dios Romano?");
                Terminal.WriteLine(menuHint);
                break;
            case 2:
               
                Terminal.WriteLine("You have released the prisoners!! Here´s the key:");
                Terminal.WriteLine(@"
  __
 /0 \_______
 \__/-='-='-/
");
                Terminal.WriteLine("Para hackear el área 51, escribi Aliens y presioná enter");
                Terminal.WriteLine(menuHint);
                break;
            case 3:
                Terminal.WriteLine(@"
 _ __   __ _ ___  __ _ 
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___/\__,_|
");

                 Terminal.WriteLine("Welcome to the NASA system");
                Terminal.WriteLine(menuHint);
                break;
            default:
                Debug.LogError("Invalid level");
                break;
        }
    }

}
