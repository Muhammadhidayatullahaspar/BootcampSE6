namespace stuff; //namespace biar terhubung

public class Goods // name class
{
	private Glass _glass; // private class
	public Goods(Glass gelas) //biar private bisa dipanggil
	{
		_glass = gelas;
	}
	public void UsingGlass() //method
	{
		_glass.hot();
		_glass.cold();
	}
	
}
