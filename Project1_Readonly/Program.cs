class Program {
	static void Main(){
		Glass gelas = new Glass("Mahal"); // construt
		Console.WriteLine(gelas.price); // keluarkan kategori harga gelas
		//gelas.price = "murah"; kalau diaktifkan, maka akan error karena hanya bisa di read dan tidak bisa di write ulang
	}
}