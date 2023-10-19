public delegate string Film();
class program
{
	static void Main()
	{
		Film baru = Title;
		baru += Rating;
		Console.WriteLine(baru());
		
		List<string> result = new();
		Delegate[] delegateList = baru.GetInvocationList();
		foreach(Film d in delegateList) 
		{
		result.Add(d.Invoke());
		}
		Console.WriteLine(string.Join(", ", result));
	}
	
	static string Rating()
	{
		return "7/10";
	}
	static string Title()
	{
		return "Star Wars";
	}
}
