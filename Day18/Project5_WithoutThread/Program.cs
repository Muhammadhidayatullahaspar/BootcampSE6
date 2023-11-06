using System;
using System.Diagnostics;
public static class Program
{
	public static void Main()
	{
		Console.WriteLine("program telah dimulai");
		var stopwatch = new Stopwatch();
		stopwatch.Start();
		DoTasks1();
		DoTasks2();
		stopwatch.Stop();
		Console.WriteLine($"program telah berakhir dengan waktu : {stopwatch.ElapsedMilliseconds}ms");
	}
	public static void DoTasks1()
		{
			Console.WriteLine("program pertama telah dimulai");
			string x = "hello";
			for (int i = 0; i <100000;i++)
			{
				x += " ";
			}
			Console.WriteLine("Task1 telah selesai");
		}
		public static void DoTasks2()
		{
			Console.WriteLine("program kedua telah dimulai");
			string x = "hello";
			for (int i = 0; i < 100000;i++)
			{
				x += " ";
			}
			Console.WriteLine("Task2 telah selesai");
		}
}