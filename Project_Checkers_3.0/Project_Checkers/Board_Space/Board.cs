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

	// Metode untuk menempatkan piece pada posisi tertentu
	public void SetPieceAt(Position position, Piece piece)
	{
		int index = position.x + position.y * 8;
		if (IsValidPosition(position))
		{
			_pieces[index] = piece;
		}
		else
		{
			Console.WriteLine("Posisi piece tidak valid");
		}
	}
	
	public Piece GetPieceAt(Position position)
	{
		int index = position.x + position.y * 8;
		if (IsValidPosition(position))
		{
			return _pieces[index];
		}
		return null; // Kembalikan null jika posisi tidak valid atau kosong
	}
	
}

