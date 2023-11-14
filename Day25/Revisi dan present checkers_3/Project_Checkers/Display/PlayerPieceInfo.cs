namespace Project_Checkers;

public class PlayerPieceInfo
{
    public int PieceId { get; set; }
    public string Colour { get; set; }
    public string PieceType { get; set; }

    public PlayerPieceInfo(int pieceId, string colour, string pieceType)
    {
        PieceId = pieceId;
        Colour = colour;
        PieceType = pieceType;
    }
}
