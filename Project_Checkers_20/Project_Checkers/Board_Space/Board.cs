namespace Project_Checkers;

public class Board
{
	private Piece[] _pieces;

	public Board()
	{
		_pieces = new Piece[64];
	}

	public bool IsValidPosition(Position position)
    {
        return position.x >= 0 && position.x < 8 && position.y >= 0 && position.y < 8;
    }

	public bool SetPieceAt(Position position, Piece piece) 
	{
		int index = position.x + position.y * 8;
		
		if (IsValidPosition(position))
		{
			_pieces[index] = piece;
			return true;
		}
		else
		{
			return false;
		}
	}

	public Piece GetPieceAt(Position position)
	{
		int index = position.x + position.y * 8;
		if (IsValidPosition(position))
		{
			return _pieces[index];
		}
		return null;
	}

	public int GetBoardPosition(Position position)
	{
		return position.x + position.y * 8;
	}
	

}
