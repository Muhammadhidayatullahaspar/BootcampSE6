using CarComponent; // gunakan namespace carcomponent
namespace Transportation; // jadikan workspace transportation

public class Car // nama kelas
{
	public Engine mesin; //
	public Lamp lampu; // 
	public Tire ban; //
	public Car(Engine engine, Tire tire, Lamp lamp) // construct
	{
		Console.WriteLine("sudah menerima mesin, ban, lampu");
		mesin = engine;
		ban = tire;
		this.lampu = lamp;
	}
	public void EngineCheck()
	{
		// Console.WriteLine(engine);
	}
	public void TireCheck() 
	{
		// Console.WriteLine(tire);
	}

}
