using System;
using System.Threading.Tasks;
class Program
{
	static void Main()
	{
		Task task = Task.Run(()=> Console.WriteLine("task telah dijalankan"));
		task.Wait();
		Console.WriteLine($" status task apakah cancel atau tidak: {task.IsCanceled}");
		Console.WriteLine($" status task apakah gagal atau tidak: {task.IsFaulted}");
		Console.WriteLine($" status task apakah telah selesai atau tidak: {task.IsCompleted}");
	}
}