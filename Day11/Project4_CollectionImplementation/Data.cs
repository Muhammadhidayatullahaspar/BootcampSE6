namespace Project4_CollectionImplementation;

public class Data
{
	private List<Card> _playerCards;
	private Colour _playerColour;
	private int _playerScore;
	private int _playerBet;
	
	public Data(Colour colour, int initialScore, int bet) {
		_playerCards = new();
		_playerColour = colour;
		_playerScore = initialScore;
		_playerBet = bet;
	}
	public bool AddCards(Card card){
		_playerCards.Add(card);
		return true;
	}
	public List<Card> GetCards()
	{
		return _playerCards;
	}
	public Colour GetColour() {
		return _playerColour;
	}
}
