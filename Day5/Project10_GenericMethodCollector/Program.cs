using Project10_GenericMethodCollector;
class program
{
	static void Main()
	{
		GenericMethodCollector<int> generic = new();
		generic.Add(7, "Martabak");
		generic.Add(2, "manis");
	}
}