namespace Hewan;

public class Animal // nama kelas
{
	public int age; // tipe data
	public string name; // tipe data string
	public bool alive; // tipe data boolean true false
	
	public Animal(string name, int age, bool alive) // Constructor
	{
		Console.WriteLine($"Animal {name} instance created"); // $ dipake untuk gabung name dan hasil printnya
		this.name = name; 
		this.age = age;
		this.alive = alive;
	}
	
	public void Eat() // method
	{
		Console.WriteLine("eat detected"); // print eat detected
		
	}
	public void PrintAnimal() // method
	{
		Console.WriteLine($"Name {this.name}");	// print nama hewan $ digabung dengan nama hewan baru
		Console.WriteLine($"Age {this.age}");	// print nama hewan $ digabung dengan umur hewan baru
		Console.WriteLine($"Is it alive {this.alive}");	 // print nama hewan $ digabung dengan alive true atau false
	}
}