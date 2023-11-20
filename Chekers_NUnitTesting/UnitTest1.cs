using NUnit.Framework;
using Project_Checkers; // Pastikan ini sesuai dengan namespace Anda
using System.Collections.Generic;

[TestFixture]
public class GameControllerTests
{
	private GameController _gameController;
	private Player _player1;
	private Player _player2;

	[SetUp]
	public void Setup()
	{
		// Inisialisasi pemain
		_player1 = new Player("Player1", 1);
		_player2 = new Player("Player2", 2);

		// Inisialisasi GameController
		_gameController = new GameController(_player1, _player2);
	}

	[Test]
	public void GameController_InitializesCorrectly()
	{
		// Periksa apakah GameController diinisialisasi dengan benar
		Assert.IsNotNull(_gameController);
	}

	[Test]
	public void Players_AreInitializedCorrectly()
	{
		// Periksa apakah pemain telah diinisialisasi dengan benar
		Assert.AreEqual("Player1", _player1.Name);
		Assert.AreEqual("Player2", _player2.Name);
	}

	[Test]
	public void Pieces_ArePlacedOnBoardCorrectly()
	{
		// Periksa apakah piece ditempatkan pada papan dengan benar
		var player1Pieces = _gameController.GetPlayerData(_player1).GetPieces();
		var player2Pieces = _gameController.GetPlayerData(_player2).GetPieces();

		// Periksa jumlah piece untuk setiap pemain
		Assert.AreEqual(12, player1Pieces.Count, "Jumlah piece pemain 1 tidak sesuai");
		Assert.AreEqual(12, player2Pieces.Count, "Jumlah piece pemain 2 tidak sesuai");

		// Periksa apakah piece ditempatkan di kotak berwarna gelap pada 3 baris pertama dari setiap sisi
		Assert.IsTrue(player1Pieces.All(p => p.Position.Y < 3 && (p.Position.X + p.Position.Y) % 2 != 0), "Piece pemain 1 tidak ditempatkan dengan benar");
		Assert.IsTrue(player2Pieces.All(p => p.Position.Y >= 5 && (p.Position.X + p.Position.Y) % 2 != 0), "Piece pemain 2 tidak ditempatkan dengan benar");
	}
	
	 [Test]
	public void InitializePieces_CreatesCorrectNumberOfPieces()
	{
		var pieces = GameController.InitializePieces(12, PieceColour.White, 1);
		Assert.AreEqual(12, pieces.Count);
	}
	[Test]
	public void GetBoardDisplay_ReturnsCorrectDisplayInfo()
	{
		var boardDisplay = _gameController.GetBoardDisplay();

		// Memeriksa jumlah total informasi tampilan papan
		Assert.AreEqual(Board.BoardSize * Board.BoardSize, boardDisplay.Count);

		// Memeriksa apakah setiap informasi tampilan papan memiliki data yang valid
		foreach (var displayInfo in boardDisplay)
		{
			Assert.IsNotNull(displayInfo);
			Assert.GreaterOrEqual(displayInfo.PositionBoard, 1);
			Assert.LessOrEqual(displayInfo.PositionBoard, Board.BoardSize * Board.BoardSize);
			
			// Memeriksa apakah informasi piece konsisten dengan status kosong atau tidak
			if (displayInfo.IsEmpty)
			{
				Assert.IsNull(displayInfo.PieceId);
				Assert.IsNull(displayInfo.Colour);
				Assert.IsNull(displayInfo.PieceType);
			}
			else
			{
				Assert.IsNotNull(displayInfo.PieceId);
				Assert.IsNotNull(displayInfo.Colour);
				Assert.IsNotNull(displayInfo.PieceType);
			}
		}
	}



	[Test]
	public void GetPieces_ReturnsCorrectPiecesForPlayer()
	{
		var player1Pieces = _gameController.GetPieces(_player1);
		Assert.AreEqual(12, player1Pieces.Count);
	}

   [Test]
	public void GetPlayerPiecesDisplay_ReturnsCorrectDisplayInfo()
	{
		var player1DisplayInfo = _gameController.GetPlayerPiecesDisplay(_player1);
		
		// Memeriksa bahwa jumlah informasi tampilan piece untuk pemain adalah benar
		Assert.AreEqual(12, player1DisplayInfo.Count, "Jumlah piece pemain 1 tidak sesuai");

		// Memeriksa apakah setiap informasi tampilan piece memiliki data yang valid
		foreach (var pieceInfo in player1DisplayInfo)
		{
			Assert.IsNotNull(pieceInfo, "Informasi piece tidak boleh null");
			Assert.Greater(pieceInfo.PieceId, 0, "ID piece harus lebih besar dari 0");
			Assert.IsNotNull(pieceInfo.Colour, "Warna piece tidak boleh null");
			Assert.IsNotNull(pieceInfo.PieceType, "Jenis piece tidak boleh null");
			Assert.That(pieceInfo.Colour, Is.EqualTo("White").Or.EqualTo("Black"), "Warna piece harus 'White' atau 'Black'");
		}
	}

