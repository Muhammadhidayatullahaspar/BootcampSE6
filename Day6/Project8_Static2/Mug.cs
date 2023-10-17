namespace Project8_Static2;

public class Mug
{
	public static int StaticPrice;
	
	public void PriceHandler(int price) {
		StaticPrice = price;
	}
	public int GetPrice()
	{
		Console.WriteLine(StaticPrice);
		return StaticPrice;
	}
}
