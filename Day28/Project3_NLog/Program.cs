using NLog;

namespace NLogTest
{
	public class Program
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		static void Main()
		{
			//var currentDirectory = Directory.GetCurrentDirectory();
            //var nlogConfigPath = Path.Combine(currentDirectory, "nlog.config");
			//LogManager.LoadConfiguration(nlogConfigPath);

			logger.Info("Starting robot arm program");

			int i = 0;
			RobotArm arm = new RobotArm();
			// while (i < 10000)
			// {
			// 	arm.Connect();
			// 	arm.MoveTo(0, 0, 0);
			// 	arm.Grab();
			// 	arm.MoveTo(10, 10, 10);
			// 	arm.Release();
				arm.Disconnect();
				i++;
			//}

			logger.Info("Robot arm program finished");
		}
	}
}