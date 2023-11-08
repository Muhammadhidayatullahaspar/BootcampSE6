using System;
using System.IO;
namespace FileHandlinDemo
{
	class Program
	{
		/// <summary>
		/// buat baca file txt lalu munculkan isinya pada terminal
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			string filePath = @"MyFile.txt";

			StreamReader streamReader = new StreamReader(filePath);

			Console.WriteLine("Content of the File");
			
			using (StreamReader reader = new StreamReader(filePath))
			{
				Console.WriteLine(reader.ReadToEnd());
			}
			
			Console.ReadKey();
		}
	}
}