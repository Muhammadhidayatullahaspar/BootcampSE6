class Program
{
	static void Main()
	{
		for (int i = 0; i<10; i++)
		{
			printer(i);
		}
		int[] arrayInt = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
		foreach (int i in arrayInt)
		{
			printer(i);
			if (i == 4) break;
		}
		void printer(int x)
		{
			Console.WriteLine($"Nilainya adalah {x}");
		}
	}
}