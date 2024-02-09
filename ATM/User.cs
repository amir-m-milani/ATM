using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;

namespace ATM;

class User
{
    private Dictionary<string, string> users = [];
    private string cardNO;
    private string password;
    private float balance;
    public User(string cardNO, string password, float balance)
    {
        this.cardNO = cardNO;
        this.password = password;
        this.balance = balance;
    }
    /// <summary>
    /// returns true if user does not exists
    /// </summary>
    /// <returns>bool</returns>
    public bool AddUser()
    {
        if (!this.users.ContainsKey(this.cardNO))
            return false;
        this.users.Add(this.cardNO, this.password);
        return true;
    }
    /// <summary>
    /// check if the user not exits return false;
    /// check if the password not match return false;
    /// </summary>
    /// <returns>bool</returns>
    public bool checkCardnumberAndPassword()
    {
        if (!this.users.ContainsKey(this.cardNO))
            return false;
        if (this.users[this.cardNO] != this.password)
            return false;
        return true;
    }
    /// <summary>
    /// if user not exists return false 
    /// </summary>
    /// <returns>bool</returns>
    public bool checkCardnumber()
    {
        if (!this.users.ContainsKey(this.cardNO))
            return false;
        return true;
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