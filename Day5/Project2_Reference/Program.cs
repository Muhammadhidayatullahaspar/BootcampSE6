using Project2_Reference;
class program
{
	static void Main()
	{
		string x = "7";
		Glass hitam = new Glass(4);
		Glass merah = hitam;
		merah.value = 1;
		Glass hijau = new Glass(9);
		hijau = hitam;
		hitam.value();
		merah.value(); 
		
	}
}