public delegate int MyDelegate(int left, int right); //wadah dari method

class Program
{
	static void Main()
	{
		MyDelegate myDelegate = Add;
		myDelegate += Divide;

		int result = myDelegate(10,5); //Invoke
		Console.WriteLine(result);
	}
	static int Add(int left, int right)
	{
		return left/right;
	}
	static int Divide(int left, int right)
	{
		return left/right;
	}
}