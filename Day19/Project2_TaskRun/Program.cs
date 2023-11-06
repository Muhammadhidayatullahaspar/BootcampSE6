using System;
using System.Threading.Tasks;

class Program
{
	static void Main()
	{
		Task task = new Task(() => Console.WriteLine("Hello, Task Start!"));
		task.Start();
		task.Wait(); 

		Task task1 = Task.Run(() => Console.WriteLine("Superman"));
		task1.Wait(); 
		
		Task.Run(() => Console.WriteLine("Batman")); 
	}
}