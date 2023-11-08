using Project_Checkers;
class Program
{
	static void Main(string[] args)
	{
		// Membuat dua pemain dengan nama yang bisa diinput
		Console.WriteLine("Masukkan nama pemain 1: ");
		string playerName1 = Console.ReadLine();
		Console.WriteLine("Masukkan nama pemain 2: ");
		string playerName2 = Console.ReadLine();
		IPlayer player1 = new Player(playerName1, 1);
		IPlayer player2 = new Player(playerName2, 2);
		// Membuat instance GameController
		GameController gameController = new GameController(player1, player2);
		// Mendapatkan daftar pemain dari GameController
		List<IPlayer> players = gameController.GetPlayers();
		// Menggunakan metode GetPieces untuk mendapatkan daftar bidak pemain 1 (Player 1)
		List<Piece> piecesPlayer1 = gameController.GetPieces(0);
		// Menggunakan metode GetPieces untuk mendapatkan daftar bidak pemain 2 (Player 2)
		List<Piece> piecesPlayer2 = gameController.GetPieces(1);

		// Menampilkan daftar bidak awal
		Console.WriteLine("Daftar Bidak Awal (Player 1 - Putih):");
		foreach (var piece in piecesPlayer1)
		{
			Console.WriteLine("ID: " + piece.idPiece + ", Colour: " + piece.colour + ", Type: " + piece.type);
		}
		Console.WriteLine("Daftar Bidak Awal (Player 2 - Hitam):");
		foreach (var piece in piecesPlayer2)
		{
			Console.WriteLine("ID: " + piece.idPiece + ", Colour: " + piece.colour + ", Type: " + piece.type);
		}
		
		List<Piece> allPieces = gameController.GetPieces(); // semua piece yang berada di papan
		Console.WriteLine("semua bidak yang berada dipapan");
		foreach (var piece in allPieces)
		{
			Console.WriteLine("ID: " + piece.idPiece + ", Colour: " + piece.colour + ", Type: " + piece.type);
		}
		
	}
}
