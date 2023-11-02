using System;
using System.Diagnostics;
using Project3_GenCheckWithoutFinalizers;
using System;
class Program
{
	static void Main(string[] args)
	{
		Stopwatch sw = new Stopwatch();
		sw.Start();
		for (int i = 0; i <100000; i++)
		{
			Cat cat = new Cat();
			Lion lion = new Lion();
			Shark shark = new Shark();
			
		}
		sw.Stop();
		Console.WriteLine("Elapsed time: " + sw.ElapsedMilliseconds);
		Console.Read();
	}
}