class Program
{
	static void Main()
	{
		Console.WriteLine("Program start");
		int x = 0;
		try
		{
			Caller(ref x);
		}
		catch (Exception e)
		{
			Console.WriteLine("Error: " + e.Message); 
		}
		finally
		{
			Console.WriteLine("Program resources removed");
		}
	}
	static void Caller(ref int x)
	{
		Console.WriteLine("Caller called");
		int a = int.Parse(Console.ReadLine());
		int b = int.Parse(Console.ReadLine());
		x = a/b;
		Console.WriteLine("Caller finished");
	}
}