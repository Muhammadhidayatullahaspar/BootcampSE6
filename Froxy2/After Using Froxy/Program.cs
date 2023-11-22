using System;
using System.Collections.Generic;

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
        // Proses pesanan di sini
    }
}

// Kelas LayananPengiriman sebagai Proxy
public class LayananPengiriman
{
    private Restoran restoranTerhubung;

    public LayananPengiriman(Restoran restoran)
    {
        restoranTerhubung = restoran;
    }

    public void PesanMakanan(string namaPelanggan, string makanan)
    {
        // Validasi pesanan
        if (string.IsNullOrWhiteSpace(makanan))
        {
            Console.WriteLine("LayananPengiriman: Maaf, Anda belum memilih makanan.");
            return;
        }

        // Pencatatan log
        Console.WriteLine($"LayananPengiriman: Menerima pesanan {makanan} dari {namaPelanggan}.");

        // Mengirim pesanan ke restoran
        restoranTerhubung.PesanMakanan(namaPelanggan, makanan);

        // Tambahan log setelah mengirim pesanan
        Console.WriteLine($"LayananPengiriman: Pesanan {makanan} oleh {namaPelanggan} telah dikirim ke restoran.");
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

    public void PesanMakanan(LayananPengiriman layananPengiriman, string makanan)
    {
        layananPengiriman.PesanMakanan(Nama, makanan);
    }
}

// Implementasi
class Program
{
    static void Main(string[] args)
    {
        // Membuat daftar restoran
        var restoranNusantara = new Restoran("Restoran Nusantara");
        var restoranPadang = new Restoran("Restoran Padang");
        var restoranSunda = new Restoran("Restoran Sunda");

        List<Restoran> restoranList = new List<Restoran> { restoranNusantara, restoranPadang, restoranSunda };

        // Input nama pelanggan
        Console.Write("Masukkan nama Anda: ");
        string namaPelanggan = Console.ReadLine();

        // Menampilkan daftar restoran
        Console.WriteLine("Pilih restoran:");
        for (int i = 0; i < restoranList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {restoranList[i].Nama}");
        }

        // Memilih restoran
        Console.Write("Pilih nomor restoran: ");
        int pilihanRestoran = Convert.ToInt32(Console.ReadLine());

        // Validasi pilihan restoran
        if (pilihanRestoran < 1 || pilihanRestoran > restoranList.Count)
        {
            Console.WriteLine("Pilihan restoran tidak valid.");
            return;
        }

        // Membuat instance pelanggan dan layanan pengiriman
        var pelanggan = new Pelanggan(namaPelanggan);
        var layananPengiriman = new LayananPengiriman(restoranList[pilihanRestoran - 1]);

        // Memesan makanan
        Console.Write("Masukkan makanan yang ingin dipesan: ");
        string makanan = Console.ReadLine();

        pelanggan.PesanMakanan(layananPengiriman, makanan);
    }
}
