using Project8_GenericCollector;
class program
{
	static void Main()
	{
		GenCollect<int> collection = new(); // construc untuk integer
		collection.Add(3);
		collection.Add(4);
		collection.Add(5);
		int result = collection.myCollection[2]; // pilih indeks 2
		Console.WriteLine($"Hasil dari integer indeks 2 adalah {result}");
	
		GenCollect<bool> collectionOfBool = new(); // construct untuk boolean
		collectionOfBool.Add(true);
		collectionOfBool.Add(false);
		bool resultOfBool = collectionOfBool.myCollection[0]; // pilih indeks 0
		Console.WriteLine($"Hasil dari boolean indeks 0 adalah {resultOfBool}");
	}
	
}