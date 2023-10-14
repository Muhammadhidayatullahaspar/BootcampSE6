namespace Project9_GenericClassCollector;

public class GenericCollection<T,T2> // generic terdiri dari dua tipe data
{
	public T[] myCollection = new T[100]; // batas 100
	public T2[] myCollection2 = new T2[100]; // batas 100
	public int counter = 0;

	public bool Add(T input, T2 input2) 
	{
		myCollection[counter] = input;
		myCollection2[counter] = input2;
		counter++;
		return true;
	}
}
