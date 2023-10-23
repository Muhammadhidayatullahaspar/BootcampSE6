namespace Project4_Enumerator;

public class Mycollection 
{
	public int currentIndex = -1;
	public int[] myInt = new int[14];
	public object Current => myInt[currentIndex];
	public bool MoveNext()
	{
		if (currentIndex+1 < myInt.Length)
		{
			currentIndex++;
			return true;
		}
		else 
		{
			Reset();
			return false;
		}
	}
	public void Reset()
	{
		currentIndex = -1;
	}
}
