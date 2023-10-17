namespace Project13_PubSubDelegate;

public class Penjual
{
	public delegate void Notify(string message);
	private Notify pembeli;
	
	public void UploadVideo() {
		Console.WriteLine("Pesanan sedang dimasak");
		Console.WriteLine("pesanan siap disajikan");
		NotifPembeli("Terima Kasih");
	}
	public void NotifPembeli(string message) {
		pembeli.Invoke(message);
	}
	public void Masak(Notify sub) {
		pembeli += sub;
	}
	public void RemoveSubscriber(Notify sub)
	{
		pembeli -= sub;
	}
}
