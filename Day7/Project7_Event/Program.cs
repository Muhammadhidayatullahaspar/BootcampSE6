public delegate void MyDelegate(string uploader);
class Program
{
	static void Main()
	{
		Penjual makan = new("Nasi Padang");
		Pembeli orang1 = new Pembeli();
		Pembeli2 orang2 = new Pembeli2();

		makan.pembeli += orang1.Notification;
		makan.pembeli += orang2.Notification;
		makan.Masak();
		makan.Selesai();
		makan.Bayar();
	}
}
class Penjual
{
	public event MyDelegate pembeli;
	
	private string _name;
	public Penjual(string name)
	{
		_name = name;
	}
	public void Masak()
	{
		Console.WriteLine("Pesanan sedang dimasak");
		if (pembeli != null)
		{
			pembeli.Invoke(_name);
		}
	}
	public void Bayar() {
		Console.WriteLine("Totalnya 20k yah");
		if (pembeli != null)
		{
			pembeli.Invoke(_name);
		}
	}
	public void Selesai() {
		pembeli = null;
	}
}
class Pembeli
{
	public void Notification(string x)
	{
		Console.WriteLine($"Saya orang pertama beli {x}");
	}
}
class Pembeli2
{
	public void Notification(string x)
	{
		Console.WriteLine($"Saya orang kedua beli {x}");
	}
}