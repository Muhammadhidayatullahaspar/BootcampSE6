namespace stuff; // namespace

public class PlasticGlass :Glass //inheritance ke glass
{
	public override void hot() // override  hot class
	{
		Console.WriteLine("Hot Water in plastic glass"); // print
	}
	
	public void cold() // method ini tidak override jadi tidak bisa diambil alih
	{
        Console.WriteLine("Cold Water in plastic glass"); // print
    }
}
