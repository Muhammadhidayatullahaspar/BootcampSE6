using System;
class Program
{
	static void Main(string[] args)
	{
		float[] largeArray = new float[100*1024]; // 400kb
		Console.WriteLine("Large object allocated on LOH");
		Console.ReadKey();
	}
}