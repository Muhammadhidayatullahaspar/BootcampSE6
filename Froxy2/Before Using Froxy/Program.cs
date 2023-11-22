using System;

// Kelas Restoran
public class Restoran
{
    public string Nama { get; set; }

    public Restoran(string nama)
    {
        Nama = nama;
    }

    public void PesanMakanan(string namaPelanggan, string makanan)
    {
        Console.WriteLine($"{namaPelanggan} memesan {makanan} dari {Nama}.");
        // Logika untuk memproses pesanan bisa ditambahkan di sini
    }
}

// Kelas Pelanggan
public class Pelanggan
{
    public string Nama { get; set; }

    public Pelanggan(string nama)
    {
        Nama = nama;
    }

    public void PesanMakanan(Restoran restoran, string makanan)
    {
        restoran.PesanMakanan(Nama, makanan);
    }
}

// Implementasi
class Program
{
    static void Main(string[] args)
    {
        var restoran = new Restoran("Restoran Nusantara");

        // Meminta input nama pelanggan
        Console.Write("Masukkan nama pelanggan: ");
        string namaPelanggan = Console.ReadLine();
        var pelanggan = new Pelanggan(namaPelanggan);

        // Meminta input makanan yang ingin dipesan
        Console.Write("Masukkan makanan yang ingin dipesan: ");
        string makanan = Console.ReadLine();

        pelanggan.PesanMakanan(restoran, makanan);
    }
}
