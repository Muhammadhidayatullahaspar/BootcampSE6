namespace Project1_Database;

public class Film
{
	public int IdFilm { get; set; }
	public string Title { get; set; } = null!;
	public int Rating { get; set; }
	public string? Description { get; set; }
	public Genre Genre { get; set; } = null!;
	public int GenreId { get; set; }
	
}
