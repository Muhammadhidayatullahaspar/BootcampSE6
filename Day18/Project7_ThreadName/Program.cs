using System;
using System.Threading;
class Program
{
	static void Main()
	{
		Thread thread1 = new Thread(Fruit1);
		Thread thread2 = new Thread(Fruit2);
		thread1.Name = "Fresh Fruit";
		thread2.Name = "Expired fruit";
		
		thread2.Start(); 
		thread1.Start();
		
		thread1.Join();
		thread2.Join();

		Console.WriteLine("thread utama telah berakhir");
	}
	static void Fruit1()
	{
		Console.WriteLine("thread yang menjalankan buah segar telah berjalan");
		Thread.Sleep(20000);
		Console.WriteLine("thread buah segar telah selesai dijalankan");
	}
	static void Fruit2()
	{
		Console.WriteLine("thread yang menjalankan buah tidak segar telah berjalan");
		Thread.Sleep(30000);
		Console.WriteLine("thread buah tidak segar telah selesai dijalankan");
	}
}