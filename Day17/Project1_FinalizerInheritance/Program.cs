using System;
using Project1_FinalizerInheritance;
class Program
{
	static void Main (string[] args)
	{
		First obj = new First();
		obj = null;
		GC.WaitForPendingFinalizers();
		GC.Collect();
	}
}