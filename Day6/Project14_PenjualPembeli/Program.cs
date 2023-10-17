using Project14_PenjualPembeli;
public delegate void Notify(string message);
class program
{
	static void Main()
	{
		Penjual pub = new Penjual();
		Pembeli sub1 = new Pembeli();
		sub1.Beli(pub);
		pub.Masak();
		
		pub.ClearPenjual();
		pub.Masak();
	}
}