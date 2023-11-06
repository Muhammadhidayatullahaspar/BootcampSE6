using System;
using System.Diagnostics;
using System.Threading;

public static class Program
{
	public static void Main()
	{
		Console.WriteLine("Starting program.");
		var stopwatch = new Stopwatch();
		stopwatch.Start();

		Thread thread1 = new Thread(DoTaskOne);
		Thread thread2 = new Thread(DoTaskTwo);
		
		thread1.Start();
		thread2.Start();

		thread1.Join();
		thread2.Join();

		stopwatch.Stop();

		Console.WriteLine($"Program complete. Elapsed time: {stopwatch.ElapsedMilliseconds}ms");
	}

	public static void DoTaskOne()
	{
		Console.WriteLine("Starting task 1.");
		string x = "Hello";
		for (int i = 0; i < 100000; i++)
		{
			x += i + " ";
		}
		Console.WriteLine("Task 1 complete.");
	}

	public static void DoTaskTwo()
	{
		Console.WriteLine("Starting task 2.");
		string x = "Hello";
		for (int i = 0; i < 100000; i++)
		{
			x += i + " ";
		}
		Console.WriteLine("Task 2 complete.");
	}
}