using Project7_Static;
class program
{
	static void Main()
	{
		float a = 2;
		float b = 3;
		Calculator myCalc = new();
		float result = myCalc.NonStaticAdder(a,b); // mycalc divde
		Console.WriteLine(result); // tampilkan hasilnya
	}
}