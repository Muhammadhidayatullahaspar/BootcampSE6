class Program
{
	static void Main()
	{
		Stack<int> domino = new();
		domino.Push(0);
		domino.Push(1);
		domino.Push(2);
		domino.Push(3);
		Console.WriteLine(domino.Pop());
		Console.WriteLine(domino.Pop());
		Console.WriteLine(domino.Pop());
		Console.WriteLine(domino.Peek());
		Console.WriteLine(domino.Peek());
	}
}