namespace Project_Checkers;
using System;
using System.Collections.Generic;

public class GameController
{
    private Dictionary<IPlayer, PlayerData> _players;
    private List<IPlayer> _playerTurn;
    private Board _board;

    public GameController(IPlayer player)
    {
        // insial gamecontroller
    }

    public int GetBoardSize() // ukuran papan
    {
        return 8; // 8
    }

    public List<IPlayer> GetPlayers() // daftar pemain
    {
        return _playerTurn;
    }

    public List<Piece> GetPieces() // daftar piece
    {
        List<Piece> pieces = new List<Piece>();
        foreach (var playerData in _players.Values)
        {
            pieces.AddRange(playerData.playerPiece);
        }
        return pieces;
    }

    public List<Piece> GetPieces(int idPlayer) // daftar bidak pada id player
    {
        if (_players.ContainsKey(_playerTurn[idPlayer]))
        {
            return _players[_playerTurn[idPlayer]].playerPiece;
        }
        return new List<Piece>();
    }

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