class Program
{
	static void Main()
	{
		Func<int,int,int> function = Rating;
		Func<string,int,bool,string> function2 = Title;
	}
	static int Rating(int a, int b)
	{
		return a + b;
	}
	static string Title(string a, int b, bool c)
	{
		return"testing";
	}
}