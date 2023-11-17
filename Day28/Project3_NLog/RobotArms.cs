using NLog;

namespace NLogTest
{
	public class RobotArm
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();
		
		public void Connect()
		{
			logger.Debug("Connecting to robot arm");
			// Code to connect to robot arm
		}

		public void MoveTo(int x, int y, int z)
		{
			logger.Trace($"Moving robot arm to ({x}, {y}, {z})");
			// Code to move robot arm to specified position
		}

		public void Grab()
		{
			logger.Trace("Grabbing object with robot arm");
			// Code to grab object with robot arm
		}

		public void Release()
		{
			logger.Trace("Releasing object with robot arm");
			// Code to release object with robot arm
		}

		public void Disconnect()
		{
			logger.Info("Disconnecting from robot arm");
			// Code to disconnect from robot arm
		}
	}
}