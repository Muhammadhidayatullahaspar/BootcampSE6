using CarComponent;
namespace Transportation{
class Car
	{
		public Engine mesin;
		public Lamp lampu;
		public Tire ban; 
		
		public Car(Engine engine, Lamp lamp, Tire tire)
		{
			mesin = engine;
			lampu = lamp;
			this.ban = tire;
		}
		
	}
}