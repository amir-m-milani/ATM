namespace ATM;

class Program
{
    static void Main(string[] args)
    {
        User user1 = new("123", "123", 1000f);
        if (user1.AddUser())
        {
            System.Console.WriteLine("user1 created");
        }
        else
        {
            System.Console.WriteLine("user1 not created");
        }

        User user2 = new("1234", "1234", 1000f);
        if (user2.AddUser())
        {
            System.Console.WriteLine("user2 created");
        }
        else
        {
            System.Console.WriteLine("user2 not created");
        }
        User user3 = new("12345", "12345", 1000f);
        if (user3.AddUser())
        {
            System.Console.WriteLine("user3 created");
        }
        else
        {
            System.Console.WriteLine("user3 not created");
        }
        ATM.Menu();
    }
}
