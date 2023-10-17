class program
{
	static void Main()
	{
		string myString = "Martabak";
		Console.WriteLine($" Nilai sebelum string appender ({myString})"); // sebelum string appender
		StringAppender(ref myString); // myString melakukan method stringappender
		Console.WriteLine($" Nilai setelah string appender ({myString})"); // setelah string appender
	}

	static void StringAppender(ref string input) // method to append
	{
		input = input + "Telur"; // tambahkan telur pada kalimat atau kata inputan
	}
}

