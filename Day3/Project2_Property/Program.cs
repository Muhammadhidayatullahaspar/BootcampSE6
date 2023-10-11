class Program {
	static void Main() {
		Glass gelas = new Glass("Merah");
		Console.WriteLine(gelas.Color); // print warna gelas
		//car.Age = 8 // kalau diaktifkan maka error karena tidak bisa diakses
		
		gelas.Price = 5; // hasilnya akan 5000 karena dikali 1000
		int roti = gelas.Price;
		Console.WriteLine(roti); // print harga roti
	}
}