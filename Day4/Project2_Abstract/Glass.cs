namespace stuff; // namespace stuff
abstract class Glass // kelas abstract yang bertujuan sebagai wadah kosong
{
	public int count = 1; // int count
	public string color = "black"; // string color
	
	public abstract void Brand(); // kosongan method abstract yang bisa diisi anaknya
	public void Age() // method age
	{
		Console.WriteLine("sudah lebih setahunlah"); // print
	}
}
