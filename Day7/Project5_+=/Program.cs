public delegate string Film();
class program
{
	static void Main()
	{
		Film mydel = Rating;
		Film mydel2 = Title;
		Film result = mydel + mydel2;

		Film mydelll = Rating;
		mydelll += Title;
		Console.WriteLine(mydelll());
	}

	static string Rating()
	{
		return "7";
	}
	static string Title()
	{
		return "Superman";
	}
}