namespace stuff;

public class Goods
{
	private Glass _glass;
	public Goods(Glass gelas)
	{
		_glass = gelas;
	}
	public void UsingGlass()
	{
		_glass.hot();
		_glass.cold();
	}
	
}
