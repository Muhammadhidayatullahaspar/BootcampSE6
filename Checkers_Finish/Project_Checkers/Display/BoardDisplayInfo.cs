namespace Project_Checkers;

public class BoardDisplayInfo //do not use again
{
    public int PositionBoard { get; set; }
    public int? PieceId { get; set; }
    public string Colour { get; set; }
    public string PieceType { get; set; }
    public bool IsEmpty { get; set; }
    public int? IdField { get; set; } // idfield tidak usah

    public BoardDisplayInfo(int positionBoard, int? pieceId, string colour, string pieceType, bool isEmpty, int? idField)
    {
        PositionBoard = positionBoard;
        PieceId = pieceId;
        Colour = colour; // hapus idfield
        PieceType = pieceType;
        IsEmpty = isEmpty;
        IdField = idField;
    }
}
