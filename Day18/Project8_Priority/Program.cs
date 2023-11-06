using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread t1 = new Thread(() =>
        {
            Console.WriteLine("Thread 1 started");
            Thread.Sleep(5000);
            Console.WriteLine("Thread 1 finished");
        });
        t1.Priority = ThreadPriority.Lowest;
        
        Thread t2 = new Thread(() =>
        {
            Console.WriteLine("Thread 2 started");
            Thread.Sleep(5000);
            Console.WriteLine("Thread 2 finished");
        });
        t2.Priority = ThreadPriority.Highest;
        
        // Start the threads
        t1.Start();
        t2.Start();
        
        // Wait for the threads to finish
        t1.Join();
        t2.Join();
        
        Console.WriteLine("All threads finished");
    }
}