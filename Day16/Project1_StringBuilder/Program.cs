using System.Text;
class Program
{
	static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int ukuran = 10000;
		for (int i = 0; i < ukuran;i++)
		{
			sb.Append("a");
			sb.Append("c");
		}
		Console.WriteLine(sb.ToString());
		
	}
}