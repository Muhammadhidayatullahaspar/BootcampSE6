namespace Project6_OverrideEqualsfromObjectandAs_Is;

public class Film
{
	public int Rating { get; private set; }
	public Film(int rate)
	{
		Rating = rate;
	}
	public override bool Equals(object e)
	{
		if(e is Film y)
		{
			var film = e as Film;
			return Rating == y.Rating;		
		}
		return false;
	}
}
