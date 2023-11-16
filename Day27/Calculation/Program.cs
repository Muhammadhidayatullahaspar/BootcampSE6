
namespace Calculation 
{
    internal class Program 
	{
		static void Main(string[] args) 
		{
			NumberCalculation numberCalc = new();
			int a = 10;
			int b = 12;

			Console.WriteLine($"Addition of {a} and {b} is {numberCalc.Add(a, b)}");
			Console.WriteLine($"Subtraction of {a} and {b} is {numberCalc.Subtract(a, b)}");
			Console.WriteLine($"Multiplication of {a} and {b} is {numberCalc.Multiply(a, b)}");
			Console.WriteLine($"Division of {a} and {b} is {numberCalc.Divide(a, b)}");
		}
	}
	
	public class NumberCalculation
	{
		public int Add(int a, int b) 
		{
			return a + b;
		}
		public int Multiply(int a, int b) 
		{
			return a * b;
		}
		public int Subtract(int a, int b) 
		{
			return a - b;
		}
		public int Divide(int a, int b) 
		{
			return a / b;
		}
	}
}