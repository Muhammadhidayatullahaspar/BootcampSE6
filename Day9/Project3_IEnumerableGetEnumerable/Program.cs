class Program
{
	static void Main()
	{
		List<string> food = new List<string> {"Coto", "Nasi Goreng", "Soto"};
		var enumerable = food.GetEnumerator();
		enumerable.MoveNext();
		string result = enumerable.Current;
		Console.WriteLine(result);
		foreach (var item in food)
		{
			Console.WriteLine(item);
		}
	}
}