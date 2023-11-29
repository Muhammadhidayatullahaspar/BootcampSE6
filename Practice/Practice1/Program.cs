class Program
{
	static void Main()
	{
		Console.WriteLine("silahkan masukkan nilai");
		int num = Convert.ToInt32(Console.ReadLine());
		Number number = new Number(); 
		number.setNumber(num); // genap or ganjil
		
		
	}
}
public class Number
{
	
	public void setNumber(int num)
	{
		if (num % 2 == 0)
		{
			Console.WriteLine("bilangan genap");
		}
		else
		{
			Console.WriteLine("bilangan ganjil");
		}
	}
}