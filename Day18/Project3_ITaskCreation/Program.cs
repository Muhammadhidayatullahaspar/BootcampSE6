using System;
using System.Threading.Tasks;

class Program
{
	static void Main()
	{
		Task task = new Task(() => Console.WriteLine("Hello, Task!"));
		TaskStatus x = task.Status;
		task.Start(); //Thread.Start();

		task.Wait(); //Thread.Join();
	}
}