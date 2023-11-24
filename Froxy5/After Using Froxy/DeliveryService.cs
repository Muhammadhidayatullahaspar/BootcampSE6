namespace After_Using_Froxy;

public class DeliveryService : IRestaurantOrder
{
	private Restaurant connectedRestaurant;
	private Dictionary<string, bool> validVouchers;
	private string restaurantName;
	private Dictionary<string, string> customerPasswords;
	
	public DeliveryService(string restaurantName)
	{
		this.restaurantName = restaurantName;
		validVouchers = new Dictionary<string, bool>
		{
			{ "DISKON10", true },
			{ "PROMO20", true }
		};
		
		customerPasswords = new Dictionary<string, string>
		{
			{ "yayat", "salatiga" },
			{ "irfan", "123" }
		};
	}

	public void OrderFood(string customerName, string food, bool hasDiscount)
	{
		Console.Write("Masukkan password Anda: ");
        string password = Console.ReadLine();

        if (!AuthenticateCustomer(customerName, password))
        {
            Console.WriteLine("Autentikasi gagal. Password salah atau customer tidak dikenal.");
            return;
        }
		// Inisialisasi lazy: Buat objek Restaurant hanya ketika diperlukan
		if (connectedRestaurant == null)
		{
			connectedRestaurant = new Restaurant(restaurantName); // terhubung ke restoran hanya jika ada orderan, dan hanya restoran yang dipilih yang akan aktif. ini buat hemat energi
			Console.ForegroundColor = ConsoleColor.Magenta;
			Log($"Restoran {restaurantName} terhubung.");
			Console.ResetColor();
		}

		Console.ForegroundColor = ConsoleColor.Green;
		Log($"DeliveryService: Pesanan {food} diterima dari {customerName}.");
		Console.ResetColor();
		
		connectedRestaurant.OrderFood(customerName, food, hasDiscount);
		
		Console.ForegroundColor = ConsoleColor.Green;
		Log($"DeliveryService: Pesanan dari {connectedRestaurant.Name} telah dikirim ke {customerName}.");
		Console.ResetColor();
	}

	public bool CheckVoucher(string voucherCode)
	{
		return validVouchers.ContainsKey(voucherCode) && validVouchers[voucherCode];
	}

	private void Log(string message)
	{
		Console.WriteLine($"[{DateTime.Now}] {message}");
	}
	
	public bool AuthenticateCustomer(string customerName, string password)
	{
		if (customerPasswords.TryGetValue(customerName, out var storedPassword))
		{
			return storedPassword == password;
		}
		return false;
	}
}
