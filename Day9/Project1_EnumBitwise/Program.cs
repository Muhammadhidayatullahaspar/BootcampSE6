using Project1_EnumBitwise;
class Program
{
	static void Main()
	{
		Food pilih = Food.Martabak & Food.Jagung;
		Console.WriteLine(pilih);
	}
}