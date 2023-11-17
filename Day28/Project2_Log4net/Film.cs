using log4net;

namespace Project2_Log4net;

public class Film
{
	private static readonly ILog logger = LogManager.GetLogger(typeof(Film));
	public static void Message(string args) 
		{
			logger.Info(args);
		}
}
