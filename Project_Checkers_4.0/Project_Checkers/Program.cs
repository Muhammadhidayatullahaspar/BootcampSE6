using Project_Checkers;
using System.Text;
using System.Collections.Generic;

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
        DisplayPlayerStatus(player1, statusPlayer1, player2, statusPlayer2);
		#endregion


	}
	#region Tampilan Informasi Papan
	/// <summary>
	/// Menampilkan informasi papan permainan ke konsol 
	/// </summary>
	/// <param name="boardDisplay">Data tampilan papan permainan dalam bentuk daftar tupel.</param>
	public static void DisplayBoardInfo(List<(int Row, int Col, int? PieceId, string Colour, string PieceType, bool IsEmpty)> boardDisplay)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("Papan Permainan:");

		foreach (var info in boardDisplay)
		{
			if (info.IsEmpty)
			{
				// Menambahkan informasi jika kosong
				stringBuilder.AppendLine($"Posisi ({info.Row}, {info.Col}): Kosong");
			}
			else
			{
				// Menambahkan informasi jika terdapat piece pada papan
				stringBuilder.AppendLine($"Posisi ({info.Row}, {info.Col}): Piece ID {info.PieceId}, Colour {info.Colour}, Type {info.PieceType}");
			}
		}

		// tuils ke consol
		Console.WriteLine(stringBuilder.ToString());
	}

	#endregion
	
	#region Tampilkan informasi piece pemain
	/// <summary>
	/// Menampilkan informasi piece pemain
	/// </summary>
	/// <param name="playerPieces">Data tampilan piece pemain dalam bentuk daftar tupel.</param>
	static void DisplayPlayerPiecesInfo(List<(int PieceId, string Colour, string PieceType)> playerPieces)
	{
		StringBuilder stringBuilder2 = new StringBuilder();

		foreach (var pieceInfo in playerPieces)
		{
			stringBuilder2.AppendLine($"ID: {pieceInfo.PieceId}, Colour: {pieceInfo.Colour}, Type: {pieceInfo.PieceType}");
		}
		
		Console.WriteLine(stringBuilder2.ToString());
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
		// Membuat string builder untuk mengonkatenasi informasi status pemain
		StringBuilder stringBuilderStatus = new StringBuilder();

		// Menambahkan informasi status pemain pertama
		stringBuilderStatus.AppendLine($"Status {player1.GetName()}: {statusPlayer1}");
		// Menambahkan informasi status pemain kedua
		stringBuilderStatus.AppendLine($"Status {player2.GetName()}: {statusPlayer2}");

		// Menampilkan informasi status pemain ke konsol
		Console.WriteLine(stringBuilderStatus.ToString());
	}
	#endregion

}
