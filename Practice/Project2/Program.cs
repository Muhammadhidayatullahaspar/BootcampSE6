using System.Xml;

class Program
{
	static void Main()
	{
		Console.WriteLine("please input your words...");
		string input = Console.ReadLine();
		Words words = new();
		string output = words.Reverse(input);
		Console.WriteLine(output);
		
	}
}

public class Words
{
	public string Reverse (string input)
	{
		string output = "";
		for (int i = input.Length -1 ; i >=0; i--)
		{
			output += input[i];
		}
		return output;
	}
}