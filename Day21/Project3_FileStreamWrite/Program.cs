using System;
using System.IO;
using System.Text;

namespace FileHandlinDemo{
class Program
{
	static void Main()
	{
		string path = @"./file.txt";
		using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
		{
			byte[] data = Encoding.UTF8.GetBytes("ini lagi nulis isi file");
			fs.Write(data, 0, data.Length);
		}
		using(FileStream fs = new FileStream(path, FileMode.Open))
		{
			byte[] buffer = new byte[fs.Length]; 
			fs.Read(buffer, 0, buffer.Length);
			string content = Encoding.UTF8.GetString(buffer); 
			Console.WriteLine(content);
		}
	}
}}