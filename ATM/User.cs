using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;

namespace ATM;

class User
{
    private static Dictionary<string, Dictionary<string, object>> users = [];
    private string cardNO;
    private string password;
    private float balance;
    public User(string cardNO, string password, float balance)
    {
        this.cardNO = cardNO;
        this.password = password;
        this.balance = balance;
    }
    public User(string cardNO, string password)
    {
        this.cardNO = cardNO;
        this.password = password;
    }
    public User(string cardNO)
    {
        this.cardNO = cardNO;
    }
    /// <summary>
    /// returns true if user does not exists. just use for testing
    /// </summary>
    /// <returns>bool</returns>
    public bool AddUser()
    {
        if (users.ContainsKey(this.cardNO))
            return false;
        users.Add(this.cardNO, new Dictionary<string, object>() { { "password", this.password }, { "balance", this.balance } });
        return true;
    }
    /// <summary>
    /// check if the user not exits return false;
    /// check if the password not match return false;
    /// </summary>
    /// <returns>bool</returns>
    public bool checkCardnumberAndPassword()
    {
        if (users.ContainsKey(this.cardNO) == false)
        {
            System.Console.WriteLine("user does not exists");
            return false;
        }
        if ((string)users[this.cardNO]["password"] != this.password)
        {
            System.Console.WriteLine("password inccorect");
            return false;
        }
        return true;
    }
    /// <summary>
    /// if user not exists return false 
    /// </summary>
    /// <returns>bool</returns>
    public bool checkCardnumber(string cardnumber)
    {
        if (!users.ContainsKey(cardnumber))
            return false;
        return true;
    }
    /// <summary>
    /// retrun the balance of the user
    /// </summary>
    /// <returns>float</returns>
    public float getBalance()
    {
        return (float)users[this.cardNO]["balance"];
    }

    public void addCashToBalance_Deposit(float cash)
    {
        float temp = (float)users[this.cardNO]["balance"];
        temp += cash;
        users[this.cardNO]["balance"] = temp;
    }

    public bool DrawCash(float cash)
    {
        float temp = (float)users[this.cardNO]["balance"];
        if (temp < cash)
            return false;
        temp -= cash;
        users[this.cardNO]["balance"] = temp;
        return true;
    }
    /// <summary>
    /// Transfer cash from one card to another
    /// </summary>
    /// <param name="cash">How much to Transfer</param>
    /// <param name="cardNumber">Detination Card</param>
    /// <returns>
    ///     0:success-
    ///     1:not enough cash-
    ///     2:wrong destinnation card
    /// </returns>
    public int CardToCard(float cash, string cardNumber)
    {
        float temp = (float)users[this.cardNO]["balance"];
        if (temp < cash)
            return 1;
        if (!checkCardnumber(cardNumber))
            return 2;
        temp -= cash;
        users[this.cardNO]["balance"] = temp;
        temp = (float)users[cardNumber]["balance"];
        temp += cash;
        users[cardNumber]["balance"] = temp;
        return 0;
    }
    /*
    public void SaveUserToFile(string cardNumber, string password)
    {
        User user = new(cardNumber, password);
        string json = JsonSerializer.Serialize(user); // serialize the object to a JSON string
        File.WriteAllText("users.json", json); // write the JSON string to a file
        System.Console.WriteLine("its done!");
    }
    */


}