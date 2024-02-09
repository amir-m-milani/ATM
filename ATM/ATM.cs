using System.Configuration.Assemblies;

namespace ATM;

static class ATM
{
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
        UserMenu();
    }
    public static void ExitMenu()
    {
        System.Console.WriteLine("\tHave a Good Time");
    }
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

    private static void CardToCard()
    {
        throw new NotImplementedException();
    }

    private static void ViewBalance()
    {

        // throw new NotImplementedException();
    }

    private static void Deposit()
    {
        throw new NotImplementedException();
    }

    private static void CashWithDraw()
    {
        throw new NotImplementedException();
    }
}