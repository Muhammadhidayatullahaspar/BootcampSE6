class Program
{
	static void Main()
	{
		bool running = 10 > 0 ? true : false;
		string walk =  30 > 10 ? "Cepat" : "Lambat";
	}
	bool checker(int a, int b)
	{
		return a > b;
	}
	string checkerstring(int a, int b)
	{
		return a > b ? "Cepat" : "Lambat";
	}
}