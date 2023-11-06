using System;
using System.Threading;
class Program
{
	static void Main()
	{
		Thread thread1 = new Thread(beli)
		{
			IsBackground = false
		};
		Console.WriteLine($"thread1 is background {thread1.IsBackground}");
		thread1.Start();
		thread1.Join();
		Thread.Sleep(1000);
		Console.WriteLine("thread utama telah berakhir");
	}
	static void beli()
	{
		Console.WriteLine("thread beli telah berjalan");
	}
}