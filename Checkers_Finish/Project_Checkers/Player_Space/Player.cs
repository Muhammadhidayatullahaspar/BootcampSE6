namespace Project_Checkers;
public class Player : IPlayer
{
	#region Properti dan Variabel Pemain
	private string _name;
	private int _idPlayer;
	private Dictionary<int, Piece> _pieces;

	/// <summary>
	/// Properti untuk mendapatkan nama pemain.
	/// </summary>
	public string Name => _name;

	/// <summary>
	/// Properti untuk mendapatkan ID pemain.
	/// </summary>
	public int ID => _idPlayer;

	/// <summary>
	/// Properti untuk mengakses koleksi piece pemain.
	/// </summary>
	public Dictionary<int, Piece> Pieces => _pieces;
	#endregion

	#region Konstruktor Pemain
	/// <summary>
	/// Konstruktor untuk objek pemain.
	/// Inisialisasi nama pemain, ID pemain, dan koleksi piece pemain.
	/// </summary>
	/// <param name="name">Nama pemain.</param>
	/// <param name="idPlayer">ID pemain.</param>
	public Player(string name, int idPlayer)
	{
		_name = name;
		_idPlayer = idPlayer;
		_pieces = new Dictionary<int, Piece>();
	}
	#endregion

	// #region Mendapatkan piece Berdasarkan ID
	// /// <summary>
	// /// Mengembalikan piece pemain berdasarkan pieceid.
	// /// </summary>
	// /// <param name="pieceId">ID piece untuk dicari.</param>
	// /// <returns>Objek piece pemain dengan ID yang sesuai, atau null jika tidak ditemukan.</returns>
	// public Piece GetPieceById(int pieceId) // ini lewat gplayerdata untuk dapatkan piece
	// {
	// 	_pieces.TryGetValue(pieceId, out var piece);
	// 	return piece;
	// }
	// #endregion

	#region tambahkan piece
	/// <summary>
	/// tambahkan piece pemain
	/// </summary>
	/// <param name="piece"></param>
	public void AddPiece(Piece piece)
	{
		_pieces[piece.pieceId] = piece;
	}
	#endregion
	
	// #region hapus piece pemain
	// /// <summary>
	// /// hapus piece pemain
	// /// </summary>
	// /// <param name="pieceId"></param>
	// public void RemovePiece(int pieceId)
	// {
	// 	if (_pieces.ContainsKey(pieceId))
	// 	{
	// 		_pieces.Remove(pieceId);
	// 	}
	// }
	// #endregion
	// Metode tambahan untuk menghapus piece
	public void RemovePiece(int pieceId)
	{
		if (_pieces.ContainsKey(pieceId))
		{
			_pieces.Remove(pieceId);
		}
	}
}
