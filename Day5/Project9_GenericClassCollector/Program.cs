using Project9_GenericClassCollector;
class program
{
	static void Main()
	{
		GenericCollection<int,string> generic = new(); //construct yang terdiri dari int dan string
		generic.Add(3,"hello"); // masukkan dua tipe data
		generic.Add(4, "true");
	}
}