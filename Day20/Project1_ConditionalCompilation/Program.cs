#define Horor
class Program
{
	static void Main()
	{
		#if Comedy
		Console.WriteLine("ini buat film genre comedy");
		#elif Horor
		Console.WriteLine("ini buat film genre Horor");
		#else
		Console.WriteLine("tidak ada genre film yang dipilih");
		#endif
		Console.WriteLine("selesai");
	}
}