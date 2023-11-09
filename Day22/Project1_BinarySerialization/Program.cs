using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Project1_BinarySerialization;
class Program
{
	static void Main()
	{
		Sport sport = new Sport{Renang = "Solo", NumberOfPeople = 2, Badminton = "ganda"};
		BinaryFormatter formatter = new BinaryFormatter();
		using (FileStream stream = new FileStream("sport.bin", FileMode.Create))
		{
			formatter.Serialize(stream, sport);
		}

		sport deserializedSport;
		using (FileStream stream = new FileStream("sport.bin", FileMode.Open))
		{
			deserializedSport = (sport)formatter.Deserialize(stream);  //unboxing
		}

		Console.WriteLine($"Deserialized sport: {deserializedSport.Renang}, {deserializedSport.NumberOfPeople}, , {deserializedSport.Badminton}");
	}
}