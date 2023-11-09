using System.Text.Json;
using Project4_JSONSerialization2;
class Program
{
	static void Main()
	{
		List<Sport> sport = new List<Sport>
		{
			new Sport { Renang = "bebas", NumberOfPeople = 12, Badminton = "Ganda" },
			new Sport { Renang = "kupu kupu", NumberOfPeople = 30, Badminton = "Tunggal" }
		};
		string jsonString = JsonSerializer.Serialize(sport);
		using (StreamWriter writer = new StreamWriter("Sport.json"))
		{
			writer.Write(jsonString);
		}

		string jsonFromFile;
		using (StreamReader reader = new StreamReader("Sport.json"))
		{
			jsonFromFile = reader.ReadToEnd();
		}
		
		List<Sport> deserializedSport = JsonSerializer.Deserialize<List<Sport>>(jsonFromFile);
		foreach (var Sport in deserializedSport)
		{
			Console.WriteLine($"Deserialized sport: {Sport.Renang}, {Sport.NumberOfPeople}, , {Sport.Badminton}");
		}
	}
}