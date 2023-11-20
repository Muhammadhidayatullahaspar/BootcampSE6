namespace EFDatabase;
using Microsoft.EntityFrameworkCore;
using Project1_SQLLite;
public class Northwind : DbContext
{
	public DbSet<Customers>? Customers {get;set;}
	public DbSet<Order>? Orders {get;set;}
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Filename=./Northwind.db");
	}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
