namespace Hewan;

public class Shark : Animal // ambil dari parent
{
	public Shark(string name, int age, bool alive) : base(name, age, alive) // ambil dari parent
	{
		Console.WriteLine("Shark instance created"); // print kalimat
	}
	public void Swim() // method
	{
		Console.WriteLine("Swim"); // keluarkan swim
	}
	public void sensorElektro() // method 
	
	{
		Console.WriteLine("Sensor elektro"); // keluarkan kalimat
	}
}