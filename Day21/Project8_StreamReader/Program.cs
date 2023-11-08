using System;
using System.IO;
namespace FileHandlinDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string filePath = @"MyFile.txt";       
            StreamReader streamReader = new StreamReader(filePath);
            Console.WriteLine("Content of the File");

            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            string strData = streamReader.ReadLine();
            while (strData != null)
            {
                Console.WriteLine(strData);
                strData = streamReader.ReadLine();
            }
            Console.ReadLine();
            streamReader.Close();
            Console.ReadKey();
        }
    }
}