namespace Project7_WithoutGenericOrObject;

public class IntType
{
	
	public int[] myCollection = new int[100];
	public int counter = 0;

	public bool Add(int input)
	{
		myCollection[counter] = input;
		counter++;
		return true;
	}
}
