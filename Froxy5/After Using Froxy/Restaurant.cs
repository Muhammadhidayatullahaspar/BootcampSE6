namespace After_Using_Froxy;

public class Restaurant : IRestaurantOrder
{
	public string Name { get; set; }
	// private Dictionary<string, bool> validVouchers;
	public Restaurant(string name)
	{
		Name = name;
		// validVouchers = new Dictionary<string, bool>
		// {
		// 	{ "RESTO20", true },
		// 	{ "RESTOSAL", true }
		// };
	}

	public void OrderFood(string customerName, string food, bool hasDiscount)
	{
		var price = CalculatePrice(food, hasDiscount);
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine($"{customerName} memesan {food} dari {Name}. Total harga: {price} (Diskon diterapkan: {hasDiscount})");
		Console.ResetColor();
		if (hasDiscount)
		{
			Console.Write($"[{DateTime.Now}] Pesanan diterima: {customerName} memesan {food}");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write(" dengan diskon");
			Console.ResetColor();
			Console.WriteLine($" dari {Name}");
		}
		else
		{
			Log($"Pesanan diterima: {customerName} memesan {food} dari {Name}");
		}

		Log("Memproses pesanan...");
		Thread.Sleep(1000);
		Log($"Mempersiapkan bahan-bahan untuk {food}...");
		Thread.Sleep(2000);
		Log($"Memasak {food}...");
		Thread.Sleep(3000);
		Log($"{food} telah selesai.");
	}

	private void Log(string message)
	{
		Console.WriteLine($"[{DateTime.Now}] {message}");
	}
	 private decimal CalculatePrice(string food, bool hasDiscount)
	{
		decimal basePrice = GetBasePrice(food); // Kembalikan harga dasar
		if (hasDiscount)
		{
			return basePrice * 0.9M; // Contoh diskon 10%
		}
		return basePrice;
	}

	private decimal GetBasePrice(string food)
	{
		return 100; // Harga contoh
	}


	// dari customer ke restoran
	// public bool CheckVoucher(string voucherCode)
	// {
	// 	return validVouchers.ContainsKey(voucherCode) && validVouchers[voucherCode];
	// }
}
