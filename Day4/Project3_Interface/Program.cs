using Project3_Interface; // using namespace dari project3
class Program // kelas program
{
	static void Main() // main method
	{
		Glass baru = new Glass(); // construct new glass named baru
		Console.WriteLine("Saya mau pesan minuman"); // print
		baru.Taste(); // call the value of taste from Glass class
		baru.Color(); // panggil nilai color pada Glass
		baru.Size(); // panggil nilai size pada Glass
		
	}
}