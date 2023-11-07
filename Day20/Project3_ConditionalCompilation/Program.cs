class Program
{
	static void Main()
	{
		#if HOROR
		Console.WriteLine("ini film horor");
		#elif COMEDY
		Console.WriteLine("ini film comedy");
		#endif
		Console.WriteLine("selesai");
	}
}