using System.Configuration.Assemblies;

namespace ATM;

static class ATM
{
    private static string cardnumber = "";
    /// <summary>
    /// the main menu of the ATM
    /// </summary>
    public static void Menu()
    {
        Console.WriteLine("\tWelcome to the my system!");
        Console.WriteLine("\t1-Start");
        Console.WriteLine("\t0-Exit");
        bool success = int.TryParse(Console.ReadLine(), out int choice);
        if (success == false)
        {
            System.Console.WriteLine("Please write Numbers!");
            Menu();
        }
        else
        {
            switch (choice)
            {
                case 1:
                    StartMenu();
                    break;
                case 0:
                    ExitMenu();
                    break;
                default:
                    System.Console.WriteLine("\tPlease choose from menu!");
                    Menu();
                    break;

            }
        }
    }
    /// <summary>
    /// if user want to start the ATM
    /// </summary>
    public static void StartMenu()
    {
        System.Console.Write("\tEnter Your Card Number: ");
        string cardNO = Console.ReadLine();
        System.Console.Write("\tEnter Your Password: ");
        string password = Console.ReadLine();
        if (string.IsNullOrEmpty(cardNO) || string.IsNullOrEmpty(password))
        {
            Console.WriteLine("\tPlease do not leave fields empty!\nTry again!");
            StartMenu();
        }
        User user = new(cardNO, password);
        if (!user.checkCardnumberAndPassword())
        {
            Console.WriteLine("\tUser not exists or Password wrong");
            Menu();
        }
        cardnumber = cardNO;
        UserMenu();
    }
    /// <summary>
    /// if user want to exit the ATM
    /// </summary>
    public static void ExitMenu()
    {
        System.Console.WriteLine("\tHave a Good Time");
    }
    /// <summary>
    /// after correct card and password head to the user menu
    /// </summary>
    public static void UserMenu()
    {
        System.Console.WriteLine("1-Cash withdrawa");
        System.Console.WriteLine("2-Deposit");
        System.Console.WriteLine("3-Balance");
        System.Console.WriteLine("4-Card To card");
        bool success = int.TryParse(Console.ReadLine(), out int choice);
        if (success == false)
        {
            System.Console.WriteLine("Please write Numbers!");
            UserMenu();
        }
        else
        {
            switch (choice)
            {
                case 1:
                    CashWithDraw();//برداشت
                    break;
                case 2:
                    Deposit();//واریز
                    break;
                case 3:
                    ViewBalance();
                    break;
                case 4:
                    CardToCard();
                    break;
                case 0:
                    ExitMenu();
                    break;
                default:
                    System.Console.WriteLine("\tPlease choose from menu!");
                    UserMenu();
                    break;

            }
        }
    }
    /// <summary>
    /// menu that handles card to card for user
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private static void CardToCard()
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// menu that handles view the balance for user
    /// </summary>
    private static void ViewBalance()
    {
        User user = new(cardnumber);
        float balance = user.getBalance();
        System.Console.WriteLine("Your Balance is : {0}", balance);
        System.Console.WriteLine("What do you want to do next : ");
        System.Console.WriteLine("1- Return to the menu");
        System.Console.WriteLine("0- Exit");
        bool success = int.TryParse(Console.ReadLine(), out int choice);
        if (success == false)
        {
            System.Console.WriteLine("Please write Numbers!");
            UserMenu();
        }
        else
        {
            switch (choice)
            {
                case 1:
                    UserMenu();
                    break;
                case 0:
                    ExitMenu();
                    break;
                default:
                    System.Console.WriteLine("\tPlease choose from menu!");
                    UserMenu();
                    break;

            }
        }
        // throw new NotImplementedException();
    }

    /// <summary>
    /// menu that handles deposite to the card for user
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private static void Deposit()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// menu that handles draw cash for user
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private static void CashWithDraw()
    {
        throw new NotImplementedException();
    }
}