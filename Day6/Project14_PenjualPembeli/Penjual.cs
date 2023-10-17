namespace Project14_PenjualPembeli;

public class Penjual
{
	
	private Notify penjual;

	public void Masak()
	{
		//"Uploading Video...".Dump();
		Console.WriteLine("Makanan sedang dimasak...");
		Console.WriteLine("Makanan siap disajikan");
		NotifMasak("Check my video");
	}
	public void NotifMasak(string message)
	{
		penjual?.Invoke(message);
	}
	public void AddPembeli(Notify penjualBaru) {
		penjual += penjualBaru;
	}
	public void ClearPenjual() {
		penjual = null;
	}
}
