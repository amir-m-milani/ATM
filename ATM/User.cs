using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;

namespace ATM;

class User
{
    private Dictionary<string, Dictionary<string, object>> users = [];
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
        if (!this.users.ContainsKey(this.cardNO))
            return false;
        this.users.Add(this.cardNO, new Dictionary<string, object>() { { "password", this.password }, { "balance", this.balance } });
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
        if ((string)this.users[this.cardNO]["password"] != this.password)
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
    /// <summary>
    /// retrun the balance of the user
    /// </summary>
    /// <returns>float</returns>
    public float getBalance()
    {
        return (float)this.users[this.cardNO]["balance"];
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