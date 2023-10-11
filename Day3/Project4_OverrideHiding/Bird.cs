namespace Hewan;
public class Bird : Animal // animal adalah parent dari bird, dimana data dari parent bisa dipakai pada bird
{
	public new void MakeSound() // new void buat method hiding
	{
		Console.WriteLine("chip"); // set nilai makesound pada bird
	}
}
