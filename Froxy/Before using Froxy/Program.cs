using System;
using System.Collections.Generic;

// Mendefinisikan kelas Film dengan properti tambahan untuk durasi
public class Film
{
	public string Judul { get; set; }
	public string Genre { get; set; }
	public double Rating { get; set; }
	public string Sinopsis { get; set; }
	public DateTime WaktuPenayangan { get; set; }
	public int DurasiMenit { get; set; }  // Durasi film dalam menit

	public Film(string judul, string genre, double rating, string sinopsis, DateTime waktuPenayangan, int durasiMenit)
	{
		Judul = judul;
		Genre = genre;
		Rating = rating;
		Sinopsis = sinopsis;
		WaktuPenayangan = waktuPenayangan;
		DurasiMenit = durasiMenit;
	}

	public override string ToString()
	{
		return $"Judul: {Judul}\n" +
               $"Genre: {Genre}\n" +
               $"Rating: {Rating}\n" +
               $"Sinopsis: {Sinopsis}\n" +
               $"Waktu Penayangan: {WaktuPenayangan}\n" +
               $"Durasi: {DurasiMenit} menit";
	}
}

// Mendefinisikan kelas untuk mengelola daftar film
public class FilmManager
{
	private List<Film> films;

	public FilmManager()
	{
		films = new List<Film>();
	}

	public void TambahFilm(Film film)
	{
		films.Add(film);
	}

	public void TampilkanSemuaFilm()
	{
		foreach (var film in films)
		{
			Console.WriteLine(film);
			Console.WriteLine(); 
		}
	}
}

// Implementasi
class Program
{
	static void Main(string[] args)
	{
		var filmManager = new FilmManager();

		// Menambahkan beberapa film
		filmManager.TambahFilm(new Film(
			"Inception", 
			"Sci-Fi", 
			8.8, 
			"Sebuah film tentang mimpi dalam mimpi dan pencurian ide.",
			new DateTime(2010, 7, 16),
			148));  // Durasi dalam menit

		filmManager.TambahFilm(new Film(
			"The Matrix", 
			"Aksi", 
			8.7, 
			"Realitas sebagai simulasi dan pemberontakan terhadap mesin.",
			new DateTime(1999, 3, 31),
			136));  // Durasi dalam menit

		// Menampilkan semua film
		filmManager.TampilkanSemuaFilm();
	}
}
