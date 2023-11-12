namespace Project_Checkers;

public class Piece
{
	// Properti untuk mengidentifikasi pion secara unik
	public int pieceId { get; set; }

	// Properti untuk warna pion
	public PieceColour Colour { get; set; }

	// Properti untuk tipe pion (Basic atau King)
	public PieceType Type { get; set; }

	// Properti untuk menandai pemain yang memiliki pion ini
	public IPlayer Player { get; set; }

	// Properti untuk posisi pion di papan
	public Position Position { get; set; }

	// Konstruktor untuk Piece yang menginisialisasi warna dan tipe
	public Piece(PieceColour colour, PieceType type)
	{
		Colour = colour;
		Type = type;
	}
}
