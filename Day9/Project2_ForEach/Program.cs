using Project2_ForEach;
class Program
{
	static void Main()
	{
		int[] Array = {1, 2, 3, 4, 5, 6, 7, 8, 9};
		foreach (int i in Array)
		{
			Console.WriteLine(i);
		}
		List<string> taste = new List<string>() { "pedas", "manis", "pahit"};
		foreach (string item in taste)
		{
			Console.WriteLine(item);
		}
		List<Food> foodList = new List<Food>()
		{
			new Food("pisang"),
			new Food("Martabak"),
			new Food("Coto")
		};
		foreach (Food food in foodList)
		{
			Console.WriteLine(food.name);
		}
		
	}
	
	
}