namespace Before_Using_Froxy;

public class Restaurant
{
    public string Name { get; set; }

    public Restaurant(string name)
    {
        Name = name;
    }

    public void OrderFood(string customerName, string food)
    {
        Console.WriteLine($"{customerName} memesan {food} dari {Name}.");
    }
}
