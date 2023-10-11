namespace Hewan; 
public class Animal
{
	public virtual void MakeSound() // biar bisa overriding pada anakannya
	{
		Console.WriteLine("Make sound"); // set nilai makesound yang akan dikeluarkan
	}
}
