namespace Project_Checkers;

public class Piece
{
	// Properti untuk mengidentifikasi piece secara unik
	public int pieceId { get; set; }

	// Properti untuk warna piece
	public PieceColour Colour { get; set; }

	// Properti untuk tipe piece (Basic atau King)
	public PieceType Type { get; set; }
	

	// Properti untuk posisi piece di papan
	public Position Position { get; set; } // positionboard

	// Konstruktor untuk Piece yang menginisialisasi warna dan tipe
	public Piece(PieceColour colour, PieceType type)
	{
		Colour = colour;
		Type = type;
	}
}
