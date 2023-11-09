namespace Project5_Protobuf;
using ProtoBuf;
[ProtoContract]
public class Person
{
	[ProtoMember(1)]
	public string Name { get; set; }

	[ProtoMember(2)]
	public  int Age { get; set; }

	[ProtoMember(3)]
	private int Umur = 23;
	
	public void GetUmur() 
	{
		Console.WriteLine(Umur);
	}
}