class Program
{
	static void Main()
	{
		Queue<int> domino = new();
		domino.Enqueue(0);
		domino.Enqueue(1);
		domino.Enqueue(2);
		domino.Enqueue(3);
		Console.WriteLine(domino.Dequeue());
		Console.WriteLine(domino.Dequeue());
		Console.WriteLine(domino.Dequeue());
		Console.WriteLine(domino.Peek());
		Console.WriteLine(domino.Peek());
	}
}