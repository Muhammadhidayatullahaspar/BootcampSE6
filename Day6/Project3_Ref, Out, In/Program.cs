class program
{
   static void Main()
	{
		float myint = 6;
		DivideRef(ref myint);
		Console.WriteLine(myint);
		float myOut = 10;
		DivideOut(out myOut);
		Console.WriteLine(myOut);
		
	}
	static void DivideRef(ref float input)
	{
		input = 5;
		input /= 2;
		
	}
	static void DivideOut(out float input)
	{
		input = 9;
		input = input / 3;
	}
	static void DivideIn(in float input)
	{
		//input = 8;
		float result = input / 4;
	}
}