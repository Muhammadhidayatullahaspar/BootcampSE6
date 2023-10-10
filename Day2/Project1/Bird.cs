namespace Hewan;

public class Bird : Animal // ambil dari parent animal
{
	public Bird(string name, int age, bool alive) : base(name, age, alive) // Constructor dari parents karena sama
	{
		Console.WriteLine("Bird instance created"); // print bird instance created
	}
	public void Fly() // method
	{
		Console.WriteLine("Fly");
	}
	public void Kukuk() // method
	{
		Console.WriteLine("Kukuk");
	}
}