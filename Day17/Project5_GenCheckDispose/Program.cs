using System;
using System.Diagnostics;
using Project5_GenCheckDispose;
using System;
class Program
{
	static void Main(string[] args)
	{
		Stopwatch sw = new Stopwatch();
		sw.Start();
		for (int i = 0; i <100000; i++)
		{
			Comedy comedy = new Comedy();
			Horor horor = new Horor();
			Romance romance = new Romance();
			
		}
		sw.Stop();
		Console.WriteLine("Elapsed time: " + sw.ElapsedMilliseconds);
		Console.Read();
	}
}