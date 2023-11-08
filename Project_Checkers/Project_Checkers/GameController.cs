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
			{ player1, new PlayerData { playerPiece = InitialPiece.InitializePieces(12, PieceColour.White), moveKing = new List<Piece>(), score = 0, status = PlayerStatus.OnGoing } },
			{ player2, new PlayerData { playerPiece = InitialPiece.InitializePieces(12, PieceColour.Black), moveKing = new List<Piece>(), score = 0, status = PlayerStatus.OnGoing } }
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
	/// inisialisasi piece pada awal permaian
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

					whitePieceID++; // Increment ID untuk bidak putih
					blackPieceID++; // Increment ID untuk bidak hitam
				}
				else
				{
					Console.WriteLine("Posisi tidak valid. Posisi di luar batas papan atau sudah terisi.");
				}
			}
		}
	}
	#endregion
	#endregion

	#region Display board information
	/// <summary>
	/// Menampilkan papan permainan beserta piece yang ada di dalamnya.
	/// </summary>
	public void DisplayBoard()
	{
		Console.WriteLine("Papan Permainan:");
		Board board = GetBoard();
		for (int row = 0; row < 8; row++)
		{
			for (int col = 0; col < 8; col++)
			{
				Position position = new Position { x = col, y = row };
				Piece piece = board.GetPieceAt(position);
				if (piece != null)
				{
					Console.WriteLine($"Posisi ({row}, {col}): Piece ID {piece.idPiece}, Colour {piece.colour}, Type {piece.type}");
				}
				else
				{
					Console.WriteLine($"Posisi ({row}, {col}): Kosong");
				}
			}
		}
		Console.WriteLine();
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
	/// Menampilkan daftar piece pada pemain
	/// </summary>
	/// <param name="player">Objek pemain yang piecenya akan ditampilkan.</param>
	public void DisplayPlayerPieces(IPlayer player)
	{
		List<Piece> pieces = GetPieces(player);

		string playerColor = (player == _playerTurn[0]) ? "Putih" : "Hitam";

		Console.WriteLine($"Daftar Bidak Awal (Player {playerColor}):");
		foreach (var piece in pieces)
		{
			Console.WriteLine("ID: " + piece.idPiece + ", Colour: " + piece.colour + ", Type: " + piece.type);
		}
		Console.WriteLine();
	}
	#endregion


	// public bool MovePiece(IPlayer player, int idPiece, Position position)
	// {
	// 	// Cari pemain berdasarkan objek pemain yang diberikan
	// 	if (_players.ContainsKey(player) && _board.IsValidPosition(position))
	// 	{
	// 		// Validasi ID bidak
	// 		List<Piece> playerPieces = GetPieces(player);
	// 		if (idPiece >= 0 && idPiece < playerPieces.Count)
	// 		{
	// 			Piece piece = playerPieces[idPiece];
	// 			return MovePiece(player, piece, position);
	// 		}
	// 	}
	// 	return false;
	// }


	// public List<Position> GetAvailableMove(Piece piece) // untuk dapat posisi yang tersedia
	// {
	// 	List<Position> availableMoves = new List<Position>();
	// 	return availableMoves;
	// }

	// public List<Position> GetAvailableMove(int idPlayer, int idPiece) // untuk tau posisi piece yang tersedia oleh idplayer
	// {
	// 	if (idPlayer >= 0 && idPlayer < _playerTurn.Count)
	// 	{
	// 		Piece piece = GetPieces(idPlayer)[idPiece];
	// 		return GetAvailableMove(piece);
	// 	}
	// 	return new List<Position>();
	// }

	public PlayerStatus GetStatus(IPlayer player) // status pemain
	{
		if (_players.ContainsKey(player))
		{
			return _players[player].status;
		}
		return PlayerStatus.Win;
	}

	public PlayerStatus GetStatus(int idPlayer) // status pemain idplayer
	{
		if (idPlayer >= 0 && idPlayer < _playerTurn.Count)
		{
			IPlayer player = _playerTurn[idPlayer];
			return GetStatus(player);
		}
		return PlayerStatus.Win;
	}

	public int GetScore(IPlayer player) // score pemain
	{
		if (_players.ContainsKey(player))
		{
			return _players[player].score;
		}
		return 0; 
	}

	public int GetScore(int idPlayer) // score pemain idplayer
	{
		if (idPlayer >= 0 && idPlayer < _playerTurn.Count)
		{
			IPlayer player = _playerTurn[idPlayer];
			return GetScore(player);
		}
		return 0;
	}
}