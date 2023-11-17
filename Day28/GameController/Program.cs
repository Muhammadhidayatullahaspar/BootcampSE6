using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using MyGame;

partial class Program
{
	static void Main()
	{
		//NoLog();
		ManualCreation();
		DependencyInjection();
	}
	static void NoLog()
	{
		IPlayer player = new Player("player1");
		IBoard board = new Board(2);
		GameController game = new GameController(player, board);
	}
}


