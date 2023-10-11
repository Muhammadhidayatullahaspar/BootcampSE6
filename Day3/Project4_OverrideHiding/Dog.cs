namespace Hewan;

public class Dog : Animal // set animal sebagai parent dari dog
{
	public override void MakeSound() // override biar bisa mengganti nilai dari parent
	
	{
		Console.WriteLine("Guk"); //set nilai yang akan dikeluarkan
	}
	
}
