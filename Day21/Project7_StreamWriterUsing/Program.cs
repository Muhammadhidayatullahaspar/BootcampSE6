using System;
using System.IO;
namespace FileHandlinDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"MyFile.txt";

          
            int a, b, result;
            a = 15;
            b = 20;
            result = a + b;

          
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.Write($"Sum of {a} + {b} = {result}");
            }
            Console.WriteLine("Variable Data is Saved into the File");
            Console.ReadKey();
        }
    }
}