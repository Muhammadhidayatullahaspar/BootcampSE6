using Project12_EnumInt;
class Program
{
	static void Main()
	{
		int olahraga = (int)Sport.Football;
		Console.WriteLine(olahraga);

		Sport sport = (Sport)14;
		Console.WriteLine(sport);
		
	}
}