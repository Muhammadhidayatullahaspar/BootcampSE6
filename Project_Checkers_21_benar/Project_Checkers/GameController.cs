namespace Project_Checkers;
using System;
using System.Collections.Generic;

public class GameController
{
	#region Variabel dan Properti GameController
	/// <summary>
	/// Koleksi pemain dan data pemain dalam permainan.
	/// </summary>
	private Dictionary<IPlayer, PlayerData> _players;

	/// <summary>
	/// Daftar pemain yang sedang giliran bermain.
	/// </summary>
	private List<IPlayer> _playerTurn;

	/// <summary>
	/// Objek papan permainan.
	/// </summary>
	private Board _board;

	/// <summary>
	/// Objek GameController yang merupakan instance singleton.
	/// </summary>
	private static GameController _gameController;
	#endregion

	#region gamecontroller
	/// <summary>
	/// instance gamecontroller yang terdiri dari player1 dan player2
	/// </summary>
	/// <param name="player1">player1</param>
	/// <param name="player2">Player2</param>
	public GameController(IPlayer player1, IPlayer player2)
	{
		_board = new Board();

		var player1Pieces = InitializePieces(12, PieceColour.White, 1);
		var player2Pieces = InitializePieces(12, PieceColour.Black, 13);

		// Tugaskan piece ke pemain
		foreach (var piece in player1Pieces)
		{
			piece.Player = player1;
			if (player1 is Player player) // Lakukan cast ke Player
			{
				player.AddPiece(piece);
			}
		}

		foreach (var piece in player2Pieces)
		{
			piece.Player = player2;
			if (player2 is Player player) // Lakukan cast ke Player
			{
				player.AddPiece(piece);
			}
		}

		// Menempatkan piece di papan
		InitializeBoard(player1Pieces, player2Pieces);

		// Simpan informasi pemain
		_players = new Dictionary<IPlayer, PlayerData>
		{
			{ player1, new PlayerData(player1) },
			{ player2, new PlayerData(player2) }
		};

	}


	#endregion
	
	#region Inisialisasi Papan Permainan
	/// <summary>
	/// Menginisialisasi papan permainan dengan menempatkan piece pemain pada posisi awal.
	/// </summary>
	/// <param name="player1Pieces">Daftar piece pemain 1.</param>
	/// <param name="player2Pieces">Daftar piece pemain 2.</param>
	private void InitializeBoard(List<Piece> player1Pieces, List<Piece> player2Pieces)
	{
		// Menempatkan piece pemain 1 pada baris 0-2
		PlacePiecesOnBoard(player1Pieces, 0);

		// Menempatkan piece pemain 2 pada baris 5-7
		PlacePiecesOnBoard(player2Pieces, 5);
	}
	#endregion

