
class Glass {
	public string Color {get; private set;} //property
	private int _price;
	public int Price // kalau pricenya diatas 0, maka akan dikali 1000
	{
		get
		{
			return _price * 1000; // kali 1000
		}
		set
		{
			if(value > 0) { // jika diatas 0
				_price = value;
			}
		}
	}
	
	private string _brand;
	public Glass(string color) { //warna
		Color = color;
	}
	
	
}