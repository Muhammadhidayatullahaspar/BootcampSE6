using Project15_PenjualPembeli2;
public delegate void Notify(string message);
class Program
{
	static void Main()
	{
		Pembeli sub1 = new();
		Pembeli sub2 = new();
		Pembeli sub3 = new();
		
		Penjual pub = new();
		pub.Notif(sub1, "Saya pesan martabak manis");
		pub.Notif(sub2, "saya pesan martabak telur");
		pub.Notif(sub3, "saya pesan dua duanya");
		
		pub.Notif(sub1, "cash");
		pub.Notif(sub2, "cash");
		pub.Notif(sub3, "cash");
	}
}