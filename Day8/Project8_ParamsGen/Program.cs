using System.Numerics;
class Program
{
	static void Main()
	{
		int result = Add(3,4);
		int result2 = Add(3,4,5,7,8,8,9,9,9,9,9,9,1);
		Console.WriteLine(result);
		Console.WriteLine(result2);
		Console.WriteLine(StringCombiner("hello","world"));
	}
	
static T Add<T>(params T[] x) where T : INumber<T> 
{
	T result = default;
	for(int i = 0; i < x.Length; i++) {
		result += x[i];
	}
	return result;
}

static string StringCombiner(params string[] strings) {
	string result = default;
	
	foreach(string s in strings) {
		result += " " + s;
	}
	return result;
}
}