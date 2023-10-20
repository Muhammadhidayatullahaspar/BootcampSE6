using Project6_DuplicateDelegate;
public delegate void Jual(string x);
class program
{
	static void Main() {
		Penjual pub = new();
		Pembeli sub = new();
		pub.PesanMakan(sub.Notify);
		pub.PesanMakan(sub.Notify);// duplicate delegate 
		pub.KirimPesanan();
		
		pub.Bayar(sub.Notify);
		pub.KirimPesanan();
	}
}