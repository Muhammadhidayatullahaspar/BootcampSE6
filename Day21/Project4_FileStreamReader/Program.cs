using System.IO;
class Program
{
	/// <summary>
	/// untuk baca file yang ada pada txt dan akan mengeluarkan di consolenya
	/// </summary>
	static void Main()
	{
		string path = @"./file.txt";
		using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
		{
			using (StreamReader sr = new StreamReader(fs))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					Console.WriteLine(line);
				}
			}
		}
	}
}