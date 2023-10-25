using Project4_CollectionImplementation;
class Program
{
	static void Main()
	{
		Dictionary<Player, Data> dictPlayers = new();
		Player player1 = new Player();
		dictPlayers.Add(player1, new Data(Colour.Green,0,100));
	
		Data result = dictPlayers[player1]; //Return Data dari DictPlayers
		foreach(Card c in result.GetCards()) {
			//...
		}
		Colour colourPlayer = result.GetColour();
		Console.WriteLine(colourPlayer);
	}
}