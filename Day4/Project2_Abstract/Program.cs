using stuff; // pakai stuff namespace
class Program // kelas program
{
	static void Main() // method utama
	{
		GlassPlastic baru = new(); // construct glassplastik
		Console.WriteLine(baru.width); // panggil nilai barunya widht
	
		Glass gelas = new GlassPlastic(); // construct Glass
		gelas.Age(); // panggil agenya glass karena bukan override di glassplastic
		gelas.Brand(); // mengeluarkan nilai brand pada glassplastic yang telah mengisi abstract glass
	}
}  