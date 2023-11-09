using Project5_Protobuf;
using ProtoBuf;
class Program
{
	static void Main()
	{
		Person person = new Person { Name = "Alice", Age = 10 };

		// Serialize the object
		using (FileStream stream = new FileStream("person.bin", FileMode.Create))
		{
			Serializer.Serialize<Person>(stream, person);
		}

		// Deserialize the object
		Person deserializedPerson;
		using (FileStream stream = new FileStream("person.bin", FileMode.Open))
		{
			deserializedPerson = Serializer.Deserialize<Person>(stream);
		}
		deserializedPerson.GetUmur();
		Console.WriteLine($"Deserialized Person: {deserializedPerson.Name}, {deserializedPerson.Age}");
	}
}