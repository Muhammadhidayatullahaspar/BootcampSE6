namespace Project10_GenericMethodCollector;

public class GenericMethodCollector<T>
{
	public T[] myCollection = new T[100];
	public int counter = 0;

	public T2 Add<T2>(T input, T2 input2)
	{
		myCollection[counter] = input;
		counter++;
		return input2;
	}
}
