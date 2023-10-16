class program
{
	static void Main()
	{
		int[] myint = { 1,2,3,4};
		char[] mychar = new char[4];
		string[] mystring = new string[] {"a", "b", "c"};
		
		int result = myint[3];
		Console.WriteLine(result);
		string hasil = mystring[2];
		Console.WriteLine(hasil);
		mychar[3] = 'd';
		Console.WriteLine(mychar[3]);
		
	}
}