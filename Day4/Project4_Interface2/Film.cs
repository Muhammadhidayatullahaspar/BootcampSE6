using Project4_Interface2;
namespace Project4_Interface2;

public class Film : IAdventure, IComedy, IHoror, IRomance // inheritance dari interface
{
	public void Bioskop() // method bioskop
	{
		Console.WriteLine("Selamat datang di bioskop"); // print
	}
	public void Netflix() // method netflix
	{
		Console.WriteLine("Netflixnya kakak silahkan"); // print
	}
	public bool Rating(int Rate) // method rating
	{
		if (Rate >= 7) // jika lebih dari 7
		{
			Console.WriteLine("Wah filmnya bagus nih");
			return true;
		}
		else // jika tidak
		{
			Console.WriteLine("Haduh, filmnya kurang menarik");
			return false;
		}
	}
	public void Ketawa() // method ketawa
	{
		Console.WriteLine("Hahaha saya ngakak"); // print
	}
	public void Hbo() // method hbo
	{
		Console.WriteLine("Asik juga nih nonton lewat HBO"); //print
	}
	public void JumpScare() // method jumpcare
	{
		Console.WriteLine("Huaaa saya kaget"); // print
	}
	public void Baper() // method baper
	{
		Console.WriteLine("waduh saya baper liatnya"); // print
	}
}
