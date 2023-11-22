using System;
using System.Collections.Generic;

// Mendefinisikan kelas Film
public class Film
{
	public string Title { get; set; }
	public string Genre { get; set; }
	public double Rating { get; set; }
	public string Sinopsis { get; set; }
	public DateTime Showtime { get; set; }
	public int Duration { get; set; }  // Durasi film dalam menit

	public Film(string title, string genre, double rating, string sinopsis, DateTime showtime, int duration)
	{
		Title = title;
		Genre = genre;
		Rating = rating;
		Sinopsis = sinopsis;
		Showtime = showtime;
		Duration = duration;
	}

	public override string ToString()
	{
	   return $"Title: {Title}\n" +
			   $"Genre: {Genre}\n" +
			   $"Rating: {Rating}\n" +
			   $"Sinopsis: {Sinopsis}\n" +
			   $"Waktu Penayangan: {Showtime}\n" +
			   $"Durasi: {Duration} menit\n";
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

	public void AddFilm(Film film)
	{
		films.Add(film);
	}

	public void ShowAllFilms()
	{
		foreach (var film in films)
		{
			Console.WriteLine(film);
		}
	}
}

// Proxy untuk FilmManager
public class FilmManagerProxy
{
	private FilmManager filmManager;

	public FilmManagerProxy()
	{
		filmManager = new FilmManager();
	}

	public void AddFilm(Film film)
	{
		Console.WriteLine($"Menambahkan film: {film.Title}");
		filmManager.AddFilm(film);
	}

	public void ShowAllFilms()
	{
		Console.WriteLine(); 
		Console.WriteLine("Menampilkan semua film:");
		filmManager.ShowAllFilms();
	}
}

// Implementasi
class Program
{
	static void Main(string[] args)
	{
		var filmManagerProxy = new FilmManagerProxy();

		// Menambahkan beberapa film melalui proxy
		filmManagerProxy.AddFilm(new Film(
			"Spiderman",
			"Action, Adventure, Sci-Fi",
			8.8,
			"Nama asli Spider-Man adalah Peter Parker. Ia tinggal bersama paman dan bibinya di sebuah apartemen di Queens, Manhattan. Sejak kecil ia sudah menyukai tetangganya yang bernama Mary Jane Watson. Awal mula ia menjadi Spider-Man ialah ketika ia mengunjungi sebuah institut milik Norman Osborn. Sebuah laba-laba beradioaktif menggigitnya yang kemudian membuat Peter memiliki kekuatan laba-laba super. Dalam ceritanya Spider-Man (juga biasa disingkat Spidey).",
			new DateTime(2010, 7, 16),
			148));

		filmManagerProxy.AddFilm(new Film(
			"The Matrix",
			"Aksi",
			8.7,
			"Realitas sebagai simulasi dan pemberontakan terhadap mesin.",
			new DateTime(1999, 3, 31),
			136));

		// Menampilkan semua film melalui proxy
		filmManagerProxy.ShowAllFilms();
	}
}
