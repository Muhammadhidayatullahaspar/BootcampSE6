namespace Project8_GenericCollector;

public class GenCollect<T>
{
	public T[] myCollection = new T[100]; // batas 100 indeks
	public int counter = 0;

	public bool Add(T input)
	{
		myCollection[counter] = input;
		counter++;
		return true;
	}
}
