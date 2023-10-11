using Hewan;
class Program
{
	static void Main()
	{
	Bird burung = new Bird(); // construk new Bird
	burung.MakeSound(); // panggil makesound
	Animal parent2 = burung; // Hiding, tetap akan mengambil nilai animal dan tidak mengambil nilai bird
	parent2.MakeSound(); //panggil makesound
	Console.WriteLine(""); // biar ada spasi
	
	Dog hitam = new Dog(); // construk new Dog
	hitam.MakeSound(); // panggil makesound
	Animal parent3 = hitam; // override, nilai dari dog akan diambil untuk paren3
	parent3.MakeSound(); // 
	Console.WriteLine(""); // biar ada spasi
	
	Cat kucing = new Cat(); // construk kucing dari Cat
	kucing.MakeSound(); // cetak nilai makesound dari kucing yang mana nilainya ada pada animal karea kosongan pada Cat
	Animal parent4 = kucing; // buat parent dari kucing
	parent4.MakeSound(); // karena dog kosongan maka akan mengikuti parent yaitu animal
	Console.WriteLine("");
	
	}
	
}