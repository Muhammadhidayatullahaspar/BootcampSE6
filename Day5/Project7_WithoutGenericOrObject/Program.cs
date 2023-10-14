using Project7_WithoutGenericOrObject;
class program
{
	static void Main()
	{
		IntType type = new(); // construct darikelas integer
		type.Add(9);
		int result = (int)type.myCollection[0];
		int result2 = (int)type.myCollection[1];	
		Console.WriteLine(result);	// keluarkan nilai result
	}
}