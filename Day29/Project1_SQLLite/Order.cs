namespace Project1_SQLLite;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
public class Order
{
	public int OrderId { get; set; }
	[Column("OrderDate", TypeName = "datetime")]
	public DateTime? OrderDate { get; set; }
	public string? ShipRegion { get; set; }
}
