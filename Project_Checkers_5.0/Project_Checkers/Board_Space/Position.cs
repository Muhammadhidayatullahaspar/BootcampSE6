namespace Project_Checkers;

public class Position
{
	public int x;
	public int y;
	
	// public readonly int id;
	// public readonly int x;
	// public readonly int y;
		
	// public Position(int id, int x, int y)
	// {
	// 	this.x = x;
	// 	this.y = y;
	// 	this.id = int.Parse(x.ToString() + y.ToString());
	// }
	// public override int GetHashCode()
	// {
	// 	return id;
	// }

}
// hashcode tutorial
// void Main()
// {

//     Dictionary<Position, int> dict = new();
//     dict.Add(new Position(34), 5); // 34 seperti posisi id sampai 1 - 64
//     dict.Add(new Position(35), 6); // sebelah kanan untuk id piece yang dikembalikan, jadi kalau pada id posisi tidak ada piecenya maka akan keluarkan 0 
//     dict.TryGetValue(new Position(35), out int value);
//     value.Dump();
// }
// class Position
// {
//     public int id;
//     public Position(int id)
//     {
//         this.id = id;
//     }
//     public override int GetHashCode()
//     {
//         return id.GetHashCode();
//     }
//     public override bool Equals(object obj)
//     {
//         if (obj == null || GetType() != obj.GetType())
//         {
//             return false;
//         }
//         Position other = (Position)obj;
//         return id == other.id;
//     }
// }