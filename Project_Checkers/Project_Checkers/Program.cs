using Project_Checkers;
class Program
{
	static void Main(string[] args)
	{
		#region InputNamePlayers
		// Membuat dua pemain dengan nama yang bisa diinput
		Console.WriteLine("Masukkan nama pemain 1: ");
		string playerName1 = Console.ReadLine();
		Console.WriteLine("Masukkan nama pemain 2: ");
		string playerName2 = Console.ReadLine();
		Console.WriteLine($"Halo {playerName1} dan {playerName2} selamat bermain \n");
		IPlayer player1 = new Player(playerName1, 1);
		IPlayer player2 = new Player(playerName2, 2);
		#endregion
		
		#region InstanceGameController
		// Membuat instance GameController
		GameController gameController = new GameController(player1, player2);
		#endregion
		gameController.DisplayPlayerPieces(player1); // Menampilkan piece pemain  (Putih)
		gameController.DisplayPlayerPieces(player2); // Menampilkan piece pemain 2 (Hitam)
		// Tampilkan papan permainan
		gameController.DisplayBoard();
	}
}
