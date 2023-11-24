using System;
using Before_Using_Froxy;
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

        Console.WriteLine("Pilih restoran:");
        foreach (var entry in restaurantNames)
        {
            Console.WriteLine($"{entry.Key}. {entry.Value}");
        }

        Console.Write("Pilih nomor restoran: ");
        int restaurantChoice = Convert.ToInt32(Console.ReadLine());

        var restaurant = new Restaurant(restaurantNames[restaurantChoice]); // langsung buat restoran
        var customer = new Customer(customerName);

        Console.Write("Masukkan makanan yang ingin dipesan: ");
        string food = Console.ReadLine();

        customer.OrderFood(restaurant, food);
    }
}
