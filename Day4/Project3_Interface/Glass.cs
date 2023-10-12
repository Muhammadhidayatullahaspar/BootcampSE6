namespace Project3_Interface; // nama namespace biar tehubung

public class Glass : IRequest // nama kelas Glass yang tehubung dengan interface request
{
	public void Taste() // method taste
	{
		Console.WriteLine("Rasa coklat"); // print
	}
	public void Color() // method color
	{
		Console.WriteLine("Warna merah"); // print
	}
	public void Size() // method size
    {
        Console.WriteLine("Ukuran Jumbo"); // print
    }
}
