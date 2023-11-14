using Project_Checkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
	static void Main()
	{
		#region InputNamePlayers
		// Membuat dua pemain dengan nama yang bisa diinput
		 Console.WriteLine("Masukkan nama pemain 1, bermain sebagai white: ");
		string playerName1 = Console.ReadLine();
		if (string.IsNullOrEmpty(playerName1))
		{
			throw new ArgumentException("Nama pemain 1 tidak boleh kosong.");
		}

		Console.WriteLine("Masukkan nama pemain 2, bermain sebagai black: ");
		string playerName2 = Console.ReadLine();
		if (string.IsNullOrEmpty(playerName2))
		{
			throw new ArgumentException("Nama pemain 2 tidak boleh kosong.");
		}

		IPlayer player1 = new Player(playerName1, 1);
		IPlayer player2 = new Player(playerName2, 2);
		if (player1 == null || player2 == null)
		{
			throw new InvalidOperationException("Gagal menginisialisasi pemain.");
		}
		#endregion
		
		#region InstanceGameController
		GameController gameController = new GameController(player1, player2);
		#endregion

		#region Tampilkan Info Piece Pemain
		// Dapatkan informasi piece pemain
		List<PlayerPieceInfo> player1PiecesInfo = gameController.GetPlayerPiecesDisplay(player1);
		List<PlayerPieceInfo> player2PiecesInfo = gameController.GetPlayerPiecesDisplay(player2);

		// Tampilkan informasi piece pemain
		Console.WriteLine($"Informasi Piece Player {player1.Name}:");
		DisplayPlayerPiecesInfo(player1PiecesInfo);

		Console.WriteLine($"Informasi Piece Player {player2.Name}:");
		DisplayPlayerPiecesInfo(player2PiecesInfo);

		#endregion
		
		#region tampilkan papan permainan
		// Dapatkan informasi tampilan papan permainan
		List<BoardDisplayInfo> boardDisplay = gameController.GetBoardDisplay();
		
		// Menampilkan informasi papan permainan
		DisplayBoardInfo(boardDisplay);
		#endregion
		
		#region cek status pemain
		try
		{
			PlayerStatus statusPlayer1 = gameController.GetStatus(player1);
			PlayerStatus statusPlayer2 = gameController.GetStatus(player2);
			DisplayPlayerStatus(player1, statusPlayer1, player2, statusPlayer2);
		}
		catch (InvalidOperationException ex)
		{
			Console.WriteLine($"Error: {ex.Message}");
		}
		#endregion

		#region logika permainan
		IPlayer currentPlayer = player1; // Mulai dari player1	
		while (true)
		{
			Console.WriteLine($"Giliran {currentPlayer.Name}. Masukkan ID Piece yang ingin dipindahkan (atau masukkan -1 untuk keluar): ");
			if (!int.TryParse(Console.ReadLine(), out int pieceId) || pieceId == -1)
			{
				break;
			}

			Piece pieceToMove = FindPieceById(gameController, player1, player2, pieceId);

			// Periksa apakah bidak milik pemain yang sedang bergerak
			if (pieceToMove == null || !IsPieceBelongsToPlayer(pieceToMove, gameController.GetPlayerData(currentPlayer)))
			{
				Console.WriteLine("Piece tidak ditemukan atau bukan giliran piece ini.");
				continue;
			}

			Console.WriteLine("Gerakan yang valid untuk Piece ID " + pieceId + ":");
			var validMoves = gameController.GetValidMovesForPiece(pieceToMove, pieceToMove.Position);
			if (validMoves.Count == 0)
			{
				Console.WriteLine("Tidak ada gerakan yang valid untuk piece ini.");
				continue;
			}

			foreach (var move in validMoves)
			{
				Console.WriteLine($"- Posisi Board {GetBoardPosition(move)}");
			}

			Console.WriteLine("Pilih gerakan dengan memasukkan posisi board (1-64): ");
			if (!int.TryParse(Console.ReadLine(), out int boardPosition) || !IsValidBoardPosition(boardPosition))
			{
				Console.WriteLine("Posisi board tidak valid.");
				continue;
			}

			Position newPosition = GetPositionFromBoard(boardPosition);
			if (gameController.MovePiece(pieceToMove.Position, newPosition))
			{
				Console.WriteLine("Piece berhasil dipindahkan.");

				// Tampilkan papan permainan terbaru
				var boardDisplayAfterMove = gameController.GetBoardDisplay();
				DisplayBoardInfo(boardDisplayAfterMove);
				 try
				{
					// Periksa kondisi kemenangan setelah setiap gerakan
				gameController.CheckWinCondition();

				// Dapatkan status pemain setelah gerakan
				PlayerStatus statusPlayer1 = gameController.GetStatus(player1);
				PlayerStatus statusPlayer2 = gameController.GetStatus(player2);

				// Periksa apakah salah satu pemain telah menang
				if (statusPlayer1 == PlayerStatus.Win || statusPlayer2 == PlayerStatus.Win)
				{
					Console.WriteLine("Permainan berakhir!");
					DisplayPlayerStatus(player1, statusPlayer1, player2, statusPlayer2);
					break; // Keluar dari loop permainan
				}
				}
				catch (InvalidOperationException ex)
				{
					Console.WriteLine($"Error: {ex.Message}");
				}
				// Ganti giliran
				currentPlayer = currentPlayer == player1 ? player2 : player1;
			}
			else
			{
				Console.WriteLine("Gerakan tidak valid.");
			}
		}
		#endregion
	}
	
	#region Tampilan Informasi Papan
	/// <summary>
	/// Menampilkan informasi papan permainan berdasarkan data yang diberikan.
	/// </summary>
	/// <param name="boardDisplay">Data display papan permainan.</param>
	static void DisplayBoardInfo(List<BoardDisplayInfo> boardDisplay)
	{
		Console.WriteLine("Papan Permainan Checkers:");
		Console.WriteLine("   +-------+-------+-------+-------+-------+-------+-------+-------+");

		for (int row = 0; row < Board.BoardSize; row++)
		{
			// Baris untuk posisi board
			Console.Write("   |");
			for (int col = 0; col < Board.BoardSize; col++)
			{
				int position = row * Board.BoardSize + col + 1;
				Console.Write($" {position:D2}    |");
			}
			Console.WriteLine();

			// Baris untuk ID piece
			Console.Write("   |");
			for (int col = 0; col < Board.BoardSize; col++)
			{
				var currentInfo = boardDisplay.FirstOrDefault(info => info.PositionBoard == (row * Board.BoardSize + col + 1));
				string pieceIdDisplay = currentInfo != null && !currentInfo.IsEmpty ? $"{currentInfo.PieceId:D2}" : "  ";
				Console.Write($" {pieceIdDisplay}    |");
			}
			Console.WriteLine();

			// Baris untuk warna dan tipe bidak
			Console.Write($" {row + 1} |"); // Nomor baris
			for (int col = 0; col < Board.BoardSize; col++)
			{
				var currentInfo = boardDisplay.FirstOrDefault(info => info.PositionBoard == (row * Board.BoardSize + col + 1));
				string pieceMarker = currentInfo != null && !currentInfo.IsEmpty ? $"{currentInfo.Colour[0]}{currentInfo.PieceType[0]}" : "  ";
				Console.Write($" {pieceMarker}    |");
			}
			Console.WriteLine();

			Console.WriteLine("   +-------+-------+-------+-------+-------+-------+-------+-------+");
		}

		Console.WriteLine("     A       B       C       D       E       F       G       H  "); // Label kolom
	}

	#endregion
	
	#region Tampilkan informasi piece pemain
	/// <summary>
	/// Menampilkan informasi piece pemain berdasarkan data yang diberikan.
	/// </summary>
	/// <param name="playerPieces">Data informasi piece pemain.</param>
	static void DisplayPlayerPiecesInfo(List<PlayerPieceInfo> playerPieces)
	{
		if (playerPieces.Count == 0)
		{
			Console.WriteLine("Tidak ada piece.");
			return;
		}

		foreach (var pieceInfo in playerPieces)
		{
			Console.WriteLine($"ID: {pieceInfo.PieceId}, Colour: {pieceInfo.Colour}, Type: {pieceInfo.PieceType}");
		}
	}

	#endregion

	#region Tampilan Status Pemain
	/// <summary>
	/// Menampilkan status pemain ke konsol berdasarkan objek pemain dan status yang diberikan.
	/// </summary>
	/// <param name="player1">Objek pemain (IPlayer) pertama.</param>
	/// <param name="statusPlayer1">Status pemain pertama (PlayerStatus).</param>
	/// <param name="player2">Objek pemain (IPlayer) kedua.</param>
	/// <param name="statusPlayer2">Status pemain kedua (PlayerStatus).</param>
	public static void DisplayPlayerStatus(IPlayer player1, PlayerStatus statusPlayer1, IPlayer player2, PlayerStatus statusPlayer2)
	{ // satu parameter saja  player, status
		StringBuilder stringBuilderStatus = new StringBuilder();
		stringBuilderStatus.AppendLine($"Status {player1.Name}: {statusPlayer1}");
		stringBuilderStatus.AppendLine($"Status {player2.Name}: {statusPlayer2}");
		Console.WriteLine(stringBuilderStatus.ToString());
	}
	#endregion

	#region Pencarian Piece berdasarkan Idpiece
	/// <summary>
	/// Mencari sebuah bidak berdasarkan ID dalam permainan catur.
	/// </summary>
	/// <param name="gameController">Controller permainan.</param>
	/// <param name="player1">Pemain 1.</param>
	/// <param name="player2">Pemain 2.</param>
	/// <param name="pieceId">ID bidak yang dicari.</param>
	/// <returns>Bidak yang ditemukan atau null jika tidak ditemukan.</returns>
	private static Piece FindPieceById(GameController gameController, IPlayer player1, IPlayer player2, int pieceId)
	{
		var piecesPlayer1 = gameController.GetPieces(player1);
		var piecesPlayer2 = gameController.GetPieces(player2);

		Piece foundPiece = piecesPlayer1.FirstOrDefault(p => p.pieceId == pieceId);
		if (foundPiece == null)
		{
			foundPiece = piecesPlayer2.FirstOrDefault(p => p.pieceId == pieceId);
		}
		
		return foundPiece;
	}
	#endregion

	#region Posisi Pada Papan chekers
	/// <summary>
	/// Mendapatkan posisi pada papan chekers berdasarkan koordinat baris dan kolom.
	/// </summary>
	/// <param name="position">Koordinat posisi pada papan.</param>
	/// <returns>Posisi pada papan shecker.</returns>
	private static int GetBoardPosition(Position position)
	{
		return position.Y * Board.BoardSize + position.X + 1;
	}
	#endregion

	#region Validasi Posisi Papan 
	/// <summary>
	/// Memeriksa apakah posisi pada papan chekers valid.
	/// </summary>
	/// <param name="boardPosition">Posisi pada papan chekers.</param>
	/// <returns>True jika posisi valid, false jika tidak.</returns>
	private static bool IsValidBoardPosition(int boardPosition)
	{
		return boardPosition >= 1 && boardPosition <= 64;
	}
	#endregion
	
	#region Konversi Posisi Board ke Posisi Papan checkers
	/// <summary>
	/// Mengkonversi posisi pada papan piece menjadi objek Position.
	/// </summary>
	/// <param name="boardPosition">Posisi pada papan chekers.</param>
	/// <returns>Objek Position yang sesuai dengan posisi pada papan chekers.</returns>
	private static Position GetPositionFromBoard(int boardPosition)
	{
		boardPosition--; // Mengurangi 1 karena papan dimulai dari 1 bukan 0
		int x = boardPosition % Board.BoardSize;
		int y = boardPosition / Board.BoardSize; // ini Board.BoardSize pakai board.gamesize
		return new Position { X = x, Y = y };
	}
	#endregion
	// Mencari bidak di dalam koleksi bidak pemain
	public static bool IsPieceBelongsToPlayer(Piece piece, PlayerData playerData)
    {
        return playerData.GetPieces().Contains(piece);
    }
}