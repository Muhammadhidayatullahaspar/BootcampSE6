using Project13_EnumGetValue;
class Program
{
	static void Main()
	{
		//Enum -> int
		int olahraga = (int)Sport.Football;
		Console.WriteLine(olahraga); // hasilnya 948

		//int -> enum (undertemine)
		Sport sport = (Sport)732;
		Console.WriteLine(sport); //hasilnya Basketball
	
		Sport[] status = (Sport[])Enum.GetValues(typeof(Sport));
		var status2 = Enum.GetValues(typeof(Sport));
		Console.WriteLine(status);
		Sport[] newstatus = {Sport.Football, Sport.Basketball, Sport.Badminton};
		int x = status.Length;
		Console.WriteLine(x); // hasilnya 3
	}
}