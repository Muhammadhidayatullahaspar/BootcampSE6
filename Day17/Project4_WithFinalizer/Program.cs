using System;
using System.Diagnostics;
using Project4_WithFinalizer;
using System;
class Program
{
	static void Main(string[] args)
	{
		Stopwatch sw = new Stopwatch();
		sw.Start();
		for (int i = 0; i <100000; i++)
		{
			Jupiter jupiter = new Jupiter();
			Moon moon = new Moon();
			Sun sun = new Sun();
			
		}
		GC.WaitForPendingFinalizers();
		sw.Stop();
		Console.WriteLine("Elapsed time: " + sw.ElapsedMilliseconds);
		Console.Read();
	}
}