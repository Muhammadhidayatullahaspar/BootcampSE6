class program
{
	static void Main()
	{
		Comedy comedy= new Comedy();
	}
}
class Comedy
{
	public void UpdateComedy(string name)
	{
		Console.WriteLine(name);
		
	}
}
class Romance
{
	public void UpdateRomance(string name)
	{
		
	}
}
class Horor
{
	public void UpdateHoror(string name)
	{
		
	}
}
class Film
{
	private Comedy _comedy;
	private Romance _romance;
	private Horor _horor;
	public Film(Comedy comedy, Romance romance, Horor horor)
	{
		_comedy = comedy;
		_romance = romance;
		_horor = horor;
	}
	public void EndFilm()
	{
		_comedy.UpdateComedy("UpinIpin");
		_romance.UpdateRomance("love");
		_horor.UpdateHoror("setan");
	}
}