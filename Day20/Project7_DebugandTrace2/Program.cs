using System.Diagnostics;

class Program 
{
	static void Main() 
	{
		int x = 10, y = 2;
		Debug.WriteLine("program telah berjalan");
		Debug.WriteLine("x = " + x);
		Debug.WriteLine("y = " + y);
		Debug.WriteLine("");
		
		Trace.WriteLine("menghitung");
		int divide = x / y;
		Trace.WriteLine(" x / y = " + divide);
		Trace.WriteLine("");
		
		Debug.Assert(divide == 5, "hasilnya 5");
	}
}