namespace Hewan;

public class Cat : Animal // ambil dari parent animal
{
	public Cat(string name, int age, bool alive) : base(name, age, alive) // Constructor dari parents digunakan di childnya 
	
	{
		Console.WriteLine("Cat instance created"); // tulis kalau catnya telah dibuat dimana semua hewan punya name, age dan alive atau tidak
	}
	public void Walk() // method
	{
		Console.WriteLine("Walk"); // keluarkan walk
	}
	public void Meow() // method
	
	{
		Console.WriteLine("Meow"); // keluarkan meow
	}
	
}