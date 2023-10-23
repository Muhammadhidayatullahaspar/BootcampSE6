using Project6_OverrideEqualsfromObjectandAs_Is;
class Program
{ 
	static void Main()
	{
		Film batman = new Film(6);
		Film superman = new Film(9);
		Film flash = new Film(6);
		Yayat y = new Yayat();
		bool result = batman.Equals(superman);
		bool result2 = batman.Equals(f  lash);
		Console.WriteLine($"Hasil perbandingan boolean batman dengan superman adalah {result}");
		Console.WriteLine($"Hasil perbandingan boolean batman dengan flash adalah {result2}");
	}
}