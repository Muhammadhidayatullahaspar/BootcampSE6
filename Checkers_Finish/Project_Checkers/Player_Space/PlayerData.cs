namespace Project_Checkers;
public class PlayerData
{
	public IPlayer Player { get; private set; }
	private Dictionary<int, Piece> _pieces;
	public PlayerStatus Status { get; set; }

	public PlayerData(IPlayer player)
	{
		Player = player ?? throw new ArgumentNullException(nameof(player));
		_pieces = new Dictionary<int, Piece>();
		Status = PlayerStatus.OnGoing;
	}


	#region Mendapatkan piece Pemain
	/// <summary>
	/// Mengembalikan daftar piece pemain.
	/// </summary>
	/// <returns>Daftar piece pemain, atau daftar kosong jika pemain bukan objek Player.</returns>
	public List<Piece> GetPieces()
	{
		if (Player is Player concretePlayer)
		{
			return concretePlayer.Pieces.Values.ToList();
		}
		return new List<Piece>();
	}
	#endregion

}
