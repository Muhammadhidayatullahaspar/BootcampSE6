namespace stuff; // namespacenya
class GlassPlastic : Glass // inheritance glassplastik ke glass
{
	public string material = "plastic"; // string material 
	public int width = 4; // integer width
	public override void Brand() // method brand override biar bisa ngisi abstractnya
	{
		Console.WriteLine("Brandnya aqua");	//print
	}
}
