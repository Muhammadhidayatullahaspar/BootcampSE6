namespace CarComponent;

public class Engine // nama kelas
{
	public string engineType; // tipe data
	public int horsePower; // tipe data
	public Engine(string engineType, int horsePower) // construct
	
	{
		this.engineType = engineType; 
		this.horsePower = horsePower;
	}
	public void PrintEngine() // method buat tampilkan kalimat
	{
		Console.WriteLine($"EngineType {this.engineType}");	// print nama engine $ digabung dengan nama type baru
		Console.WriteLine($"HorsePower {this.horsePower}");	// print horsepower  $ digabung dengan kekuatan horsepower baru
	}
	
}
