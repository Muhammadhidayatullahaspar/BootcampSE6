class Program
{
	static void Main()
	{
		var method = (int x, int y) =>
		{
			return x + y;
		};
	
		var printer = (object x) => Console.WriteLine(x);
		var makan = () => Console.WriteLine("Durian");
	
		printer(30);
		int result = method(3,4);
		Console.WriteLine(result);
	}
	
int Add(int x, int y) {
	return x + y;
}

int Add2 (int x, int y) => x+y;
}