using System;
using System.Threading;

class Program
{
	static void Main()
	{

		Thread t0 = new Thread(DoWorkSimple);
		t0.Start();
		
		
		Thread t1 = new Thread(new ThreadStart(DoWorkSimple));
		t1.Start();


		Thread t2 = new Thread(new ParameterizedThreadStart(DoWorkWithParameter));
		t2.Start("parameter");


		Thread t3 = new Thread(new ThreadStart(DoWorkSimple), 1024 * 1024 ); // 1 MB stack size
		t3.Start();

		Thread t4 = new Thread(new ThreadStart(DoWorkSimple));
		t4.Name = "Named Thread";
		t4.Start();


		Thread t5 = new Thread( () => DoWorkWithParameter("parameter2")); //lambda expression
		t5.Start();

		Thread t6 = new Thread(DoWorkWithParameter);
		t6.Start("parameter23");
		
		Thread t7 = new Thread(DoWorkWithParameter);
		t7.Start("parameter233");
	}

	static void DoWorkSimple()
	{
		Console.WriteLine("Simple work: Thread ID={0}", Thread.CurrentThread.ManagedThreadId);
	}

	static void DoWorkWithParameter(object param)
	{
		Console.WriteLine("Parameterized work: Thread ID={0}, Parameter='{1}'", Thread.CurrentThread.ManagedThreadId, param);
	}
}