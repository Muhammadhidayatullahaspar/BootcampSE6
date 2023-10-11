namespace Hewan;

class Kitten : Cat
{
	public Kitten(int age)
	{
		Console.WriteLine("Overload");
	}
	public Kitten() : base(12)
	{
		Console.WriteLine("inheritance");
	}
}
