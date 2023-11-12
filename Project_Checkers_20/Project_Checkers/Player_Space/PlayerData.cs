namespace Project_Checkers;
public class PlayerData
{
	public IPlayer Player { get; private set; }
	public int Score { get; set; }
	public PlayerStatus Status { get; set; }

	public PlayerData(IPlayer player)
	{
		Player = player ?? throw new ArgumentNullException(nameof(player));
		Score = 0;
		Status = PlayerStatus.OnGoing;
	}

	public List<Piece> GetPieces()
	{
		if (Player is Player concretePlayer)
		{
			return concretePlayer.Pieces.Values.ToList();
		}
		return new List<Piece>();
	}
}
