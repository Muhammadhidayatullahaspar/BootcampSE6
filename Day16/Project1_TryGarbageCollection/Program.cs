using System.Text;
class Program
{
	static void Main()
	{
		string nama = String.Empty;
		int ukuran = 1000000000;
		for (int i = 0; i < ukuran;i++)
		{
			nama += "a";
			nama += "b";
		}
		Console.WriteLine(nama);
		
	}
}