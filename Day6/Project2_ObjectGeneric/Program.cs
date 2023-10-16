using Project2_ObjectGeneric;
class program
{
	static void Main()
	{
		Film<string> film = new();
		film.SetValue(1, "Ironman");
		film.SetValue(2, "Batman");
		film.SetValue(3, "Superman");
		film.SetValue(4, "Spiderman");
		Console.WriteLine(film.GetValue(3));
	}
}