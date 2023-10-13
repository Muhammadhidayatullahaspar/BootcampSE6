using System.Diagnostics;
class program
{
	static void Main()
	{
		stopwatch timer = new Stopwatch();
		string food = string.Empty;
		timer.Start();
		for (int i = 0; i < 1000; i++)
		{
			food.Append("pesan 1");
			food.Append("pesan 2");
			food.Append("itu saja");
		}
		stopwatch.Stop();
	}
}