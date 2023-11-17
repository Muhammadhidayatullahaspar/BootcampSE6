using Project2_Log4net;
using log4net;
using log4net.Config;
class Program
{
	
	private static readonly ILog logger = LogManager.GetLogger(typeof(Program));
	static void Main()
	{
		XmlConfigurator.Configure(new FileInfo("log4net.config"));
		logger.Debug("This is a debug message");
		logger.Info("This is an info message");
		logger.Warn("This is a warning message");
		logger.Error("This is an error message");
		logger.Fatal("This is a fatal message");
		Film.Message("This is GAMERUNNER");
	}
}