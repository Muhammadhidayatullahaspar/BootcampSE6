namespace Project15_PenjualPembeli2;

public class Penjual
{
	public void Masak()
	{
		Console.WriteLine("Makanan sedang dimasak");
		Console.WriteLine("Makanan telah siap disajikan");
	}
	public void Notif(Pembeli sub,string message)
	{
		sub.Notification(message);
	}
}
