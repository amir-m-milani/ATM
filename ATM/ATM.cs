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
        Console.Clear();
        Console.WriteLine("\tWelcome to the my system!");
        Console.WriteLine("\t1-Start");
        Console.WriteLine("\t0-Exit");
        Console.Write("\tYour choice: ");
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
        Console.Clear();
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
        Environment.Exit(0);
    }
    /// <summary>
    /// after correct card and password head to the user menu
    /// </summary>
    public static void UserMenu()
    {
        Console.Clear();
        System.Console.WriteLine("1-Draw Cash");
        System.Console.WriteLine("2-Deposit");
        System.Console.WriteLine("3-Balance");
        System.Console.WriteLine("4-Card To card");
        System.Console.WriteLine("0-Exit");
        System.Console.Write("Your choice: ");
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
        User user = new(cardnumber);
        Console.Clear();
        System.Console.WriteLine("How much to want to Transfer? ");
        System.Console.Write("Dollars: ");
        bool success = float.TryParse(Console.ReadLine(), out float cash);
        if (success == false)
        {
            System.Console.WriteLine("Please write Numbers!");
            Deposit();
        }
        System.Console.Write("Write Destination Card: ");
        string destinationCardnumber = Console.ReadLine();
        if (string.IsNullOrEmpty(destinationCardnumber))
        {
            Console.WriteLine("\tPlease do not leave fields empty!\nTry again!");
            CardToCard();
        }
        switch (user.CardToCard(cash, destinationCardnumber))
        {
            case 0:
                System.Console.WriteLine("It was success");
                System.Console.WriteLine("Your new Balance is : {0}", user.getBalance());
                System.Console.WriteLine("What next ? ");
                System.Console.WriteLine("1- Another Work");
                System.Console.WriteLine("0- Exit");
                success = int.TryParse(Console.ReadLine(), out int choice);
                if (success == false)
                {
                    System.Console.WriteLine("Please write Numbers!");
                    Console.ReadKey();
                    CardToCard();
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
                break;
            case 1:
                System.Console.WriteLine("Your Balance is not enough!");
                UserMenu();
                break;
            case 2:
                System.Console.WriteLine("Destination Card is not Valid!");
                UserMenu();
                break;
        }
    }
    /// <summary>
    /// menu that handles view the balance for user
    /// </summary>
    private static void ViewBalance()
    {
        User user = new(cardnumber);
        float balance = user.getBalance();
        Console.Clear();
        System.Console.WriteLine("Your Balance is : {0}", balance);
        System.Console.WriteLine("What do you want to do next : ");
        System.Console.WriteLine("1- Return to the menu");
        System.Console.WriteLine("0- Exit");
        System.Console.Write("Your choice: ");
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
    private static void Deposit()
    {
        User user = new(cardnumber);
        System.Console.WriteLine("How much do you want to deposit? ");
        System.Console.Write("Dollars: ");
        bool success = float.TryParse(Console.ReadLine(), out float cash);
        if (success == false)
        {
            System.Console.WriteLine("Please write Numbers!");
            Deposit();
        }
        else
        {
            // add cash to balance
            user.addCashToBalance_Deposit(cash);
            System.Console.WriteLine("It was success");
            System.Console.WriteLine("Your new Balance is : {0}", user.getBalance());
            System.Console.WriteLine("What next ? ");
            System.Console.WriteLine("1- Another Work");
            System.Console.WriteLine("0- Exit");
            success = int.TryParse(Console.ReadLine(), out int choice);
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
        }
    }

    /// <summary>
    /// menu that handles draw cash for user
    /// </summary>
    private static void CashWithDraw()
    {
        User user = new(cardnumber);
        System.Console.WriteLine("How much do you want to draw? ");
        System.Console.Write("Dollars: ");
        bool success = float.TryParse(Console.ReadLine(), out float cash);
        if (success == false)
        {
            System.Console.WriteLine("Please write Numbers!");
            CashWithDraw();
        }
        else
        {
            // draw cash
            if (!user.DrawCash(cash))
            {
                System.Console.WriteLine("Your Balance is LOW!");
                System.Console.WriteLine("Your new Balance is : {0}", user.getBalance());
            }
            else
            {
                System.Console.WriteLine("It was success");
                System.Console.WriteLine("Your new Balance is : {0}", user.getBalance());
            }
            System.Console.WriteLine("What next ? ");
            System.Console.WriteLine("1- Another Work");
            System.Console.WriteLine("0- Exit");
            success = int.TryParse(Console.ReadLine(), out int choice);
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
        }
    }
}