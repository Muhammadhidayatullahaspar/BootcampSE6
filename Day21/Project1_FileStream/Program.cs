class Program
{
	static void Main()
	{
		string path = @"./file.txt";
		using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
		{
			Console.WriteLine("ini lagi nulis file");
		}
	}
}