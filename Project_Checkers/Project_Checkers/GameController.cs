namespace Project_Checkers;
using System;
using System.Collections.Generic;

public class GameController
{
	private Dictionary<IPlayer, PlayerData> _players;
	private List<IPlayer> _playerTurn;
	private Board _board;
	private List<Piece> _pieces;
	#region gamecontroller
	/// <summary>
	/// instance gamecontroller yang terdiri dari player1 dan player2
	/// </summary>
	/// <param name="player1">player1</param>
	/// <param name="player2">Player2</param>
	public GameController(IPlayer player1, IPlayer player2)
	{
		_players = new Dictionary<IPlayer, PlayerData>
		{
			{ player1, new PlayerData { playerPiece = InitialPiece.InitializePieces(12, PieceColour.White), moveKing = new List<Piece>(), score = 0, status = PlayerStatus.OnGoing } },
			{ player2, new PlayerData { playerPiece = InitialPiece.InitializePieces(12, PieceColour.Black), moveKing = new List<Piece>(), score = 0, status = PlayerStatus.OnGoing } }
		};
		_playerTurn = new List<IPlayer> { player1, player2 };
		_board = new Board();
	}
	#endregion
	
	#region getboard
	/// <summary>
	/// untuk dapatkan ukuran board
	/// </summary>
	/// <returns>mengembalikan ukuran board yakni 8x8</returns>
	public int GetBoardSize() // ukuran papan
	{
		return 8; // 8
	}
	#endregion
	
	#region getlistplayer
	/// <summary>
	/// Gets the list of players in the current turn order.
	/// </summary>
	/// <returns>A List of IPlayer representing the players.</returns>
	public List<IPlayer> GetPlayers() // daftar pemain
	{
		return _playerTurn;
	}
	#endregion
	
	#region AllPieceOnBoard
	/// <summary>
	/// dapatkan total piece yang ada di board
	/// </summary>
	/// <returns>mengembalikan nilai poiece yaang ada pada player data atau pada papan permainan</returns>
	public List<Piece> GetPieces() // total piece yang berada di papan permainan
	{
		List<Piece> pieces = new List<Piece>();
		foreach (var playerData in _players.Values)
			{
				if (playerData.playerPiece != null)  // Periksa apakah playerPiece tidak null
				{
					pieces.AddRange(playerData.playerPiece);
				}
			}
		return pieces;
	}
	#endregion

	#region PieceonSpecificPlayer
	/// <summary>
	/// dapatkan piece pada pemain tertentu
	/// </summary>
	/// <param name="idPlayer">id pada pemain yang mau di cek piecenya.</param>
	/// <returns>mengembalikan nilai piece.</returns>
	public List<Piece> GetPieces(int idPlayer) // daftar piece sesuai id player tertentu
	{
		if (_players.ContainsKey(_playerTurn[idPlayer]))
		{
			return _players[_playerTurn[idPlayer]].playerPiece;
		}
		return new List<Piece>();
	}
	#endregion

	#region InitialPiece
	/// <summary>
	/// inisialisasi piece pada awal permaian
	/// </summary>
	/// <param name="basicPieceCount">jumlah basic piece yang dibuat</param>
	/// <param name="colour">warna piece yang dibuat.</param>
	/// <returns>mengembalikan nilai piece</returns>
	public class InitialPiece
	{
		public static List<Piece> InitializePieces(int basicPieceCount, PieceColour colour)
		{
			List<Piece> pieces = new List<Piece>();
			for (int i = 0; i < basicPieceCount; i++)
			{
				pieces.Add(new Piece { idPiece = i, colour = colour, type = PieceType.Basic });
			}
			return pieces;
		}
	}
	#endregion
	
	public List<Position> GetPiecesAt(Piece piece, Position position) // set pidak pada tempatnya
	{
		List<Position> positions = new List<Position>();
		foreach (var playerData in _players.Values)
		{
			foreach (var playerPiece in playerData.playerPiece)
			{
				if (playerPiece == piece)
				{
					positions.Add(position);
				}
			}
		}
		return positions;
	}

	public bool MovePiece(IPlayer player, Piece piece, Position position) // pindahkan bidak oleh pemain
	{
		if (_players.ContainsKey(player) && _board.IsValidPosition(position)) // jika tempatnya vaid
		{
			return true; // bisa dipindahkan
		}
		return false;
	}

	public bool MovePiece(int idPlayer, int idPiece, Position position) // pindahkan bidak oleh idplayer
	{
		if (idPlayer >= 0 && idPlayer < _playerTurn.Count)
		{
			IPlayer player = _playerTurn[idPlayer];
			Piece piece = GetPieces(idPlayer)[idPiece];
			return MovePiece(player, piece, position);
		}
		return false;
	}

	public List<Position> GetAvailableMove(Piece piece) // untuk dapat posisi yang tersedia
	{
		List<Position> availableMoves = new List<Position>();
		return availableMoves;
	}

	public List<Position> GetAvailableMove(int idPlayer, int idPiece) // untuk tau posisi piece yang tersedia oleh idplayer
	{
		if (idPlayer >= 0 && idPlayer < _playerTurn.Count)
		{
			Piece piece = GetPieces(idPlayer)[idPiece];
			return GetAvailableMove(piece);
		}
		return new List<Position>();
	}

	public PlayerStatus GetStatus(IPlayer player) // status pemain
	{
		if (_players.ContainsKey(player))
		{
			return _players[player].status;
		}
		return PlayerStatus.Win;
	}

	public PlayerStatus GetStatus(int idPlayer) // status pemain idplayer
	{
		if (idPlayer >= 0 && idPlayer < _playerTurn.Count)
		{
			IPlayer player = _playerTurn[idPlayer];
			return GetStatus(player);
		}
		return PlayerStatus.Win;
	}

	public int GetScore(IPlayer player) // score pemain
	{
		if (_players.ContainsKey(player))
		{
			return _players[player].score;
		}
		return 0; 
	}

	public int GetScore(int idPlayer) // score pemain idplayer
	{
		if (idPlayer >= 0 && idPlayer < _playerTurn.Count)
		{
			IPlayer player = _playerTurn[idPlayer];
			return GetScore(player);
		}
		return 0;
	}
}