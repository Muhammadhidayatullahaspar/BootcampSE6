class Program
{
	static void Main()
	{
		Action <string> belanja = null;
		belanja += (string s) => Console.WriteLine(s);
		belanja?.Invoke("Belanja");
	}
	static void Makan(string pesanan)
	{
		Console.WriteLine("Saya sudah makan");
	}
	static void Minum(string pesanan)
	{
		Console.WriteLine("Saya sudah minum");
	}
}