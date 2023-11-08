using System;
using System.IO;
using System.Text;

namespace FileHandlinDemo{
class Program
{
	/// <summary>
	/// untuk membuat atau membuka file txt lalu menuliskan tulis, tulis baris kedua, tulis baris ketiga
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
	}
}
}