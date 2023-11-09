using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
public enum Code
{
	Safe = 0,
	Error = 1
}
[DataContract]
public class Person
{
	[DataMember]
	private string name;

	[DataMember]
	internal int age;

	[DataMember]
	private Code code;
	
	public Person(string name, int age, Code code)
	{
		this.name = name;
		this.age = age;
		this.code = code;
	}
	
	public string GetName()
	{
		return name + " " + (int)code;
	}
}

class Program
{
	static void Main()
	{
		var p = new Person("ZJohn", 123, Code.Error);
		var p2 = new Person("Yusuf", 444, Code.Safe);
		List<Person> people = new();
		people.Add(p);
		people.Add(p2);

		DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Person>));
		using (FileStream stream = new FileStream("person.json", FileMode.OpenOrCreate))
		{
			ser.WriteObject(stream, people);
		}

		List<Person> importPerson;
		using (FileStream stream2 = new FileStream("person.json", FileMode.Open))
		{
			importPerson = (List<Person>)ser.ReadObject(stream2);
		}

		foreach (var person in importPerson)
		{
			Console.WriteLine(person.GetName());
		}
	}
}