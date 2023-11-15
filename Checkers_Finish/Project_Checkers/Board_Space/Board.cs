namespace Project_Checkers;

public class Board
{
	private Piece[] _pieces;
	// revisidibawah
	public static int BoardSize { get; private set; } //No need to static, it will only make your Board can be created more than one, but the variable will be the same
	public Board() // Board(int size)
	{
		BoardSize = 8; // Hardcode
		_pieces = new Piece[BoardSize * BoardSize];
	}

	#region Pemeriksaan dan Penetapan Posisi piece di Papan
	/// <summary>
	/// Memeriksa apakah posisi yang diberikan berada dalam batas papan permainan (BoardSizexBoardSize).
	/// </summary>
	/// <param name="position">Objek posisi (Position) yang akan diperiksa.</param>
	/// <returns>True jika posisi valid, False jika tidak.</returns>
	public bool IsValidPosition(Position position)
	{
		return position.X >= 0 && position.X < BoardSize && position.Y >= 0 && position.Y < BoardSize;
	}

	/// <summary>
	/// Menetapkan piece pada posisi tertentu di papan permainan.
	/// </summary>
	/// <param name="position">Objek posisi (Position) tempat piece akan ditempatkan.</param>
	/// <param name="piece">Objek piece yang akan ditempatkan.</param>
	/// <returns>True jika penempatan berhasil, False jika posisi tidak valid.</returns>
	public bool SetPieceAt(Position position, Piece piece) 
	{
		int index = position.X + position.Y * BoardSize;
		
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
		int index = position.X + position.Y * BoardSize;
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
		return position.X + position.Y * BoardSize;
	}
	#endregion
	
	// revisi
	// 1. dapat nilai ukuran papan yang sekali set, hanya pada class board (sudah)
	// 2. public int Y {get; set;} // ini huruf besar (sudah)
	// 3. jangan pakai tupple di gamecontroller(sudah)
	// 4. ubah tampilan papan jadi kayak bentuk kotak tulisannya (sudah)
	// 5. throw exception, bukan return 0 untuk yang menggunakan enum (sudah)
	// 6. dapatkan piece dan hapus piece pemain lewat playerdata bukan piece.iplayer (sudah)
}

	// revisi
	//1. tidak perlu pakai static di board (belum)
	//2. pengubahan size board itu lewat program.cs (belum)
	//3. tidak perlu pakai idfield karena itu bagian frontend (belum)
	// 4. gamecontrolller tidak perlu pakai parameter board karena sudha ada board dalam gamecontrolller (belum)
	// 5. buat kelas masing masing di display board contohnya dibawah (belum)
	// //public List<Piece> GetPieces(Player p)
	//public List<Piece> GetPieces(int playerId)