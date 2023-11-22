namespace Before_Using_Froxy;

public class Customer
{
    public string Name { get; set; }

    public Customer(string name)
    {
        Name = name;
    }

    public void OrderFood(Restaurant restaurant, string food)
    {
        restaurant.OrderFood(Name, food);
    }
}
