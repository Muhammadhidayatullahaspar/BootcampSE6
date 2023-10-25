class Program
{
	static void Main()
	{
		Dictionary<int, string> price = new();
		price.Add(10, "telur");
		price.Add(15, "ayam");
		price.Add(20, "sapi");
		foreach (KeyValuePair<int, string> e in price)
		{
			Console.WriteLine($" nilai keynya adalah {e.Key} dan nilai valuenya adalah {e.Value}");
		}
		string menu = price[10];
		Console.WriteLine($" makanan dari harga menu yang dimasukkan adalah  {menu}");
		string CariHarga = "sapi";
		int harga = 0;
		foreach(var e in price)
		{
			if(e.Value == CariHarga)
			{
				harga = e.Key;
				break;
			}
		}
		Console.WriteLine($"harga dari makanan yang dimasukkan adalah {harga}");
		KeyValuePair<int, string> keyvalue = new(25, "kambing");
		bool chekKey = price.Contains(keyvalue);
		Console.WriteLine(chekKey);
		
		int keyAdd = 5;
		string valueAdd = "Tempe";
		price.TryAdd(5,"Tempe");
	}
}