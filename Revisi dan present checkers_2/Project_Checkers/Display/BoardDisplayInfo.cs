namespace Project_Checkers;

public class BoardDisplayInfo
{
    public int PositionBoard { get; set; }
    public int? PieceId { get; set; }
    public string Colour { get; set; }
    public string PieceType { get; set; }
    public bool IsEmpty { get; set; }
    public int? IdField { get; set; }

    public BoardDisplayInfo(int positionBoard, int? pieceId, string colour, string pieceType, bool isEmpty, int? idField)
    {
        PositionBoard = positionBoard;
        PieceId = pieceId;
        Colour = colour;
        PieceType = pieceType;
        IsEmpty = isEmpty;
        IdField = idField;
    }
}
