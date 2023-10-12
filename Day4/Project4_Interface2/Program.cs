using Microsoft.Win32.SafeHandles; // panggil namespacenya
using Project4_Interface2;
class Program // kelas program
{
	static void Main() // method utama
	{	
		Console.WriteLine(""); // buat spasi
		IComedy UpinIpin = new Film(); // konstruct Icomedy dari film baru
		UpinIpin.Rating(3); // beri rating 3 dari film
		UpinIpin.Hbo(); // panggil nilai hbo
		UpinIpin.Ketawa(); // panggil kalimat ketawa
		Console.WriteLine(""); // spasi
		
		IRomance Lover = new Film(); // konstruk romance dari film
		Lover.Rating(9); // beri rating 9
		Lover.Baper(); // panggil baper
		Lover.Bioskop(); // panggil bioskop
		Console.WriteLine(""); // spasi
	}	
}