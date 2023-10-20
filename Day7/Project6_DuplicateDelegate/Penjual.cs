namespace Project6_DuplicateDelegate;

public class Penjual
{
	private Jual _pembeli;
	public void KirimPesanan() {
		if(_pembeli != null) 
			_pembeli.Invoke("Nasi Padang");
	}
	public bool PesanMakan(Jual sub) {
		if(_pembeli is null || !_pembeli.GetInvocationList().Contains(sub))
		{
		 	_pembeli += sub;
			return true;
		}
		return false;
	}
	public void Bayar(Jual sub) {
		_pembeli -= sub;
	}
}
