using Project8_Static2;
class program
{
	static void Main()
	{
		Mug mugA = new Mug();
		Mug mugB = new Mug();
		mugB.PriceHandler(13);
		mugA.PriceHandler(15);
		mugA.GetPrice();
		mugB.GetPrice();
		Console.WriteLine(Mug.StaticPrice);
	}
}