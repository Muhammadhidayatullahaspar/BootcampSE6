namespace Project7_ExtensionMethod;

public static class MyPrint
{
	public static void Print(this object input) 
	{
		Console.WriteLine(input);
	}
	public static bool Dibandingkan(this int a, int b) {
		return a > b;
	}
}
