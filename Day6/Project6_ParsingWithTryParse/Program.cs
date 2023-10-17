class program
{
	static void Main()
{
	string myString = "9494"; // string pertama hanya angka
	string myString2 = "949ds4"; // string kedua terdapat huruf
	bool statusParsing = int.TryParse(myString, out int result); // status boolean parsing
	bool statusParsing2 = int.TryParse(myString2, out int result2); // status boolean parsing
	Console.WriteLine($" Hasil parsingnya adalah {result}"); // hasil parsing pada string pertama
	Console.WriteLine($" Status hasil parsing dari 9494 adalah {statusParsing}"); // status boolean string pertama
	Console.WriteLine($" Hasil parsingnya adalah{result2}"); // hasil parsing pada string kedua
	Console.WriteLine($"status hasil parsing dari 949ds4 adalah {statusParsing2}"); // status boolean string kedua
}
}
