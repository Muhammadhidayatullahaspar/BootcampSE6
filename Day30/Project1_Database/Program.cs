using System.Data.Common;
using Project1_Database;
class Program
{
	static void Main()
	{
		using(Northwind db = new Northwind())
		{
			Film newProduct = new Film()
			{
				IdFilm = 1, 
				Title = "Spiderman",
				Rating = 9,
				Description = "ini film baru dari netflix",
				GenreId = 1
			};
		}
		
	}
}