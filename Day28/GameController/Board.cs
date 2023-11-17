namespace MyGame;

public class Board : IBoard
{
	private int _size;
	public Board(int size) 
	{
		_size = size;
	}
    public int GetSize()
    {
		return _size;
    }

}
