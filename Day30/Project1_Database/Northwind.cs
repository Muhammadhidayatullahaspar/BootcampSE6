namespace Project1_Database;
using Microsoft.EntityFrameworkCore;
public class Northwind : DbContext
{
	public DbSet<Film> Films { get; set; }
	public DbSet<Genre> Genres { get; set; }
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("FileName = ./Mydatabase.db");
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Genre>( Gen => 
			{
				Gen.Property(G => G.GenreName).HasMaxLength(50).IsRequired();
				Gen.HasKey(G => G.GenreId);
				Gen.Property(G => G.Description).HasMaxLength(150).IsRequired();
				Gen.HasMany(G => G.Films).WithOne(F => F.Genre);
			});
		modelBuilder.Entity<Film>( Fil => 
			{
				Fil.Property(F => F.Title).HasMaxLength(50).IsRequired();
				Fil.HasKey(F => F.IdFilm);
				Fil.Property(F => F.Rating);
				Fil.Property(F => F.Description).HasMaxLength(150).IsRequired();
			});
	}


}