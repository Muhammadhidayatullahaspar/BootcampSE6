namespace Domino;

public class Tile
{
	public DotNumber Side1 { get; }
	public DotNumber Side2 { get; }

	public DominoTile(DotNumber side1, DotNumber side2)
	{
		Side1 = side1;
		Side2 = side2;
	}
}
