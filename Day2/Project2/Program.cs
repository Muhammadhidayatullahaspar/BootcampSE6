using CarComponent; // pakai carcomponen
using Transportation; // pakai workspace transportation
class Program()

{
	static void Main()
	{
		Engine kuda = new Engine ("Kuda", 76); // construct kuda baru
		kuda.PrintEngine(); // keluarkan kalimat lewat method printengine
		Console.WriteLine(""); // biar ada spasi
		
		Lamp sharp = new Lamp (); // costruct lampu baru
		Console.WriteLine("Bahan lampu " + sharp.lampIngredients); // print bahan lampu tanpa method
		Console.WriteLine("Kecerahan cahaya " + sharp.shinePower); // print bahan lampu tanpa method
		
	}
}