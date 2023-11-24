using System;
using System.Collections.Generic;
using After_Using_Froxy;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, string> restaurantNames = new Dictionary<int, string>
        {
            { 1, "Restoran Nusantara" },
            { 2, "Restoran Padang" },
            { 3, "Restoran Salatiga" }
        };

        Console.Write("Masukkan nama Anda: ");
        string customerName = Console.ReadLine();

        int restaurantChoice;
        bool validChoice = false;
        do
        {
            Console.WriteLine("Pilih restoran:");
            foreach (var entry in restaurantNames)
            {
                Console.WriteLine($"{entry.Key}. {entry.Value}");
            }

            Console.Write("Pilih nomor restoran: ");
            validChoice = int.TryParse(Console.ReadLine(), out restaurantChoice) && restaurantNames.ContainsKey(restaurantChoice);

            if (!validChoice)
            {
                Console.WriteLine("Pilihan restoran tidak valid. Silakan coba lagi.");
            }

        } while (!validChoice);

        string selectedRestaurantName = restaurantNames[restaurantChoice];
        var deliveryService = new DeliveryService(selectedRestaurantName);

        var customer = new Customer(customerName);

        Console.Write("Masukkan makanan yang ingin dipesan: ");
        string food = Console.ReadLine();

        Console.Write("Masukkan kode voucher (jika ada): ");
        string voucherCode = Console.ReadLine();

        Console.WriteLine();

        customer.OrderFood(deliveryService, food, voucherCode);
        Console.WriteLine();
		
		// langusung ke restoran
		// var restaurant = new Restaurant(selectedRestaurantName);
		// customer.OrderFood(restaurant, food, voucherCode);
	}
}
