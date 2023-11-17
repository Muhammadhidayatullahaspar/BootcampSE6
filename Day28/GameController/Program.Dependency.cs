using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using MyGame;

partial class Program
{
	static void DependencyInjection()
	{
		var serviceCollection = new ServiceCollection();
		ConfigureServices(serviceCollection);
		
		var serviceProvider = serviceCollection.BuildServiceProvider();

		var player = serviceProvider.GetRequiredService<IPlayer>();
		var board = serviceProvider.GetRequiredService<IBoard>();
		var logger = serviceProvider.GetRequiredService<ILogger<GameController>>();
		var game = new GameController(player, board, logger);
	}

	private static void ConfigureServices(IServiceCollection services)
	{
		services.AddLogging(logBuilder =>
		{
			logBuilder.ClearProviders(); 
			logBuilder.SetMinimumLevel(LogLevel.Trace);
			logBuilder.AddNLog("nlog.config");
		});
		services.AddTransient<IPlayer>(provider => new Player("player1"));
		services.AddTransient<IBoard>(provider => new Board(2));
	}
}
