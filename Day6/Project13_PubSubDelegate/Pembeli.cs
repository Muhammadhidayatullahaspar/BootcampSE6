namespace Project13_PubSubDelegate;

class Pembeli 
	{
	public void Notification(string message) 
		{
		//$"Pembeli 1 got notif : {message}".Dump();
		Console.WriteLine($"Pembeli 1 got notif : {message}");
		}
	}
class Pembeli2
	{
	public void Notification(string message)
		{
		Console.WriteLine($"Pembeli 2 got notif : {message}");
		}
	}
class Pembeli3
{
	public void Notification(string message)
		{
		Console.WriteLine($"Pembeli 3 got notif : {message}");
		}
}