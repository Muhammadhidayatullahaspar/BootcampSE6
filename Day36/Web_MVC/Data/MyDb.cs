
using Microsoft.EntityFrameworkCore;

namespace MyAPI.Data;

public class MyDb : DbContext
{
	public MyDb(DbContextOptions options) : base(options)
	{
	}
	public DbSet<Category> Categories { get; set; }
	public DbSet<Product> Products { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<Category>(c =>
			{
				c.HasKey(c => c.CategoryId);
				c.Property(c => c.CategoryName).IsRequired().HasMaxLength(20);
				c.Property(c => c.Description).HasMaxLength(300);
				c.HasMany(c => c.Products).WithOne(p => p.Category);
			});		
		builder.Entity<Product>(p =>
			{
				p.HasKey(p => p.ProductId);
				p.Property(c => c.ProductName).IsRequired().HasMaxLength(20);
				p.Property(c => c.Description).HasMaxLength(300);
			});
		builder.Entity<Category>().HasData(
			new Category() { CategoryId = 1, CategoryName = "Elektronik", Description = "Ini Elektronik" },
			new Category() { CategoryId = 2, CategoryName = "Buah", Description = "ini buah" }
		);
		builder.Entity<Product>().HasData(
			new Product() { ProductId = 1, ProductName = "Xiaomi", Description = "Ini Elektronik", CategoryId = 1 },
			new Product() { ProductId = 2, ProductName = "Samsung", Description = "ini buah" , CategoryId = 1}
		);
		
	}
	
}
