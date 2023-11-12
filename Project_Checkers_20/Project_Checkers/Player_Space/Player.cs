namespace Project_Checkers;
public class Player : IPlayer
{
	private string _name;
	private int _idPlayer;
	private Dictionary<int, Piece> _pieces;

	public string Name => _name;
	public int ID => _idPlayer;

	// Tambahkan properti publik untuk mengakses _pieces
	public Dictionary<int, Piece> Pieces => _pieces;

	public Player(string name, int idPlayer)
	{
		_name = name;
		_idPlayer = idPlayer;
		_pieces = new Dictionary<int, Piece>();
	}

	public Piece GetPieceById(int pieceId)
	{
		_pieces.TryGetValue(pieceId, out var piece);
		return piece;
	}

	public void AddPiece(Piece piece)
	{
		_pieces[piece.pieceId] = piece;
	}
	
	public void RemovePiece(int pieceId)
    {
        if (_pieces.ContainsKey(pieceId))
        {
            _pieces.Remove(pieceId);
        }
    }
}
