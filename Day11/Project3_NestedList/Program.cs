class Program
{
	static void Main()
	{
		//Instead of this
		//Dictionary<Player, List<Card>> playerCards;
		//Dictionary<Player, Colour> playerColour;
		//Dictionary<Player, int> playerScore;
		//Dictionary<Player, int> playerBet;
	
		//Use this
		Dictionary<Player, PlayerInfo> playerInfo;
	}
	
	class PlayerInfo {
		private List<Card> _playerCards;
		private Colour _playerColour;
		private int _playerScore;
		private int _playerBet;
	
		public List<Card> GetCards() {
			return _playerCards;
		}
	}
	public enum Colour {
		White,
		Black
	}
	class Player { }
	class Card { }
}