using Collection;
class program
{
	static void Main()
	{
		ObjectCollection collection = new();
		collection.Add(48);
		collection.Add(true);
		collection.Add(54.4f);
		collection.Add(null);
		collection.Add("Yayat");
		collection.Add(324M);
	
		int result = (int)collection.myCollection[0];
		//int result2 = (int)collection.myCollection[1];
	}
}