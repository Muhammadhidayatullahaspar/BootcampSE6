using Project11_ListCollection;

class program
{
	static void Main()
	{
	List<IFilm> myList = new List<IFilm>(); // list interface Film
	myList.Add(new Comedy()); // tambahkan kedalam list
	myList.Add(new Romance());
	myList.Add(new Horor());
	Horor horor = new Horor(); // construct kelas Horor
	horor.Nama("Tuyul"); // keluarkan nama
	}
}
