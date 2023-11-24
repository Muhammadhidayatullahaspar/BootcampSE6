namespace After_Using_Froxy;

public class Customer
{
	public string Name { get; set; }

	public Customer(string name)
	{
		Name = name;
	}

	public void OrderFood(DeliveryService deliveryService, string food, string voucherCode)
	{
		bool hasDiscount = deliveryService.CheckVoucher(voucherCode);
		deliveryService.OrderFood(Name, food, hasDiscount);
	}
	
	//customer ke restorant without delivery service
	// public void OrderFood(Restaurant restaurant, string food, string voucherCode)
	// {
	// 	bool hasDiscount = restaurant.CheckVoucher(voucherCode);
	// 	restaurant.OrderFood(Name, food, hasDiscount);
	// }
}
// proxy 
// 1. lazy initialization
// 2. acces control
// 3. logging 