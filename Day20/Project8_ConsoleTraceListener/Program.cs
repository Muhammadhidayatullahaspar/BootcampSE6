using System.Diagnostics;

namespace MyNamespace
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleTraceListener consoleTraceListener = new ConsoleTraceListener();
			Trace.Listeners.Add(consoleTraceListener);

			Trace.WriteLine("Starting program");

			int x = 5;
			int y = 10;

			Trace.WriteLine($"x = {x}, y = {y}");

			int sum = x + y;

			Trace.WriteLine($"The sum of {x} and {y} is {sum}");

			Trace.WriteLine("Program complete");
		}
	}
}