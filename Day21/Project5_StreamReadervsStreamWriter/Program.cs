using System.IO;
class Program
{
	/// <summary>
	/// untuk menulis file txt menggunakan streamwriter lalu membacanya menggunakan streamreader. 
	/// </summary>
	static void Main()
	{
		string path = @"./file.txt";
		using (StreamWriter writer = new StreamWriter(File.Open(path, FileMode.OpenOrCreate)))
		{
			writer.WriteLine("tulis");
			writer.WriteLine("tulis baris kedua");
			writer.WriteLine("tulis baris ketigas");
		}
		using (StreamReader reader = new StreamReader(File.Open(path, FileMode.OpenOrCreate)))
		{
			string line1 = reader.ReadLine();
			string line2 = reader.ReadLine();
			string line3 = reader.ReadLine();
			Console.WriteLine(line1 + " \n" + line2 + " \n" + line3);
		}
	}
}