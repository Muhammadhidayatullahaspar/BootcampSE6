namespace Project7_WithoutGenericOrObject;

public class DoubleType
{
	public double[] myCollection = new double[100];
	public int counter = 0;

	public bool Add(double input)
	{
		myCollection[counter] = input;
		counter++;
		return true;
	}
}
