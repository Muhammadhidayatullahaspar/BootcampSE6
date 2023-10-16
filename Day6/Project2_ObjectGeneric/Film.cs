namespace Project2_ObjectGeneric;

public class Film<T>
{
	private T[] collection = new T[100];
	public T GetValue (int index)
	{
		if (index < collection.Length - 1)
		{
			return collection[index];
		} throw new ArgumentOutOfRangeException("Not found in collection");
		
	}
	public bool SetValue (int index, T value)
	{
		collection[index] = value;
		return true;
	}
	
	
}
