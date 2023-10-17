namespace Project14_PenjualPembeli;

public class Pembeli
{
	public void Notification(string message)
	{
		//$"Subscriber 1 got notif : {message}".Dump();
		Console.WriteLine($"Subscriber 1 got notif : {message}");
	}
	public void Beli(Penjual pub) {
		pub.AddPembeli(Notification);
	}
}
