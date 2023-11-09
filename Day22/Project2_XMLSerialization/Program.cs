using System.IO;
using System.Xml.Serialization;
using Project2_XMLSerialization;
class Program
{
	static void Main()
	{
		Sport sport = new Sport{Renang = "Solo", NumberOfPeople = 2, Badminton = "ganda"};
		Type type = typeof(Sport);
		XmlSerializer serializer = new XmlSerializer(type);
		using (StreamWriter writer = new StreamWriter("sport.xml"))
		{
			serializer.Serialize(writer, sport);
		}

		Sport deserializedSport;
		using (StreamReader reader = new StreamReader("sport.xml"))
		{
			deserializedSport = (Sport)serializer.Deserialize(reader);
		}
		
		Console.WriteLine($"Deserialized sport: {deserializedSport.Renang}, {deserializedSport.NumberOfPeople}, , {deserializedSport.Badminton}");
	}
}