	[Test]
	public void GetStatus_ReturnsCorrectPlayerStatus()
	{
		var statusPlayer1 = _gameController.GetStatus(_player1);
		var statusPlayer2 = _gameController.GetStatus(_player2);

		// Asumsikan status awal pemain adalah 'OnGoing'
		Assert.AreEqual(PlayerStatus.OnGoing, statusPlayer1);
		Assert.AreEqual(PlayerStatus.OnGoing, statusPlayer2);
	}

	[Test]
	public void MovePiece_ValidMove_ReturnsTrue()
	{
		// Setup posisi awal dan tujuan yang valid
		Position from = new Position { X = 0, Y = 2 };
		Position to = new Position { X = 2, Y = 3 };

		bool result = _gameController.MovePiece(from, to);

		Assert.IsTrue(result, "Gerakan valid seharusnya berhasil.");
	}

	[Test]
	public void MovePiece_InvalidMove_ReturnsFalse()
	{
		// Setup posisi awal dan tujuan yang tidak valid
		Position from = new Position { X = 0, Y = 2 };
		Position to = new Position { X = 0, Y = 5 };

		bool result = _gameController.MovePiece(from, to);

		Assert.IsFalse(result, "Gerakan tidak valid seharusnya gagal.");
	}

	[Test]
	public void IsValidMove_ValidMove_ReturnsTrue()
	{
		var piece = new Piece(PieceColour.White, PieceType.Basic);
		Position from = new Position { X = 2, Y = 2 };
		Position to = new Position { X = 3, Y = 3 };

		bool isValid = _gameController.IsValidMove(piece, from, to);

		Assert.IsTrue(isValid);
	}

	[Test]
	public void IsValidMove_InvalidMove_ReturnsFalse()
	{
		var piece = new Piece(PieceColour.White, PieceType.Basic);
		Position from = new Position { X = 2, Y = 2 };
		Position to = new Position { X = 4, Y = 4 };

		bool isValid = _gameController.IsValidMove(piece, from, to);

		Assert.IsFalse(isValid);
	}

	[Test]
	public void CheckForPromotion_PromotesPieceWhenApplicable()
	{
		var piece = new Piece(PieceColour.White, PieceType.Basic) { Position = new Position { X = 0, Y = 7 } };

		_gameController.CheckForPromotion(piece);

		Assert.AreEqual(PieceType.King, piece.Type, "Piece seharusnya dipromosikan menjadi King.");
	}
	
	[Test]
	public void GetValidMovesForPiece_ReturnsCorrectMovesForBasic()
	{
		var piece = new Piece(PieceColour.White, PieceType.Basic) { Position = new Position { X = 2, Y = 2 } };
		var validMoves = _gameController.GetValidMovesForPiece(piece, piece.Position);

		// Tambahkan asersi spesifik tergantung pada aturan gerakan Anda
		Assert.IsNotEmpty(validMoves, "Harus ada gerakan yang valid.");

		// Misalnya, untuk piece basic, harus bisa bergerak maju satu langkah diagonal
		var expectedMove1 = new Position { X = 3, Y = 3 };
		var expectedMove2 = new Position { X = 1, Y = 3 };

		Assert.Contains(expectedMove1, validMoves, "Gerakan valid harus mencakup maju satu langkah diagonal ke kanan.");
		Assert.Contains(expectedMove2, validMoves, "Gerakan valid harus mencakup maju satu langkah diagonal ke kiri.");
	}

	[Test]
	public void GetValidMovesForPiece_ReturnsCorrectMovesForKing()
	{
		var kingPiece = new Piece(PieceColour.White, PieceType.King) { Position = new Position { X = 3, Y = 3 } };
		var validMovesForKing = _gameController.GetValidMovesForPiece(kingPiece, kingPiece.Position);

		Assert.IsNotEmpty(validMovesForKing, "Harus ada gerakan yang valid untuk King.");

		// Gerakan maju dan mundur satu langkah diagonal
		var expectedMoves = new List<Position>
		{
			new Position { X = 2, Y = 2 },
			new Position { X = 4, Y = 2 },
			new Position { X = 2, Y = 4 },
			new Position { X = 4, Y = 4 }
		};

		foreach (var expectedMove in expectedMoves)
		{
			Assert.Contains(expectedMove, validMovesForKing, $"Gerakan valid untuk King harus mencakup posisi {expectedMove.X}, {expectedMove.Y}.");
		}
	}

	[Test]
	public void GetPlayerData_ForValidPlayer_ReturnsCorrectData()
	{
		// Menggunakan pemain yang telah diinisialisasi di Setup
		var playerData = _gameController.GetPlayerData(_player1);

		// Memeriksa apakah data yang dikembalikan adalah benar
		Assert.IsNotNull(playerData, "Data pemain tidak boleh null.");
		Assert.AreEqual(_player1, playerData.Player, "Data pemain harus sesuai dengan pemain yang diminta.");
	}

	[Test]
	public void GetPlayerData_ForInvalidPlayer_ThrowsException()
	{
		// Membuat pemain yang tidak ada di game controller
		var invalidPlayer = new Player("InvalidPlayer", 999);

		// Memeriksa apakah metode melempar exception yang sesuai
		var ex = Assert.Throws<InvalidOperationException>(() => _gameController.GetPlayerData(invalidPlayer));
		Assert.AreEqual("Pemain tidak ditemukan.", ex.Message, "Pesan exception harus sesuai.");
	}

}
