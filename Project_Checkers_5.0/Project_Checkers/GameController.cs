namespace Project_Checkers;
using System;
using System.Collections.Generic;

public class GameController
{
	private Dictionary<IPlayer, PlayerData> _players;
	private List<IPlayer> _playerTurn;
	private Board _board;
	#region gamecontroller
	/// <summary>
	/// instance gamecontroller yang terdiri dari player1 dan player2
	/// </summary>
	/// <param name="player1">player1</param>
	/// <param name="player2">Player2</param>
	public GameController(IPlayer player1, IPlayer player2)
	{
		_players = new Dictionary<IPlayer, PlayerData>
		{
			{ player1, new PlayerData { playerPiece = InitialPiece.InitializePieces(12, PieceColour.White), status = PlayerStatus.OnGoing } },
			{ player2, new PlayerData { playerPiece = InitialPiece.InitializePieces(12, PieceColour.Black), status = PlayerStatus.OnGoing } }
		};
		_playerTurn = new List<IPlayer> { player1, player2 };
		_board = new Board();
		// Inisialisasi posisi awal bidak checkers
		InitialPositionPiece.InitializeCheckersPositions(_board, player1, player2);
	}
	#endregion
	
	#region getboard
	/// <summary>
	/// untuk dapatkan ukuran board
	/// </summary>
	/// <returns>mengembalikan ukuran board yakni 8x8</returns>
	public Board GetBoard()
	{
		return _board;
	}
	#endregion
	
	#region getlistplayer
	/// <summary>
	/// Gets the list of players in the current turn order.
	/// </summary>
	/// <returns>A List of IPlayer representing the players.</returns>
	public List<IPlayer> GetPlayers() // daftar pemain
	{
		return _playerTurn;
	}
	#endregion
	
	#region inisialisasi piece dan posisinya
	#region InitialPiece
	/// <summary>
	/// inisialisasi piece 
	/// </summary>
	/// <param name="basicPieceCount">jumlah basic piece yang dibuat</param>
	/// <param name="colour">warna piece yang dibuat.</param>
	/// <returns>mengembalikan nilai piece</returns>
	public class InitialPiece
	{
		public static List<Piece> InitializePieces(int basicPieceCount, PieceColour colour)
		{
			List<Piece> pieces = new List<Piece>();
			for (int i = 0; i < basicPieceCount; i++)
			{
				pieces.Add(new Piece { idPiece = i, colour = colour, type = PieceType.Basic }); //set awal piece semua masih basic tipenya
			}
			return pieces;
		}
	}
	#endregion
	
	#region iniSialisasi posisi piece
	public class InitialPositionPiece
	{
		public static void InitializeCheckersPositions(Board board, IPlayer player1, IPlayer player2)
		{
			// Lokasi awal bidak checkers (1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23)
			int[] positions = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23 };
			int whitePieceID = 0;
			int blackPieceID = 0; 

