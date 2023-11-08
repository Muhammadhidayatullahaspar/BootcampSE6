using System;
using System.IO;
using System.Text;

namespace FileHandlinDemo
{
	class Program
	{
		/// <summary>
		/// buat file baru berupa txt lalu isi dengan "ini lagi nulis isi file
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			string FilePath = "MyFile.txt";

			using (FileStream fileStream = new FileStream(FilePath, FileMode.Create))
			{
				byte[] bytedata = Encoding.Default.GetBytes("ini lagi nulis isi file");
				Console.WriteLine(bytedata.Length);
				fileStream.Write(bytedata, 0, bytedata.Length);
				fileStream.Close();
			}
			Console.WriteLine("Successfully saved file with data : C# Is an Object Oriented Programming Language");
			Console.ReadKey();
		}
	}
}