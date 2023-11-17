using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MyGame
{
	public class GameController
	{
		private ILogger<GameController>? _log;
		private Dictionary<IPlayer, HashSet<ICard>> _players;
		private IBoard _board;
		public event Action<ICard>? OnCardUpdate;

		public GameController(IPlayer player, IBoard board, ILogger<GameController>? log = null)
		{
			_players = new()
			{
				{ player, new HashSet<ICard>() }
			};
			_board = board;
			_log = log;
			_log?.LogInformation("GameController initialized for player: {@Player}", player);
		}

		public bool AddCards(IPlayer player, params ICard[] cards)
		{
			if (!_players.TryGetValue(player, out HashSet<ICard>? playerCards))
			{
				_log?.LogWarning("Attempt to add cards failed for player: {Player}", player);
				return false;
			}

			foreach (var card in cards)
			{
				_log?.LogTrace("Adding card {Card} to player {Player}.", card, player);
				playerCards.Add(card);
				ChangeCardStatus(card, CardStatus.OnPlayer);
			}
			
			_log?.LogInformation("Added {CardCount} cards to player {Player}.", cards.Length, player);
			return true;
		}

		public IEnumerable<ICard> GetCards(IPlayer player)
		{
			if (!_players.ContainsKey(player))
			{
				_log?.LogWarning("Attempt to get cards failed for player: {Player}", player);
				return Enumerable.Empty<ICard>();
			}

			return _players[player];
		}

		public bool RemoveCard(IPlayer player, ICard card)
		{
			if (!_players.ContainsKey(player))
			{
				_log?.LogWarning("Attempt to remove card failed for player: {Player}", player);
				return false;
			}

			if (!_players[player].Contains(card))
			{
				_log?.LogWarning("Attempt to remove card {Card} failed for player: {Player}", card, player);
				return false;
			}

			_players[player].Remove(card);
			ChangeCardStatus(card, CardStatus.Removed);
			_log?.LogInformation("Card {Card} removed from player {Player}.", card, player);
			return true;
		}

		public void ChangeCardStatus(ICard card, CardStatus status)
		{
			card.SetStatus(status);
			OnCardUpdate?.Invoke(card);
			_log?.LogInformation("Card {Card} status changed to {Status}.", card, status);
		}
	}
}
