using stuff;
class Program
{
	static void Main()
	{
		GlassPlastic baru = new();
		Console.WriteLine(baru.width);
	
		Glass gelas = new GlassPlastic();
		Console.WriteLine(gelas.Age);
	}
}  