			foreach (var position in positions)
			{
				int row = position / 8; // Baris (0-7) berdasarkan indeks
				int col = position % 8; // Kolom (0-7) berdasarkan indeks

				if (board.IsValidPosition(new Position { x = col, y = row }))
				{
					// Buat piece untuk pemain 1 (putih)
					Piece piecePlayer1 = new Piece { idPiece = whitePieceID, colour = PieceColour.White, type = PieceType.Basic };
					board.SetPieceAt(new Position { x = col, y = row }, piecePlayer1);

					// Buat piece untuk pemain 2 (hitam)
					Piece piecePlayer2 = new Piece { idPiece = blackPieceID, colour = PieceColour.Black, type = PieceType.Basic };
					board.SetPieceAt(new Position { x = 7 - col, y = 7 - row }, piecePlayer2);

					whitePieceID++; // Increment ID untuk piece putih
					blackPieceID++; // Increment ID untuk piece hitam
				}
				else
				{
					 throw new Exception("Posisi tidak valid. Posisi di luar batas papan atau sudah terisi.");
				}
			}
		}
	}
	#endregion
	#endregion

	#region Display board information
	/// <summary>
	/// Mengambil data tampilan papan permainan dalam bentuk daftar tupel yang berisi informasi setiap sel di papan.
	/// </summary>
	/// <returns>Daftar tupel berisi informasi setiap sel, termasuk baris, kolom, ID potongan, warna potongan, tipe potongan, dan status kekosongan.</returns>
	public List<(int Row, int Col, int? PieceId, string Colour, string PieceType, bool IsEmpty)> GetBoardDisplay()
	{
		List<(int Row, int Col, int? PieceId, string Colour, string PieceType, bool IsEmpty)> boardDisplay = new List<(int, int, int?, string, string, bool)>();

		Board board = GetBoard();
		for (int row = 0; row < 8; row++)
		{
			for (int col = 0; col < 8; col++)
			{
				Position position = new Position { x = col, y = row };
				Piece piece = board.GetPieceAt(position);

				// Membuat tupel berisi informasi setiap sel di papan
				var info = (
					Row: row,
					Col: col,
					PieceId: piece?.idPiece,
					Colour: piece?.colour.ToString(), // isi piece yang ada pada posisi tertentu
					PieceType: piece?.type.ToString(),
					IsEmpty: piece == null // piece jadi null ketika tidak ada piece pada posisi tertentu
				);

				boardDisplay.Add(info);
			}
		}

		return boardDisplay;
	}
	#endregion
	
	#region ambil data piece pemain
	/// <summary>
	/// Mengambil daftar piece pemain yang dimiliki oleh pemain 
	/// </summary>
	/// <param name="player">Objek pemain (IPlayer) yang mau di cek pieceny.</param>
	/// <returns>Daftar piece pada pemain.</returns>

	public List<Piece> GetPieces(IPlayer player)
	{
		if (_players.ContainsKey(player))
		{
			return _players[player].playerPiece;
		}
		return new List<Piece>();
	}
	#endregion
	
	#region tampikan piece pemain
	/// <summary>
	/// Mengambil data tampilan piece pemain dalam bentuk daftar tupel yang berisi informasi setiap potongan milik pemain.
	/// </summary>
	/// <param name="player">Objek pemain (IPlayer) yang piecenya akan ditampilkan.</param>
	/// <returns>Daftar tupel berisi informasi setiap potongan pada pemain, termasuk ID, warna, dan tipe.</returns>
	public List<(int PieceId, string Colour, string PieceType)> GetPlayerPiecesDisplay(IPlayer player)
	{
		List<Piece> pieces = GetPieces(player); // daftar piece yang dimiliki pemain

		return pieces.Select(piece => (
			PieceId: piece.idPiece,
			Colour: piece.colour.ToString(),
			PieceType: piece.type.ToString()
		)).ToList();
	}
	#endregion

	#region Pemantauan Status Pemain
	/// <summary>
	/// Mengambil status pemain 
	/// </summary>
	/// <param name="player1">Objek pemain (IPlayer) pertama.</param>
	/// <param name="player2">Objek pemain (IPlayer) kedua.</param>
	/// <returns>Status pemain (PlayerStatus). Jika pemain tidak ditemukan, mengembalikan nilai (0).</returns>
	public PlayerStatus GetStatus(IPlayer player1, IPlayer player2) // status pemain
	{
		if (_players.ContainsKey(player1))
		{
			// Console.WriteLine($"status player {player1.GetName()} {_players[player1].status}");
			return _players[player1].status;
		}
		if (_players.ContainsKey(player2))
		{
			// Console.WriteLine($"status player {player2.GetName()} {_players[player2].status}");
			return _players[player2].status;
		}
		return 0;
	}
	#endregion

	//PieceId: piece.idPiece, 
	// 1. kelas buat gerakan piece
	// 2. kelas buat moveavailable, tampilkan available
	// 3. kelas buat ubah piece tipe basic jadi king
	// 4. kelas buat gerakan piece tipe basic kiri atas dan kanan atas satu langkah
	// 5. kelas buat gerakan piece tipe king kiri atas, kanan atas, kiri bawah, dan kanan bawah satu langkah
	// 6. kelas buat position yang implementasikan gethashcode, buat tampilkan piece id pada posisi tertentu
	

}