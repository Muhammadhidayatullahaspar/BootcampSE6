class Program
{
	static void Main()
	{
		#if COMEDY
		Console.WriteLine("ini film comedy");
		#elif DEBUG
		Console.WriteLine("ini film horor");
		#endif
		Console.WriteLine("selesai");
	}
}