using System.Diagnostics;
static class Program
{
	static void Main()
	{
		int UserId = 123;
		string UserName = "yayat";
		Debug.WriteLine(UserId + " " + UserName);
		Trace.WriteLine("tracing user " + UserName);
		Debug.Assert(false, "Tracing");
		Trace.Assert(false, "Tracing");
		Console.Read();
	}
}
