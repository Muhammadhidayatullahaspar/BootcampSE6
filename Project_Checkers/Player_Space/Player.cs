namespace Project_Checkers;

public class Player : IPlayer
{
    private string _name;
    private int _idPlayer;

    public Player(string name, int idPlayer)
    {
        _name = name;
        _idPlayer = idPlayer;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetID()
    {
        return _idPlayer;
    }
}