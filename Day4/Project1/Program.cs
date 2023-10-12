using stuff; //using namespace
class Program // kelas program
	{

	static void Main() // method utama
	{
		PlasticGlass baru = new(); // construct plastikglass baru
		baru.cold(); // panggil nilai plastik glass dingin
		Console.WriteLine(""); // berikan spasi
		
		SteelGlass besi = new(); // construct steelglasss baru
		besi.hot(); // keluarkan besi hot
		Console.WriteLine(); // spasi
	
		Glass glass = new PlasticGlass(); // override dari Plastic
		glass.hot();// akan mengeluarkan nilai dari plastic glass
		glass.cold(); // akan mengeluarkan nilai dari Glass karena tidak override
		
	}
	}