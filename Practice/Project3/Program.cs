class Program
{
	static void Main()
	{
		Calc calc = new Calc();
		int output = calc.Sum(5);
		Console.WriteLine(output);
	}
}
public class Calc
{
	public int Sum(int number)
	{
		number += 3;
		return number;
	}
}