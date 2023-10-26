namespace Domino;

public class GameController
{
	public List<Tile> _tilePlayer;
	private Player _currentPlayer;
	private Dictionary<Player, Status> _playerStatus;
	private Dictionary<Player, List<Tile>> _players;
	private Tile _LastTile;
	public GameController(Player player, List<Tile> tilePlayer) 
	{
		_tilePlayer = new();
		_playerStatus = new();
		_players = new();
	}
	
	public List<Player> GetPlayers() 
	{
		return _players.Select(p => p.Key).ToList();
	}
	private void ShuffleDeck(List<Tile> TileRandom)
	{
		return _tilePlayer;
	}
	
	public Tile GetLastCard() 
	{
		return _lastCard;
	}
	public List<Tile> GetTile(Player p) {
		return _players[p];
	}
	
}
