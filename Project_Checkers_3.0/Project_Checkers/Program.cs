using Project_Checkers;

class Program
{
	static void Main(string[] args)
	{
		#region InputNamePlayers
		// Membuat dua pemain dengan nama yang bisa diinput
		Console.WriteLine("Masukkan nama pemain 1, bermain sebagai white: ");
		string playerName1 = Console.ReadLine();
		Console.WriteLine("Masukkan nama pemain 2, bermain sebagai black : ");
		string playerName2 = Console.ReadLine();
		Console.WriteLine($"Halo {playerName1} dan {playerName2} selamat bermain \n");
		IPlayer player1 = new Player(playerName1, 1);
		IPlayer player2 = new Player(playerName2, 2);
		#endregion
		
		#region InstanceGameController
		// Membuat instance GameController
		GameController gameController = new GameController(player1, player2);
		#endregion

		#region tampikan info piece pemain
		// Menampilkan informasi piece pemain 1
		Console.WriteLine($"Informasi Piece Player {playerName1}:");
		var player1Pieces = gameController.GetPlayerPiecesDisplay(player1);
		DisplayPlayerPiecesInfo(player1Pieces);

		// Menampilkan informasi piece pemain 2
		Console.WriteLine($"Informasi Piece Player {playerName2}:");
		var player2Pieces = gameController.GetPlayerPiecesDisplay(player2);
		DisplayPlayerPiecesInfo(player2Pieces);
		#endregion
		
		#region tampilkan papan permainan
		// Tampilkan papan permainan
		DisplayBoardInfo(gameController.GetBoardDisplay());
		#endregion
		
		#region cek status pemain
		PlayerStatus statusPlayer1 = gameController.GetStatus(player1, player2);
		PlayerStatus statusPlayer2 = gameController.GetStatus(player2, player1);
		Console.WriteLine($"Status {player1.GetName()}: {statusPlayer1}");
		Console.WriteLine($"Status {player2.GetName()}: {statusPlayer2}");
		#endregion


	}
	#region Tampilan Informasi Papan
	/// <summary>
	/// Tampilkan infonya papan permainan yang ada id piece, color, dan tipenya apa
	/// </summary>
	/// <param name="boardDisplay">Data tampilan papan permainan dalam bentuk daftar tupel.</param>
	static void DisplayBoardInfo(List<(int Row, int Col, int? PieceId, string Colour, string PieceType, bool IsEmpty)> boardDisplay)
	{
		Console.WriteLine("Papan Permainan:");

		foreach (var info in boardDisplay)
		{
			if (info.IsEmpty)
			{
				Console.WriteLine($"Posisi ({info.Row}, {info.Col}): Kosong");
			}
			else
			{
				Console.WriteLine($"Posisi ({info.Row}, {info.Col}): Piece ID {info.PieceId}, Colour {info.Colour}, Type {info.PieceType}");
			}
		}

		Console.WriteLine();
	}
	#endregion
	
	#region Tampilkan informasi piece pemain
	/// <summary>
	/// Menampilkan informasi piece pemain
	/// </summary>
	/// <param name="playerPieces">Data tampilan piece pemain dalam bentuk daftar tupel.</param>
	static void DisplayPlayerPiecesInfo(List<(int PieceId, string Colour, string PieceType)> playerPieces) // Metode untuk menampilkan informasi piece pemain
	{
		foreach (var pieceInfo in playerPieces)
		{
			Console.WriteLine($"ID: {pieceInfo.PieceId}, Colour: {pieceInfo.Colour}, Type: {pieceInfo.PieceType}");
		}
		Console.WriteLine();
	}	
	#endregion
}
