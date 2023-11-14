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
	//private List<IPlayer> _playerTurn;
	/// <summary>
	/// Objek papan permainan.
	/// </summary>
	private Board _board;
	#endregion

	#region gamecontroller
	/// <summary>
	/// instance gamecontroller yang terdiri dari player1 dan player2
	/// </summary>
	/// <param name="player1">player1</param>
	/// <param name="player2">Player2</param>
	public GameController(IPlayer player1, IPlayer player2) //GameController need parameter Board, GameController have Board inside it
	{
		_board = new Board();

		var player1Pieces = InitializePieces(12, PieceColour.White, 1);
		var player2Pieces = InitializePieces(12, PieceColour.Black, 13);

		foreach (var piece in player1Pieces)
		{
			if (player1 is Player player)
			{
				player.AddPiece(piece);
			}
		}

		foreach (var piece in player2Pieces)
		{
			if (player2 is Player player)
			{
				player.AddPiece(piece);
			}
		}

		InitializeBoard(player1Pieces, player2Pieces);

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
			for (int col = 0; col < Board.BoardSize; col++)
			{
				// Hanya menempatkan piece pada kotak berwarna gelap
				if ((row + col) % 2 != 0 && pieceIndex < pieces.Count)
				{
					var piece = pieces[pieceIndex++];
					piece.Position = new Position { X = col, Y = row };
					_board.SetPieceAt(new Position { X = col, Y = row }, piece);
				}
			}
		}
	}
	#endregion
	
	#region inisialisasi piece dan posisinya
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


	#region Mendapatkan Tampilan Papan Permainan
	/// <summary>
	/// Mengembalikan daftar informasi tampilan papan permainan.
	/// </summary>
	/// <returns>
	/// Daftar informasi tampilan papan permainan, 
	/// berisi posisi, ID piece, warna, jenis piece, status kosong, dan ID kotak.
	/// </returns>
	public List<BoardDisplayInfo> GetBoardDisplay()
	{
		var boardDisplay = new List<BoardDisplayInfo>();
		int idFieldCounter = 1;

		for (int row = 0; row < Board.BoardSize; row++)
		{
			for (int col = 0; col < Board.BoardSize; col++)
			{
				var position = new Position { X = col, Y = row };
				var piece = _board.GetPieceAt(position);

				if ((row + col) % 2 != 0) // Hanya pada kotak berwarna gelap
				{
					boardDisplay.Add(new BoardDisplayInfo(
						_board.GetBoardPosition(position) + 1,
						piece?.pieceId,
						piece?.Colour.ToString(),
						piece?.Type.ToString(),
						piece == null,
						idFieldCounter++ // Menambahkan IdFieldCounter hanya untuk kotak valid
					));
				}
				else
				{
					boardDisplay.Add(new BoardDisplayInfo(
						_board.GetBoardPosition(position) + 1,
						piece?.pieceId,
						piece?.Colour.ToString(),
						piece?.Type.ToString(),
						piece == null,
						null // Tidak menambahkan IdFieldCounter untuk kotak tidak valid
					));
				}
			}
		}

		return boardDisplay;
	}
	
	//public List<Piece> GetPieces(Player p)
	//public List<Piece> GetPieces(int playerId)

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
	public List<PlayerPieceInfo> GetPlayerPiecesDisplay(IPlayer player)
	{
		var playerPieces = _players[player].GetPieces();
		return playerPieces.Select(piece => 
			new PlayerPieceInfo(piece.pieceId, piece.Colour.ToString(), piece.Type.ToString())
		).ToList();
	}

	#endregion

	#region Pemantauan Status Pemain
	/// <summary>
	/// Mendapatkan status pemain.
	/// </summary>
	/// <param name="player1">Objek pemain 1 (IPlayer).</param>
	/// <param name="player2">Objek pemain 2 (IPlayer).</param>
	/// <returns>Status pemain, atau 0 jika pemain tidak ditemukan.</returns>
	public PlayerStatus GetStatus(IPlayer player)
	{
		if (_players.ContainsKey(player))
		{
			return _players[player].Status;
		}
		else
		{
			throw new InvalidOperationException("Pemain tidak ditemukan dalam permainan.");
		}
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
			if (Math.Abs(to.X - from.X) == 2 && Math.Abs(to.Y - from.Y) == 2)
			{
				Position middle = new Position { X = (from.X + to.X) / 2, Y = (from.Y + to.Y) / 2 };
				Piece capturedPiece = _board.GetPieceAt(middle);
				
				if (capturedPiece != null)
				{
					// Hapus piece yang dimakan dari papan
					_board.SetPieceAt(middle, null);

					// Hapus piece yang dimakan dari pemiliknya
					foreach (var playerData in _players.Values)
					{
						if (playerData.GetPieces().Contains(capturedPiece))
						{
							playerData.RemovePiece(capturedPiece.pieceId);
							break; // Keluar dari loop setelah menemukan dan menghapus bidak
						}
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
	public void CheckWinCondition() 
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
				break;
			}
		}
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
		int deltaX = to.X - from.X;
		int deltaY = to.Y - from.Y;

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
				Position middle = new Position { X = from.X + deltaX / 2, Y = from.Y + deltaY / 2 };
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
				Position middle = new Position { X = from.X + deltaX / 2, Y = from.Y + deltaY / 2 };
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
		if ((piece.Colour == PieceColour.White && piece.Position.Y == 7) ||
			(piece.Colour == PieceColour.Black && piece.Position.Y == 0)) 
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
		for (int y = 0; y < Board.BoardSize; y++)
		{
			for (int x = 0; x < Board.BoardSize; x++)
			{
				Position newPosition = new Position { X = x, Y = y };
				if (IsValidMove(piece, currentPosition, newPosition))
				{
					validMoves.Add(newPosition);
				}
			}
		}
		return validMoves;
	}
	#endregion

	public PlayerData GetPlayerData(IPlayer player)
	{
		if (_players.ContainsKey(player))
		{
			return _players[player];
		}
		throw new InvalidOperationException("Pemain tidak ditemukan.");
	}

}
