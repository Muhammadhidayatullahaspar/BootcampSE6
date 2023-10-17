public delegate string MyDelegate(); //wadah dari method

class Program
{
	static void Main()
	{
		MyDelegate myDelegate = Martabak;
		myDelegate += Manis;

		string result = myDelegate(); //Invoke
		Console.WriteLine(result); //
	}
	static string Martabak()
	{
		return "Martabak";
	}
	static string Manis()
	{
		return "Manis";
	}
}