	#region Penempatan piece pada Papan
	/// <summary>
	/// Menempatkan piece pemain pada papan permainan, dimulai dari baris tertentu.
	/// </summary>
	/// <param name="pieces">Daftar piece pemain yang akan ditempatkan.</param>
	/// <param name="startingRow">Baris awal tempat piece akan ditempatkan.</param>
	private void PlacePiecesOnBoard(List<Piece> pieces, int startingRow)
	{
		int pieceIndex = 0;
		for (int row = startingRow; row < startingRow + 3; row++)
		{
			for (int col = 0; col < 8; col++)
			{
				// Hanya menempatkan piece pada kotak berwarna gelap
				if ((row + col) % 2 != 0 && pieceIndex < pieces.Count)
				{
					var piece = pieces[pieceIndex++];
					piece.Position = new Position { x = col, y = row };
					_board.SetPieceAt(new Position { x = col, y = row }, piece);
				}
			}
		}
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
	/// dapatkan list pemain
	/// </summary>
	/// <returns>list pemain.</returns>
	public List<IPlayer> GetPlayers()
	{
		return _players.Keys.ToList();
	}

	#endregion
	
	#region inisialisasi piece dan posisinya
	#region InitialPiece
	/// <summary>
	///  inisialisasi piece
	/// </summary>
	/// <param name="pieceCount"> jumlah piece yang dibuat</param>
	/// <param name="colour"> warna piece</param>
	/// <param name="startId"> mulai dari idpiece</param>
	/// <returns></returns>
	public static List<Piece> InitializePieces(int pieceCount, PieceColour colour, int startId)
	{
		List<Piece> pieces = new List<Piece>();
		for (int i = 0; i < pieceCount; i++)
		{
			Piece newPiece = new Piece(colour, PieceType.Basic)
			{
				pieceId = startId + i // Mulai ID dari startId
			};

			pieces.Add(newPiece);
		}
		return pieces;
	}


	#endregion
	
	#region iniSialisasi posisi piece
	public class InitialPositionPiece
	{
		public static void InitializeCheckersPositions(Board board, IPlayer player1, IPlayer player2)
		{
			int[] positions = { /* posisi awal */ };
			int pieceIDWhite = 1;
			int pieceIDBlack = 13;

			foreach (var position in positions)
			{
				int row = (position - 1) / 8;
				int col = (position - 1) % 8;

				if (board.IsValidPosition(new Position { x = col, y = row }))
				{
					if (row < 3) 
					{
						var piecePlayer1 = new Piece(PieceColour.White, PieceType.Basic)
						{
							pieceId = pieceIDWhite++, 
							Position = new Position { x = col, y = row }
						};
						board.SetPieceAt(new Position { x = col, y = row }, piecePlayer1);
					}
					else if (row > 4) 
					{
						// Membuat piece hitam
						Piece piecePlayer2 = new Piece(PieceColour.Black, PieceType.Basic)
						{
							pieceId = pieceIDBlack++, 
							Position = new Position { x = col, y = row }
						};
						board.SetPieceAt(new Position { x = col, y = row }, piecePlayer2);
					}
				}
			}
		}
	}

	#endregion
	#endregion

	#region Mendapatkan Tampilan Papan Permainan
	/// <summary>
	/// Mengembalikan daftar informasi tampilan papan permainan.
	/// </summary>
	/// <returns>
	/// Daftar informasi tampilan papan permainan, 
	/// berisi posisi, ID piece, warna, jenis piece, status kosong, dan ID kotak.
	/// </returns>
	public List<(int PositionBoard, int? PieceId, string Colour, string PieceType, bool IsEmpty, int? IdField)> GetBoardDisplay()
	{
		var boardDisplay = new List<(int PositionBoard, int? PieceId, string Colour, string PieceType, bool IsEmpty, int? IdField)>();
		int idFieldCounter = 1;

		for (int row = 0; row < 8; row++)
		{
			for (int col = 0; col < 8; col++)
			{
				var position = new Position { x = col, y = row };
				var piece = _board.GetPieceAt(position);

				// Hanya pada kotak berwarna gelap
				if ((row + col) % 2 != 0) 
				{
					var info = (
						PositionBoard: _board.GetBoardPosition(position) + 1,
						PieceId: piece?.pieceId, 
						Colour: piece?.Colour.ToString(), 
						PieceType: piece?.Type.ToString(), 
						IsEmpty: piece == null,
						IdField: idFieldCounter++ // Menambahkan IdFieldCounter hanya untuk kotak valid
					);

					boardDisplay.Add(info);
				}
				else
				{
					var info = (
						PositionBoard: _board.GetBoardPosition(position) + 1,
						PieceId: piece?.pieceId, 
						Colour: piece?.Colour.ToString(), 
						PieceType: piece?.Type.ToString(), 
						IsEmpty: piece == null,
						IdField: (int?)null // Tidak menambahkan IdFieldCounter untuk kotak tidak valid
					);

					boardDisplay.Add(info);
				}
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
		return _players[player].GetPieces();
	}
	#endregion
	
	#region Mendapatkan Tampilan piece Pemain
	/// <summary>
	/// Mengembalikan daftar informasi tampilan piece pemain.
	/// </summary>
	/// <param name="player">Objek pemain (IPlayer) yang piecnya akan ditampilkan.</param>
	/// <returns>
	/// Daftar informasi tampilan piece pemain, 
	/// berisi ID piece, warna, dan jenis piece.
	/// </returns>
	public List<(int PieceId, string Colour, string PieceType)> GetPlayerPiecesDisplay(IPlayer player)
	{
		var playerPieces = _players[player].GetPieces();
		return playerPieces.Select(piece => (PieceId: piece.pieceId, Colour: piece.Colour.ToString(), PieceType: piece.Type.ToString())).ToList();
	}
	#endregion

	#region Pemantauan Status Pemain
	/// <summary>
	/// Mendapatkan status pemain.
	/// </summary>
	/// <param name="player1">Objek pemain 1 (IPlayer).</param>
	/// <param name="player2">Objek pemain 2 (IPlayer).</param>
	/// <returns>Status pemain, atau 0 jika pemain tidak ditemukan.</returns>
	public PlayerStatus GetStatus(IPlayer player1, IPlayer player2)
	{
		if (_players.ContainsKey(player1))
		{
			return _players[player1].Status;
		}
		if (_players.ContainsKey(player2))
		{
			return _players[player2].Status;
		}
		return 0;
	}
	#endregion

	#region Pergerakan piece
	/// <summary>
	/// Memindahkan piece dari satu posisi ke posisi lain.
	/// </summary>
	/// <param name="from">Posisi awal piecce.</param>
	/// <param name="to">Posisi tujuan piece.</param>
	/// <returns>
	/// True jika pergerakan berhasil dilakukan, False jika pergerakan tidak valid atau gagal.
	/// </returns>
	public bool MovePiece(Position from, Position to)
	{
		if (!_board.IsValidPosition(from) || !_board.IsValidPosition(to))
		{
			return false; // Posisi tidak valid
		}

		Piece piece = _board.GetPieceAt(from);
		if (piece == null)
		{
			return false; // Tidak ada piece di posisi asal
		}

		// Periksa apakah gerakan valid berdasarkan tipe piece dan aturan permainan
		if (IsValidMove(piece, from, to))
		{
			// Periksa dan hapus piece lawan jika ini adalah gerakan makan
			if (Math.Abs(to.x - from.x) == 2 && Math.Abs(to.y - from.y) == 2)
			{
				Position middle = new Position { x = (from.x + to.x) / 2, y = (from.y + to.y) / 2 };
				Piece capturedPiece = _board.GetPieceAt(middle);
				
				if (capturedPiece != null)
				{
					// Hapus piece yang dimakan dari papan
					_board.SetPieceAt(middle, null);

					// Hapus piece yang dimakan dari pemiliknya
					if (_players[capturedPiece.Player].Player is Player player)
					{
						player.RemovePiece(capturedPiece.pieceId);
					}
				}
			}

			// Lakukan gerakan
			_board.SetPieceAt(to, piece);
			_board.SetPieceAt(from, null); // Kosongkan posisi asal
			piece.Position = to; // Perbarui posisi piece

			// Periksa promosi ke King jika perlu
			CheckForPromotion(piece);

			return true;
		}

		return false;
	}
	#endregion
	
	#region Pengecekan Kondisi Menang
	/// <summary>
	/// Memeriksa kondisi kemenangan dan mengatur status pemain sesuai hasil permainan.
	/// </summary>
	private void CheckWinCondition()
	{
		foreach (var playerData in _players.Values)
		{
			// Periksa apakah pemain ini tidak memiliki piece yang tersisa
			var pieces = playerData.GetPieces();
			if (pieces.Count == 0)
			{
				// Pemain ini kalah
				playerData.Status = PlayerStatus.Lose;

				// Tentukan dan atur status kemenangan untuk pemain lain
				foreach (var otherPlayerData in _players.Values)
				{
					if (otherPlayerData != playerData)
					{
						otherPlayerData.Status = PlayerStatus.Win;
						break; // Keluar dari loop setelah menemukan dan mengatur pemenang
					}
				}

				// Tidak perlu memeriksa pemain lain setelah menemukan pemain yang kalah
				break;
			}
		}
	}
	
	/// <summary>
	/// agar bisa diakses di class program
	/// </summary>
	public void CheckGameStatus()
	{
		CheckWinCondition();
	}
	#endregion

	#region Validasi Gerakan
	/// <summary>
	/// Memeriksa apakah suatu gerakan adalah gerakan yang valid untuk piece tertentu.
	/// </summary>
	/// <param name="piece">Piece yang ingin digerakkan.</param>
	/// <param name="from">Posisi awal piece.</param>
	/// <param name="to">Posisi tujuan piece.</param>
	/// <returns>True jika gerakan valid, False jika tidak.</returns>
	private bool IsValidMove(Piece piece, Position from, Position to)
	{
		// Periksa apakah kotak tujuan kosong
		if (_board.GetPieceAt(to) != null)
		{
			return false; // Kotak tujuan tidak kosong
		}

		// Hitung perbedaan posisi
		int deltaX = to.x - from.x;
		int deltaY = to.y - from.y;

		// Aturan untuk piece Basic
		if (piece.Type == PieceType.Basic)
		{
			// Cek arah pergerakan sesuai warna piece
			int direction = (piece.Colour == PieceColour.White) ? 1 : -1;

			// Gerakan biasa (majunya satu langkah diagonal)
			if (Math.Abs(deltaX) == 1 && deltaY == direction)
			{
				return true;
			}

			// Gerakan makan (melompati piece lawan)
			if (Math.Abs(deltaX) == 2 && deltaY == 2 * direction)
			{
				// Periksa apakah ada piece lawan di antara
				Position middle = new Position { x = from.x + deltaX / 2, y = from.y + deltaY / 2 };
				Piece middlePiece = _board.GetPieceAt(middle);
				if (middlePiece != null && middlePiece.Colour != piece.Colour)
				{
					return true; // Dapat melompati dan mengambil piece lawan
				}
			}
		}

		// Aturan untuk piece King
		if (piece.Type == PieceType.King)
		{
			// King bisa bergerak maju atau mundur satu langkah
			if (Math.Abs(deltaX) == 1 && Math.Abs(deltaY) == 1)
			{
				return true;
			}

			// Gerakan makan King
			if (Math.Abs(deltaX) == 2 && Math.Abs(deltaY) == 2)
			{
				// Periksa apakah ada piece lawan di antara
				Position middle = new Position { x = from.x + deltaX / 2, y = from.y + deltaY / 2 };
				Piece middlePiece = _board.GetPieceAt(middle);
				if (middlePiece != null && middlePiece.Colour != piece.Colour)
				{
					return true; // Dapat melompati dan mengambil piece lawan
				}
			}
		}

		return false; // Gerakan tidak valid
	}
	#endregion

	#region Cek Promosi
	/// <summary>
	/// Memeriksa apakah suatu piece memenuhi syarat untuk dipromosikan menjadi King.
	/// </summary>
	/// <param name="piece">Piece yang ingin diperiksa.</param>
	private void CheckForPromotion(Piece piece)
	{
		// Jika piece mencapai ujung papan lawan, promosikan ke King
		if ((piece.Colour == PieceColour.White && piece.Position.y == 7) ||
			(piece.Colour == PieceColour.Black && piece.Position.y == 0))
		{
			piece.Type = PieceType.King;
		}
	}
	#endregion

	#region Daftar Gerakan Valid untuk Sebuah Piece
	/// <summary>
	/// Mendapatkan daftar posisi yang merupakan gerakan valid untuk suatu piece pada posisi tertentu.
	/// </summary>
	/// <param name="piece">Piece yang akan diperiksa gerakan validnya.</param>
	/// <param name="currentPosition">Posisi saat ini dari piece.</param>
	/// <returns>Daftar posisi yang merupakan gerakan valid untuk piece tersebut.</returns>
	public List<Position> GetValidMovesForPiece(Piece piece, Position currentPosition)
	{
		var validMoves = new List<Position>();
		for (int y = 0; y < 8; y++)
		{
			for (int x = 0; x < 8; x++)
			{
				Position newPosition = new Position { x = x, y = y };
				if (IsValidMove(piece, currentPosition, newPosition))
				{
					validMoves.Add(newPosition);
				}
			}
		}
		return validMoves;
	}
	#endregion

}
