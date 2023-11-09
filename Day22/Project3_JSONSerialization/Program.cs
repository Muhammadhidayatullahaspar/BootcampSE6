using Project3_JSONSerialization;
using System.Text.Json;
class Program
{
	static void Main()
	{
		Sport sport = new Sport{Renang = "Solo", NumberOfPeople = 2, Badminton = "ganda"};
		string jsonString = JsonSerializer.Serialize(sport);
		using (StreamWriter writer = new StreamWriter("sport.json"))
		{
			writer.Write(jsonString);
		}


		//Deserialize
		string jsonFromFile;
		using (StreamReader reader = new StreamReader("sport.json"))
		{
			jsonFromFile = reader.ReadToEnd();
		}
		Sport? deserializedSport = JsonSerializer.Deserialize<Sport>(jsonFromFile);
		Console.WriteLine($"Deserialized sport: {deserializedSport.Renang}, {deserializedSport.NumberOfPeople}, , {deserializedSport.Badminton}");

	}
}