namespace Project_Checkers;

public class Board
{
	private Piece[] _pieces;
	
	#region Konstruktor Papan Permainan
	/// <summary>
	/// Konstruktor untuk objek papan permainan.
	/// Inisialisasi array piece dengan ukuran 64.
	/// </summary>
	public Board()
	{
		_pieces = new Piece[64];
	}
	#endregion

	#region Pemeriksaan dan Penetapan Posisi piece di Papan
	/// <summary>
	/// Memeriksa apakah posisi yang diberikan berada dalam batas papan permainan (8x8).
	/// </summary>
	/// <param name="position">Objek posisi (Position) yang akan diperiksa.</param>
	/// <returns>True jika posisi valid, False jika tidak.</returns>
	public bool IsValidPosition(Position position)
	{
		return position.x >= 0 && position.x < 8 && position.y >= 0 && position.y < 8;
	}

	/// <summary>
	/// Menetapkan piece pada posisi tertentu di papan permainan.
	/// </summary>
	/// <param name="position">Objek posisi (Position) tempat piece akan ditempatkan.</param>
	/// <param name="piece">Objek piece yang akan ditempatkan.</param>
	/// <returns>True jika penempatan berhasil, False jika posisi tidak valid.</returns>
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
	#endregion

	#region Mendapatkan piece pada Posisi Tertentu di Papan
	/// <summary>
	/// Mengembalikan piece pada posisi yang ditentukan di papan permainan.
	/// </summary>
	/// <param name="position">Objek posisi (Position) tempat piece akan dicari.</param>
	/// <returns>Objek piece (Piece) pada posisi tertentu, atau null jika posisi tidak valid.</returns>
	public Piece GetPieceAt(Position position)
	{
		int index = position.x + position.y * 8;
		if (IsValidPosition(position))
		{
			return _pieces[index];
		}
		return null;
	}
	#endregion

	#region Mendapatkan Indeks Papan dari Posisi Tertentu
	/// <summary>
	/// Mengembalikan indeks papan berdasarkan objek posisi (Position) yang diberikan.
	/// </summary>
	/// <param name="position">Objek posisi (Position) untuk mendapatkan indeks papan.</param>
	/// <returns>Indeks papan yang sesuai dengan posisi tertentu.</returns>
	public int GetBoardPosition(Position position)
	{
		return position.x + position.y * 8;
	}
	#endregion
	

}
