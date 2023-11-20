namespace Project1_SQLLite;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
public class Customers
{
	public int CustomerId { get; set; }
	public string? ContactName { get; set; }
	public string? City { get; set; }
	public string? Region { get; set; }
	public ICollection<Order> Orders { get; set; }
	public Customers() 
	{
		Orders = new HashSet<Order>();
	}
	
}
