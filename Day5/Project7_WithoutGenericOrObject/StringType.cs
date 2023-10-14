namespace Project7_WithoutGenericOrObject;

public class StringType
{
	public string[] myCollection = new string[100];
	public int counter = 0;

	public bool Add(string input)
	{
		myCollection[counter] = input;
		counter++;
		return true;
	}
}
