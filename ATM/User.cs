namespace ATM;

class User
{
    int id;
    string name;
    string cardNO;
    public User(
        int id,
        string name,
        string cardNO
    )
    {
        this.id = id;
        this.name = name;
        this.cardNO = cardNO;
    }
}