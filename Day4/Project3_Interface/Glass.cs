namespace Project3_Interface;

public class Glass : IRequest
{
	public void Taste()
	{
		Console.WriteLine("Rasa coklat");
	}
	public void Color()
	{
		Console.WriteLine("Warna merah");
	}
	public void Size()
    {
        Console.WriteLine("Ukuran Jumbo");
    }
}
