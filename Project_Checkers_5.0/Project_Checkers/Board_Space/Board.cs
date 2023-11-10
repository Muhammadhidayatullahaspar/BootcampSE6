namespace Project_Checkers;

public class Board
{
	private Piece[] _pieces;

	public Board()
	{
		_pieces = new Piece[64]; // Menginisialisasi array dengan panjang 64 (8x8)
	}

	public bool IsValidPosition(Position position)
	{
		// Implementasi validasi posisi pada papan
		int index = position.x + position.y * 8; // Menghitung indeks dari posisi (x, y) pada array 1D
		return index >= 0 && index < 64; // Memastikan posisi berada dalam rentang yang valid
	}

	#region tempatkan piece
	/// <summary>
	/// menempatkan piece pada posisi tertentu
	/// </summary>
	/// <param name="position"></param>
	/// <param name="piece"></param>
	/// <returns></returns>
	public bool SetPieceAt(Position position, Piece piece) 
	{
		int index = position.x + position.y * 8;
		
		if (IsValidPosition(position))
		{
			_pieces[index] = piece;
			return true; // Operasi berhasil
		}
		else
		{
			// Operasi gagal
			return false;
		}
	}
	#endregion
	
	#region ambil data piece pada posisi tertentu
	/// <summary>
	/// dapatkan piece pada posisi tertentu
	/// </summary>
	/// <param name="position"></param>
	/// <returns></returns>
	public Piece GetPieceAt(Position position)
	{
		int index = position.x + position.y * 8;
		if (IsValidPosition(position))
		{
			return _pieces[index];
		}
		return null; // Kembalikan null jika posisi tidak valid atau kosong
	}
	#endregion
	
}

