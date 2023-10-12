namespace stuff;

public class PlasticGlass :Glass
{
	public override void hot()
	{
		Console.WriteLine("Hot Water in plastic glass");
	}
	
	public void cold()
	{
        Console.WriteLine("Cold Water in plastic glass");
    }
}
