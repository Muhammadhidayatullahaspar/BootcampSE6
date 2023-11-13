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
		// Tampilkan informasi piece pemain
		Console.WriteLine($"Informasi Piece Player {player1.Name}:");
		var player1PiecesInfo = gameController.GetPlayerPiecesDisplay(player1);
		DisplayPlayerPiecesInfo(player1PiecesInfo);

		Console.WriteLine($"Informasi Piece Player {player2.Name}:");
		var player2PiecesInfo = gameController.GetPlayerPiecesDisplay(player2);
		DisplayPlayerPiecesInfo(player2PiecesInfo);
		#endregion
		
		#region tampilkan papan permainan
		// Tampilkan papan permainan
		List<(int PositionBoard, int? PieceId, string Colour, string PieceType, bool IsEmpty, int? IdField)> boardDisplay = gameController.GetBoardDisplay();
		// Menampilkan informasi papan permainan
		DisplayBoardInfo(boardDisplay);
		#endregion
		
		#region cek status pemain
		PlayerStatus statusPlayer1 = gameController.GetStatus(player1, player2);
		PlayerStatus statusPlayer2 = gameController.GetStatus(player2, player1);
		DisplayPlayerStatus(player1, statusPlayer1, player2, statusPlayer2);
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
			if (pieceToMove == null || pieceToMove.Player != currentPlayer)
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
				gameController.CheckGameStatus();
				// Cek status pemain setelah gerakan
				var statusPlayer1AfterMove = gameController.GetStatus(player1, player2);
				var statusPlayer2AfterMove = gameController.GetStatus(player2, player1);

				if (statusPlayer1AfterMove == PlayerStatus.Win || statusPlayer2AfterMove == PlayerStatus.Win)
				{
					Console.WriteLine("Permainan berakhir!");
					DisplayPlayerStatus(player1, statusPlayer1AfterMove, player2, statusPlayer2AfterMove);
					break;
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
	static void DisplayBoardInfo(List<(int PositionBoard, int? PieceId, string Colour, string PieceType, bool IsEmpty, int? IdField)> boardDisplay)
	{
		Console.WriteLine("Papan Permainan:");

		foreach (var info in boardDisplay)
		{
			if (info.IsEmpty)
			{
				// Periksa apakah IdField tidak null sebelum menampilkannya
				string idFieldDisplay = info.IdField.HasValue ? $"Id Field {info.IdField}, " : "";
				Console.WriteLine($"Posisi Board {info.PositionBoard}, {idFieldDisplay}, Kosong");
			}
			else
			{
				// Periksa apakah IdField tidak null sebelum menampilkannya
				string idFieldDisplay = info.IdField.HasValue ? $"Id Field {info.IdField}, " : "";
				Console.WriteLine($"Posisi Board {info.PositionBoard}, {idFieldDisplay}Piece ID {info.PieceId}, Colour {info.Colour}, Type {info.PieceType}");
			}
		}

		Console.WriteLine();
	}


	#endregion
	
	#region Tampilkan informasi piece pemain
	/// <summary>
	/// Menampilkan informasi piece pemain berdasarkan data yang diberikan.
	/// </summary>
	/// <param name="playerPieces">Data informasi piece pemain.</param>
	static void DisplayPlayerPiecesInfo(List<(int PieceId, string Colour, string PieceType)> playerPieces)
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
	{
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
		return position.y * 8 + position.x + 1;
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
		int x = boardPosition % 8;
		int y = boardPosition / 8;
		return new Position { x = x, y = y };
	}
	#endregion

}
