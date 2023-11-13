namespace Project_Checkers;
public class PlayerData
{
	#region Properti Pemain pada PlayerData
	/// <summary>
	/// Properti untuk mendapatkan objek pemain.
	/// </summary>
	public IPlayer Player { get; private set; }

	/// <summary>
	/// Properti untuk mendapatkan atau mengatur status pemain.
	/// </summary>
	public PlayerStatus Status { get; set; }
	#endregion

	#region Konstruktor Data Pemain
	/// <summary>
	/// Konstruktor untuk objek data pemain.
	/// Inisialisasi objek pemain dan status pemain.
	/// </summary>
	/// <param name="player">Objek pemain (IPlayer) yang akan diinisialisasi.</param>
	/// <exception cref="ArgumentNullException">Dilempar jika objek pemain null.</exception>
	public PlayerData(IPlayer player)
	{
		Player = player ?? throw new ArgumentNullException(nameof(player));
		Status = PlayerStatus.OnGoing;
	}
	#endregion

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
