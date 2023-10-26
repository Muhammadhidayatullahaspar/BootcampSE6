namespace Domino;

public class Player
{
	private int _id;
	private string _name;
	public Player(int id, string name) 
	{
		_id = id;
		_name = name;
	}
	public string GetName() 
	{
		return _name;
	}
	public int GetID() 
	{
		return _id;
	}
}
