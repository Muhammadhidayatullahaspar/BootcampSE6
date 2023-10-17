public delegate void MyDelegate(); //wadah dari method

class Program {
	static void Main() {
		MyDelegate myDelegate = Printer;
		myDelegate += Layangan;
		myDelegate += Printer2;
		myDelegate += Layangan2;
		
		myDelegate(); //Invoke
	}
	static void Printer() {
		Console.WriteLine("Printer");
	}
	static void Layangan() {
		Console.WriteLine("Layangan");
	}
	static void Printer2()
	{
		Console.WriteLine("Printer2");
	}
	static void Layangan2()
	{
		Console.WriteLine("Layangan2");
	}
}