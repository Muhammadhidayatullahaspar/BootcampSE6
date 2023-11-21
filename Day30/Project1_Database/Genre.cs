namespace Project1_Database;

public class Genre
{
	public int GenreId { get; set; }
	public String GenreName { get; set; } = null!;
	public string? Description { get; set; }
	public ICollection<Film> Films { get; set;}
	public Genre()
	{
		Films = new HashSet<Film>();
	}
}
