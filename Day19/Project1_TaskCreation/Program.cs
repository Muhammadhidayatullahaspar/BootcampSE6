using System;
using System.Threading.Tasks;
class Program
{
	static void Main()
	{
		Task task = new Task(beli);
		task.Start();
	}
	static void beli()
	{
		Console.WriteLine("coba beli");
	}
}