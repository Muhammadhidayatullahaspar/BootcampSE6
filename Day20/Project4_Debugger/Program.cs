class Program
{
	
	static void Main()
	{
		double a = 5;
		double b = 10;
		double c = Divide(a,b);
		Console.WriteLine($"hasil dari pembagiaannya adalah {c}");
	}
	/// <summary>
	/// ini untuk membagi bilangan
	/// </summary>
	/// <param name="a untuk bilangan pertama"></param>
	/// <param name="b untuk bilangan kedua"></param>
	/// <returns></returns>
	static double Divide(double a, double b)
	{
		return a + b;
	}
}